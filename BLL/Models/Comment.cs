using System;
using System.Collections.Generic;

namespace Blog.Models
{
    public partial class Comment
    {
        public int CommentID { get; set; }
        public string CommentAuthor { get; set; }
        public System.DateTime CreateDate { get; set; }
        public string CommentContents { get; set; }
        public Nullable<int> ParentCommentID { get; set; }
        public Nullable<int> CommentAuthorId { get; set; }
    }
}
