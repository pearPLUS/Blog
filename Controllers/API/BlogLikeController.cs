using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBlog.Data;
using MyBlog.Models;

namespace MyBlog.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogLikeController : ControllerBase
    {
        private ApplicationDbContext _context;

        public BlogLikeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get /api/bloglike
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<BlogLike>>> getRecords()
        {
            var blogLikes = await _context.BlogLike.ToListAsync();

            return Ok(blogLikes);
        }

        // POST /api/bloglike
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<BlogLike>> CreateBlogLike(BlogLike blogLike)
        {
            if (!ModelState.IsValid)
            {
                return NoContent();
            }

            var blog = await _context.Blog.FirstOrDefaultAsync(b => b.Id == blogLike.BlogId);
            if(blog == null)
            {
                return BadRequest();
            }
            blog.LikeCount++;

            _context.Update(blog);
            _context.Add(blogLike);
            await _context.SaveChangesAsync();
            return blogLike;
        }

        // GET /api/bloglike/blogId/userId
        [AllowAnonymous]
        [HttpGet("{blogId}/{userId}")]
        public async Task<ActionResult<BlogLike>> GetBlogLike(int blogId, String userId)
        {
            var blogLike = await _context.BlogLike.FirstOrDefaultAsync(b => b.BlogId == blogId && b.UserId == userId);

            return blogLike;
        }

        // GET /api/bloglike/id/status
        [AllowAnonymous]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStatus(int id, BlogLike blogLike)
        {
            if(id != blogLike.Id)
            {
                return BadRequest();
            }

            var blog = await _context.Blog.FirstOrDefaultAsync(b => b.Id == blogLike.BlogId);
            if (blog == null)
            {
                return BadRequest();
            }

            if(blogLike.Status == 1)
            {
                blog.LikeCount++;
            }
            else
            {
                blog.LikeCount--;
            }
            _context.Update(blog);
            _context.Entry(blogLike).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();


        }
    }
}