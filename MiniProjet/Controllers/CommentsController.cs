using nouhailaMiniProjet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace nouhailaMiniProjet.Controllers
{
    public class CommentsController : Controller
    {
        private DESKTOP_9EJM882 db = new DESKTOP_9EJM882();

        // GET: Comments
        public ActionResult Index(string searchString)
        {
            var comments = from p in db.Comments select p;

            if (!string.IsNullOrEmpty(searchString))
            {
                comments = comments.Where(p =>
                    p.Text.Contains(searchString) ||
                    p.AuthorName.Contains(searchString)
                );
            }

            return View(comments.ToList());
        }

    }
}