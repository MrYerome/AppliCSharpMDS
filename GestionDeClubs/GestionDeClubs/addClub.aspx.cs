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
      
        }


       protected void addClubAction(object sender, EventArgs e)
        {
            db = new ClubFootEntities();
            Club c = new Club();
            
            
            c.nom = clubName.Text;
            c.adresse = clubAddress.Text;
            c.ville = clubCity.Text;
            c.codePostal = Convert.ToInt32(clubZipcode.Text);
            db.Club.Add(c);
            db.SaveChanges();
       }
    }
}


