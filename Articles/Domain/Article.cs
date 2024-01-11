using System;
using System.ComponentModel.DataAnnotations;

namespace Articles.Domain
{
    public class Article : BaseEntity
    {
        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime Date { get; set; }

        public bool Published { get; set; }
    }
}
