using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Models
{
    public class Catergory
    {
        [Column("catergory_id")]
        public int Id { get; set; }
        [Column("catergory_name")]
        [Required]
        [StringLength(10, MinimumLength =2)]
        public string Name { get; set; }
        [Column("catergory_description")]
        public string  Description { get; set; }

        public virtual ICollection<Blog> Blogs { get; set; }
    }
}
