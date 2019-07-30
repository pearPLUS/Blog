using MyBlog.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Models
{
    public class BlogComment
    {
        [Column("comment_id")]
        public int Id { get; set; }
        [Column("comment_content")]
        public string content { get; set; }

        [Column("comment_date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime PostTime { get; set; }

        [Column("comment_like_count")]
        [DefaultValue(0)]
        public int LikeCount { get; set; }

        
        public int FKParentComment { get; set; }

        [ForeignKey("BlogComment")]
        [DefaultValue(0)]
        public int? ParentCommentId { get; set; }
        public virtual BlogComment ParentComment { get; set; }

        public string ParentCommentName { get; set; }

        [Required]
        [ForeignKey("ApplicationUser")]
        public string FKApplicationUser { get; set; }
        public ApplicationUser ApplicationUser { get; set; }


        [ForeignKey("Blog")]
        public int? FKBlog { get; set; }
        public Blog Blog { get; set; }

        public virtual ICollection<BlogComment> ChildComment { get; set; }

    }
}
