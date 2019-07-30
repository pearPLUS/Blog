using MyBlog.Data;
using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyBlog.Controllers
{
    public class Helper
    {
        private ApplicationDbContext _context;
        List<BlogComment> blogComments;
        public Helper(ApplicationDbContext context, List<BlogComment> blogComments)
        {
            _context = context;
            this.blogComments = blogComments;
            getChildComment(1002);
        }
        public BlogComment getChildComment(int CommentId)
        {

            var comment = _context.BlogComment
                .Include(c => c.ChildComment)
                .FirstOrDefault(c => c.Id == CommentId);

            if (comment.ChildComment.Count != 0)
            {
                foreach (var childComment in comment.ChildComment)
                {

                    var GrandChildComment = getChildComment(childComment.Id);
                    blogComments.Add(GrandChildComment);
                }
            }
            return comment;

        }
    }
}
