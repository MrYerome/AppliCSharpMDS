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
        protected void Page_Load(object sender, EventArgs e)
        {
            
            List<Club> clubs = entities.Club.ToList();
            _dropDownListClub.DataSource = clubs;
            _dropDownListClub.DataValueField = "id";
            _dropDownListClub.DataTextField = "nom";
            _dropDownListClub.DataBind();
                
        }
    }
}