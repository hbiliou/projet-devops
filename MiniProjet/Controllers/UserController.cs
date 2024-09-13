using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using nouhailaMiniProjet.Models;
using System.Net;
using System.Data.Entity;
using Microsoft.Owin.Security;

namespace nouhailaMiniProjet.Controllers
{
    public class UserController : Controller
    {
        private UserManager<IdentityUser> _userManager;
        private DESKTOP_9EJM882 db = new DESKTOP_9EJM882();

        public UserController()
        {
            var userStore = new UserStore<IdentityUser>(db);
            _userManager = new UserManager<IdentityUser>(userStore);
        }
        // GET: User
        public ActionResult Index()
        {
            var users = _userManager.Users.ToList();
            return View(users);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string userName, string email, string password)
        {
            var user = new IdentityUser
            {
                UserName = userName,
                Email = email
            };

            // Customize password policy if needed
            // userManager.PasswordValidator = new PasswordValidator
            // {
            //    RequiredLength = 6,
            //    RequireNonLetterOrDigit = true,
            //    RequireDigit = true,
            //    RequireLowercase = true,
            //    RequireUppercase = true,
            // };

            IdentityResult result = _userManager.Create(user, password);

            if (result.Succeeded)
            {
                return RedirectToAction("Index"); // Redirect to Index action

            }
            else
            {
                ViewBag.Message = "Error adding user to database";
            }

            return View();
        }
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            IdentityUser user = _userManager.FindById(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, string userName, string email, string password)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            IdentityUser user = _userManager.FindById(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            // Update other properties
            user.UserName = userName;
            user.Email = email;

            // Update password if a new password is provided
            if (!string.IsNullOrEmpty(password))
            {
                var newPasswordHash = _userManager.PasswordHasher.HashPassword(password);
                user.PasswordHash = newPasswordHash;
            }

            IdentityResult result = _userManager.Update(user);

            if (result.Succeeded)
            {
                // Ensure the user is reloaded after the update
                user = _userManager.FindById(id);

                // Sign in again with the updated user
                var authenticationManager = HttpContext.GetOwinContext().Authentication;
                var userIdentity = _userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, userIdentity);

                return RedirectToAction("Index");
            }

            return View(user);
        }


        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            IdentityUser user = _userManager.FindById(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            IdentityUser user = _userManager.FindById(id);
            _userManager.Delete(user);
            return RedirectToAction("Index");
        }

    }
}