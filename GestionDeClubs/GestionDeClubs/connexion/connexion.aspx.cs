using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionDeClubs.connexion
{
    public partial class connexion : System.Web.UI.Page
    {
        private ClubFootEntities entities = new ClubFootEntities();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected Boolean isValidUser(string login, string password)
        {
            Users user = entities.Users.FirstOrDefault(x => x.identifiant == login && x.password == password);

            bool result;

            if(user is Users)
            {
                 result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }

        protected void validateConnexion_Click(object sender, EventArgs e)
        {

            if(isValidUser(login.Text, password.Text))
            {
                Users user = entities.Users.FirstOrDefault(x => x.identifiant == login.Text && x.password == password.Text);
                Page.Session["userConnected"] = user;
                Response.Redirect("../Default");
            }
        }
    }
}