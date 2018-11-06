using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionDeClubs
{
    public partial class addClub : Page
    {

        private ClubFootEntities db = new ClubFootEntities();
        protected void Page_Load(object sender, EventArgs e)
        {

            Users user = (Users)Page.Session["userConnected"];

            if (user == null)
            {
                Response.RedirectToRoute("default");
            }
      
        }

        protected void messageValidation(bool status, string message)
        {
            if (status)
            {
                errorMessage.InnerText = message;
                errorMessage.Attributes["class"] = "alert alert-success alert-dismissible show";
            }
            else
            {
                errorMessage.InnerText = message;
                errorMessage.Attributes["class"] = "alert alert-danger alert-dismissible show";
            }
        }


        protected void addClubAction(object sender, EventArgs e)
        {
            db = new ClubFootEntities();
            Club c = new Club();

            try
            {
                //var query = db.Club.Where(club => club.nom == clubName.Text).First();
                var query = db.Club.Any(club => club.nom == clubName.Text);

                //System.Diagnostics.Debug.WriteLine(query);

                if(query == true)
                {
                    messageValidation(false, "Un club porte deja le meme nom");
                }
                else
                {
                    messageValidation(true, "Club ajoute avec succes");
                }
            }
            catch(Exception exc)
            {
                
            }


            //c.nom = clubName.Text;
            //c.adresse = clubAddress.Text;
            //c.ville = clubCity.Text;
            //c.codePostal = Convert.ToInt32(clubZipcode.Text);
            //db.Club.Add(c);
            //db.SaveChanges();
        }
    }
}


