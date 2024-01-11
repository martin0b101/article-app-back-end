using System;
using System.ComponentModel.DataAnnotations;

namespace Articles.Models
{
    public class ArticleModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime Date { get; set; }

        public bool Published { get; set; }
    }
}