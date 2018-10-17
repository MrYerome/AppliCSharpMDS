using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionDeClubs
{
    public partial class updateClub : System.Web.UI.Page

    {
        int idClub;
        public string test = "coucou";
        protected void Page_Load(object sender, EventArgs e)
        {
            idClub = Convert.ToInt32(Page.RouteData.Values["idClub"]);
        }

        protected void loadClub()
        {
            ClubFootEntities db = new ClubFootEntities();

            Club club = new Club();



        }

        protected void updateClubAction(object sender, EventArgs e)
        {

        }
    }
}