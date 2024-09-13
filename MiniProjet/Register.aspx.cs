using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using nouhailaMiniProjet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace nouhailaMiniProjet
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Bt2_Click(object sender, EventArgs e)
        {
            var dbcontext = new DESKTOP_9EJM882();
            var UserStore = new UserStore<IdentityUser>(dbcontext);
            var manager = new UserManager<IdentityUser>(UserStore);

            var user = new IdentityUser(UserName.Text);

            IdentityResult resultat = manager.Create(user, Password.Text);

            if (resultat.Succeeded)
            {
                var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                var userIdentity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authenticationManager.SignIn(new AuthenticationProperties() { }, userIdentity);
                Response.Redirect("~/Login.aspx");
                Msg.Text = string.Format("Utilisateur {0} crée avec succès", user.UserName);
            }
            else
            {
                Msg.Text = "Erreur de création: ";
                foreach (var error in resultat.Errors)
                {
                    Msg.Text += error + "<br />";
                }
            }

        }
    }
}