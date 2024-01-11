using System.Collections.Generic;

namespace Articles.Models
{
    public class ArticleListModel
    {
        public IEnumerable<ArticleModel> Articles { get; set; }
    }
}