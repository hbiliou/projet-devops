using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nouhailaMiniProjet.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public Ad RelatedAd { get; set; }
        public string AuthorName { get; set; } // New property

    }

}