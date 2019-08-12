using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Models
{
    public class BlogLike
    {
        [Column("bloglike_id")]
        public int Id { get; set; }

        [Column("blog_id")]
        [Required]
        public int BlogId { get; set; }

        [Column("user_id")]
        [Required]
        public string UserId { get; set; }


        // 0 means no like, 1 means like
        [Column("like_status")]
        [Required]
        [Range(0,1)]
        [DefaultValue(0)]
        public short Status { get; set; }
    }
}
