using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace nouhailaMiniProjet.Models
{
    public class DESKTOP_9EJM882 : IdentityDbContext<IdentityUser>
    {
        public DESKTOP_9EJM882() : base("name=MyDbConnection")
        {

        }
        public DbSet<Ad> Ads { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }

    }
}