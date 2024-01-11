using System;
using System.ComponentModel.DataAnnotations;

namespace Articles.Domain
{
    public class Comment : BaseEntity
    {
        public int? ArticleId { get; set; }

        public virtual Article Article { get; set; }

        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime Date { get; set; }

        public bool Published { get; set; }
    }
}
