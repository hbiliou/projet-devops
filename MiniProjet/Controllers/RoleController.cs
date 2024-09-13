using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;
using System.Web.Mvc;
using nouhailaMiniProjet.Models;
using System.Net;
using System.Data.Entity;

namespace nouhailaMiniProjet.Controllers
{
    public class RoleController : Controller
    {
        private RoleManager<IdentityRole> _roleManager;
        private DESKTOP_9EJM882 db = new DESKTOP_9EJM882();

        public RoleController()
        {
            var roleStore = new RoleStore<IdentityRole>(db);
            _roleManager = new RoleManager<IdentityRole>(roleStore);
        }

        // GET: Role
        public ActionResult Index()
        {
            var roles = _roleManager.Roles.ToList();
            return View(roles);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string roleName)
        {
            if (ModelState.IsValid)
            {
                var role = new IdentityRole
                {
                    Name = roleName
                };

                IdentityResult result = _roleManager.Create(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Message = "Error adding role to database";
                }
            }
            // If ModelState is not valid, handle accordingly
            return View();
        }


        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            IdentityRole role = _roleManager.FindById(id);

            if (role == null)
            {
                return HttpNotFound();
            }

            return View(role);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] IdentityRole role)
        {
            if (ModelState.IsValid)
            {
                // Detach the existing role from the context
                db.Entry(role).State = EntityState.Detached;

                // Attach the modified role
                db.Entry(role).State = EntityState.Modified;

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(role);
        }

        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            IdentityRole role = _roleManager.FindById(id);

            if (role == null)
            {
                return HttpNotFound();
            }

            return View(role);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            IdentityRole role = _roleManager.FindById(id);
            _roleManager.Delete(role);
            return RedirectToAction("Index");
        }

    }
}
