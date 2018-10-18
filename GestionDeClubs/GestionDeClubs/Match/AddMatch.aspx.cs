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
    public partial class Match : Page
    {

        private ClubFootEntities db = new ClubFootEntities();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ValidateMatch(object sender, EventArgs e)
        {
            db = new ClubFootEntities();
            Matchs m = new Matchs();
            string date = datematch.Text;
            string heure = heurematch.Text;
            string dateHeureMatch = date + " " + heure;
            m.date = Convert.ToDateTime(dateHeureMatch);
            db.Matchs.Add(m); //ajout dans la table Matchs
            db.SaveChanges();
        }
    }


}
