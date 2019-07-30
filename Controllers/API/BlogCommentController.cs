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
    public class BlogCommentController : ControllerBase
    {
        private ApplicationDbContext _context;
        private List<BlogComment> ChildComments;


        public BlogCommentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get /api/blogComment
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<BlogComment>>> GetBlogComments()
        {
            var blogComments = await _context.BlogComment.ToListAsync();


            return Ok(blogComments);

        }

        // Get /api/blogComment/1
        [AllowAnonymous]
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<BlogComment>> getCommentDetail(int id)
        {
            ChildComments = new List<BlogComment>();
            getChildComment(id);
            return Ok(ChildComments);
        }

        // POST /api/blogComment
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<BlogComment>> CreateComment( BlogComment blogComment)
        {
            blogComment.PostTime = DateTime.Now.Date;
            if (!ModelState.IsValid)
            {
                return NoContent();
            }
           
            _context.Add(blogComment);
            await _context.SaveChangesAsync();

            return blogComment;

            
        }



        // use to get chilidComments 
        public BlogComment getChildComment(int CommentId)
        {

            var comment = _context.BlogComment
                .Include(c => c.ChildComment)
                .Include(c => c.ApplicationUser)
                .Include(c => c.ParentComment)
                .ThenInclude(pc => pc.ApplicationUser)
                .FirstOrDefault(c => c.Id == CommentId);

            // store the each comment to collection first 
            // then keep searching 
            ChildComments.Add(comment);
            if (comment.ChildComment.Count != 0)
            {
                foreach (var childComment in comment.ChildComment)
                {

                    var GrandChildComment = getChildComment(childComment.Id);
                    
                }
            }

            // in order to clean the childComment set for client end]
            if(comment.ParentComment != null)
            {
                comment.ParentCommentName = comment.ParentComment.ApplicationUser.UserName;

            }


            // clean the parentComment and childComment after using 
            // avoid large json data pass
            comment.ParentComment = null;
            comment.ChildComment = null;
            if(comment.ApplicationUser != null)
            {
                comment.ApplicationUser.Comments = null;
            }
            
            return comment;

        }

    }
}