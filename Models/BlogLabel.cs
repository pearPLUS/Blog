using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Models
{

    public class BlogLabel
    {
        [Key, Column(Order = 0)]
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
        [Key, Column(Order = 1)]
        public int LabelId { get; set; }
        public label Label { get; set; }
    }
}
