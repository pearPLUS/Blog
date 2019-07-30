using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyBlog.Data;
using MyBlog.Models;

namespace MyBlog.Controllers
{
    public class BlogCommentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BlogCommentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BlogComments
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.BlogComment.Include(b => b.ApplicationUser).Include(b => b.Blog);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: BlogComments/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogComment = await _context.BlogComment
                .Include(b => b.ApplicationUser)
                .Include(b => b.Blog)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blogComment == null)
            {
                return NotFound();
            }

            return View(blogComment);
        }

        // GET: BlogComments/Create
        [AllowAnonymous]
        public IActionResult Create()
        {
            ViewData["FKApplicationUser"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["FKBlog"] = new SelectList(_context.Blog, "Id", "BlogBrief");
            return View();
        }

        // POST: BlogComments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,content,PostTime,LikeCount,ParentCommentId,FKApplicationUser,FKBlog")] BlogComment blogComment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(blogComment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FKApplicationUser"] = new SelectList(_context.Users, "Id", "Id", blogComment.FKApplicationUser);
            ViewData["FKBlog"] = new SelectList(_context.Blog, "Id", "BlogBrief", blogComment.FKBlog);
            return View(blogComment);
        }

        // GET: BlogComments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogComment = await _context.BlogComment.FindAsync(id);
            if (blogComment == null)
            {
                return NotFound();
            }
            ViewData["FKApplicationUser"] = new SelectList(_context.Users, "Id", "Id", blogComment.FKApplicationUser);
            ViewData["FKBlog"] = new SelectList(_context.Blog, "Id", "BlogBrief", blogComment.FKBlog);
            return View(blogComment);
        }

        // POST: BlogComments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,content,PostTime,LikeCount,FKParentComment,FKApplicationUser,FKBlog")] BlogComment blogComment)
        {
            if (id != blogComment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(blogComment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogCommentExists(blogComment.Id))
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
            ViewData["FKApplicationUser"] = new SelectList(_context.Users, "Id", "Id", blogComment.FKApplicationUser);
            ViewData["FKBlog"] = new SelectList(_context.Blog, "Id", "BlogBrief", blogComment.FKBlog);
            return View(blogComment);
        }

        // GET: BlogComments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogComment = await _context.BlogComment
                .Include(b => b.ApplicationUser)
                .Include(b => b.Blog)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blogComment == null)
            {
                return NotFound();
            }

            return View(blogComment);
        }

        // POST: BlogComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blogComment = await _context.BlogComment.FindAsync(id);
            _context.BlogComment.Remove(blogComment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BlogCommentExists(int id)
        {
            return _context.BlogComment.Any(e => e.Id == id);
        }
    }
}
