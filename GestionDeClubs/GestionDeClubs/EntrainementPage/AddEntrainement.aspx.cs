using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionDeClubs.EntrainementPage
{
    public partial class AddEntrainement : System.Web.UI.Page
    {
        private ClubFootEntities db = new ClubFootEntities();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ValidateEntrainement(object sender, EventArgs e)
        {
            db = new ClubFootEntities();
            Entrainement en = new Entrainement();
            en.type = typeentrainement.Text;
            string date = dateentrainement.Text;
            string heure = heureentrainement.Text;
            string dateHeureMatch = date + " " + heure;
            en.date = Convert.ToDateTime(dateHeureMatch);
            db.Entrainement.Add(en); //ajout dans la table Matchs
            db.SaveChanges();
        }
    }
}