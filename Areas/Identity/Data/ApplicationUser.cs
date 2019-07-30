using Microsoft.AspNetCore.Identity;
using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Areas.Identity.Data
{
    public class ApplicationUser : IdentityUser
    {
        [Column("user_name")]
        [Required]
        public string Name { get; set; }
        [Column("user_profile_photo")]
        public string ProfilePhoto { get; set; }

        [Column("user_regisration_time")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime RegistrationTime { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        [Column("user_birthday")]
        public DateTime Birthday { get; set; }
        [Column("user_age")]
        public int age { get; set; }

        [Column("article_count")]
        [DefaultValue(0)]
        public int ArticleCount { get; set; }

        public virtual ICollection<Blog> Blogs { get; set; }
        public virtual ICollection<BlogComment> Comments { get; set; }
    }
}
