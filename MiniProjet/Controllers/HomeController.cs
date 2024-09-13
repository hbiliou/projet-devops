using nouhailaMiniProjet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace nouhailaMiniProjet.Controllers
{
    public class HomeController : Controller
    {

        private DESKTOP_9EJM882 db = new DESKTOP_9EJM882();

        // GET: Home
        public ActionResult Index()
        {
            var ads = db.Ads.ToList(); // Assuming dbContext is your database context
            ViewBag.Ads = ads;
            return View();
        }

    }
}