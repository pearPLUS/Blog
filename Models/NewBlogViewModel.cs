using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Models
{
    public class NewBlogViewModel
    {
        public Blog Blog { get; set; }
        public IEnumerable<Catergory> Catergories { get; set; }

        public IEnumerable<label> labels { get; set; }
        public string LabelStr { get; set; }
    }
}
