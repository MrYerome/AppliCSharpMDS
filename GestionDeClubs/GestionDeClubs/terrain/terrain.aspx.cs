using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace GestionDeClubs.terrain
{
    public partial class addTerrain : Page
    {
        private ClubFootEntities entities = new ClubFootEntities();
        private Users userConnected = new Users();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Page.Session["userConnected"] != null)
            {
                userConnected = (Users)Page.Session["userConnected"];
            }
        }

        protected void addTerrain_Click(object sender, EventArgs e)
        {
            Terrain terrain = new Terrain();
            

        }
    }
}