using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nouhailaMiniProjet.Models
{
    public class Ad
    {
        public int Id { get; set; } 
        public string Title { get; set; }
        public string Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public Category AdCategory { get; set; }
        public ICollection<Comment> Comments { get; set; }

    }

}