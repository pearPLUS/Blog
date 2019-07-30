using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Models
{
    public class Post
    {
        [Column("post_id")]
        public int Id { get; set; }

        [Column("post_date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime PostTime { get; set; }
        [Column("post_like_count")]
        [DefaultValue(0)]
        public int LikeCount { get; set; }

        [Column("post_comment_count")]
        public int CommentCount { get; set; }

        [Required]
        [Column("post_content")]
        public string BlogContent { get; set; }

    }
}
