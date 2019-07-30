using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Models
{
    public class label
    {
        [Column("label_id")]
        public int Id { get; set; }
        [Required]
        [Column("label_name")]
        public string Name { get; set; }
        [Required]
        [Column("label_description")]
        public string Description { get; set; }

        public virtual ICollection<BlogLabel> BlogLabels { get; set; }
    }
}
