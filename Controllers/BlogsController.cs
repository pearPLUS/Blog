using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyBlog.Areas.Identity.Data;
using MyBlog.Data;
using MyBlog.Models;

namespace MyBlog.Controllers
{
    public class BlogsController : ApplicationBasedController
    {
        private readonly ApplicationDbContext _context;

        public BlogsController(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        // GET: Blogs
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        { 

            var indexBlog = new IndexBlogViewModel() {

                Blogs = await _context.Blog.Include(b => b.Catergory).OrderByDescending(b => b.PostTime).ToListAsync(),
                Labels = await _context.label.ToListAsync()
            };
            return View(indexBlog);
        }

        // GET: Blogs/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {



            if (id == null)
            {
                return NotFound();
            }
            // to include many to many relationship value 
            // get one level childcomment 

            var Blog = await _context.Blog
                .Include(blog => blog.Catergory)
                .Include(blog => blog.LabelsBlogs)
                .ThenInclude(labelBlogs => labelBlogs.Label)
                .Include(blog => blog.Comments)
                .ThenInclude(Comment => Comment.ApplicationUser)
                .Include(blog => blog.Comments)
                .ThenInclude(Comment => Comment.ChildComment)
                .ThenInclude(Comment => Comment.ApplicationUser)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Blog == null)
            {
                return NotFound();
            }

            // judge wether current user have like the blog
            short? likeStatus = null;
            if(!string.IsNullOrEmpty(User.Identity.Name))
            {
                var user = _context.Users.SingleOrDefault(u => u.UserName == User.Identity.Name);
                var userId = user.Id;
                var blogLike = await _context.BlogLike.FirstOrDefaultAsync(b => b.BlogId == Blog.Id && b.UserId == userId);

                // avoid null reference 
                if (blogLike != null)
                {
                    likeStatus = blogLike.Status;
                }
            }


            var blogDetail = new BlogDetailViewModel()
            {
                blog = Blog,
                likeStatus = likeStatus
            };

            // add Browse count
            Blog.BrowseCount++;

            if (ModelState.IsValid)
            {
                _context.Update(Blog);
                await _context.SaveChangesAsync();

            }
           
            return View(blogDetail);
        }
       
        [Authorize(Roles = "Admin, Memeber")]
        // GET: Blogs/Create
        public async Task<IActionResult> Create()
        {
            var catergories = await _context.Catergory.ToListAsync();
            var labels = await _context.label.ToListAsync();

            var newBlog = new NewBlogViewModel
            {
                Catergories = catergories,
                labels = labels
            };
            return View(newBlog);
        }

        // POST: Blogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Memeber")]
        public async Task<IActionResult> Create([Bind("Blog", "Catergories", "labels", "LabelStr")] NewBlogViewModel newBlog)
        {


           
            newBlog.Blog.PostTime = DateTime.Now.Date;

            // if article has tabs 
            if (newBlog.LabelStr != null)
            {
                if (ModelState.IsValid)
                {
                    var StrArr = newBlog.LabelStr.Split(",");
                    for (int i = 0; i < StrArr.Length - 1; i++)
                    {

                        var blogLabel = new BlogLabel();
                        blogLabel.Blog = newBlog.Blog;

                        var LabelId = System.Convert.ToInt32(StrArr[i]);
                        var Label = _context.label.Find(LabelId);
                        blogLabel.Label = Label;
                        _context.Add(blogLabel);
                        await _context.SaveChangesAsync();
                    }

                    // increment the article counts 
                    var author = await _context.Users.FirstOrDefaultAsync(m => m.Id == newBlog.Blog.FKApplicationUser);
                    author.ArticleCount++;
                    await _context.SaveChangesAsync();


                    return RedirectToAction(nameof(Index));

                }

            }

            //if doesn;t have tabs
            else
            {
                if (ModelState.IsValid)
                {
                    _context.Add(newBlog.Blog);
                    await _context.SaveChangesAsync();
                    // increment the article counts 
                    var author = await _context.Users.FirstOrDefaultAsync(m => m.Id == newBlog.Blog.FKApplicationUser);
                    author.ArticleCount++;
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

                
            }

            var catergories = await _context.Catergory.ToListAsync();
            var labels = await _context.label.ToListAsync();
            newBlog.Catergories = catergories;
            newBlog.labels = labels;
            return View(newBlog);
        }

        // GET: Blogs/Edit/5
        [HttpGet("Blogs/Edit/{id}")]
        [Authorize(Roles = "Admin, Memeber")]
        public async Task<IActionResult> Edit(int? id)
        {

            var username = User.Identity.Name;
            var user = await _context.Users.SingleOrDefaultAsync(u => u.UserName == username);
            if (id == null)
            {
                return NotFound();
            }

            var Blog = await _context.Blog.FindAsync(id);
            if (Blog == null)
            {
                return NotFound();

            }

            if (Blog.FKApplicationUser != user.Id)
            {
                return NotFound();
            }
          
            return View(Blog);
        }

        // POST: Blogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Memeber")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,author,BlogTitle,BlogBrief,BlogContent,FkCatergory,tabs,PostTime,LikeCount,CommentCount,BrowseCount,FKApplicationUser")] Blog blog)
        {
            if (id != blog.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(blog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogExists(blog.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(blog);
        }

        // GET: Blogs/Delete/5
        [Authorize(Roles = RoleName.admin)]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _context.Blog
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }

        // POST: A/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.admin)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blog = await _context.Blog.FindAsync(id);
            _context.Blog.Remove(blog);
            await _context.SaveChangesAsync();

            // after delete article, decrement 
            var author = await _context.Users.FirstOrDefaultAsync(m => m.Id == blog.FKApplicationUser);
            author.ArticleCount--;
            await _context.SaveChangesAsync();


            return RedirectToAction(nameof(Index));
        }

        private bool BlogExists(int id)
        {
            return _context.Blog.Any(e => e.Id == id);
        }
    }
}
