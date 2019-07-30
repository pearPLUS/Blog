using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Web;
using MyBlog.Data;

namespace MyBlog.Controllers
{
    public class ApplicationBasedController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ApplicationBasedController(ApplicationDbContext context)
        {
            _context = context;
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if(User != null)
            {
                var username = User.Identity.Name;

                if (!string.IsNullOrEmpty(username))
                {
                    var user = _context.Users.SingleOrDefault(u => u.UserName == username);
                    int articleCount = user.ArticleCount;
                    ViewData.Add("articleCount", articleCount);
                    var useId = user.Id;
                    ViewData.Add("userId", useId);
                }
            }
            base.OnActionExecuted(filterContext);
        }
    }
}