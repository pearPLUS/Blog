using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Models
{
    public class BlogDetailViewModel
    {
        public Blog blog { get; set; }
        public short? likeStatus { get; set; }
    }
}
