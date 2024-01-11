using System.Collections.Generic;

namespace Articles.Models
{
    public class CommentListModel
    {
        public IEnumerable<CommentModel> Comments { get; set; }
    }
}