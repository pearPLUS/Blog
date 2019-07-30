using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Models
{
    public class IndexBlogViewModel
    {
        public IEnumerable<Blog> Blogs { get; set; }

        public IEnumerable<label> Labels { get; set; }
    }
}
