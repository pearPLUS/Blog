using Microsoft.AspNetCore.Identity;
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
    public class Blog
    {
        [Column("blog_id")]
        public int Id { get; set; }
        [Required]

        [ForeignKey("Catergory")]
        public int FkCatergory { get; set; }
        public Catergory Catergory { get; set; }

        [Required]
        [Column("blog_title")]
        public string BlogTitle { get; set; }

        [Required]
        [Column("blog_brief")]
        public string BlogBrief { get; set; }

        [Required]
        [Column("blog_content")]
        public string BlogContent { get; set; }


        [Column("blog_date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime PostTime { get; set; }


        [Column("blog_like_count")]
        [DefaultValue(0)]
        public int LikeCount { get; set; }

        [Column("blog_comment_count")]
        public int CommentCount { get; set; }

        [Column("blog_views")]
        public int BrowseCount { get; set; }
        [Required]
        [ForeignKey("ApplicationUser")]
        public string FKApplicationUser { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public virtual ICollection<BlogComment> Comments { get; set; }

        public virtual ICollection<BlogLabel> LabelsBlogs { get; set; }
    }
}

