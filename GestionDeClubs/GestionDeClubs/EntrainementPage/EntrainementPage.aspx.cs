using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionDeClubs.EntrainementPage
{
    public partial class EntrainementPage : System.Web.UI.Page
    {
        protected ClubFootEntities entities = new ClubFootEntities();
        private Users userConnected = new Users();
        protected Entrainement selectedEntrainment;

        protected void Page_Load(object sender, EventArgs e)
        {
#if DEBUG
            Users user = entities.Users.FirstOrDefault(x => x.identifiant == "admin" && x.password == "admin");
            Page.Session["userConnected"] = user;
#endif
            if (Util.isConnected((Users)Page.Session["userConnected"]))
            {
                userConnected = (Users)Page.Session["userConnected"];
                if (!IsPostBack)
                {
                    loadTerrainList();
                }
            }
            else
            {
                Response.Redirect("../connexion/connexion");
            }

        }

        protected void loadTerrainList()
        {
            ListTerrainEntrainement.DataSource = entities.Terrain.Where(t => t.id_Club == userConnected.id_Club).ToList();
            ListTerrainEntrainement.DataBind();
        }

        protected void addEntrainement_Click(object sender, EventArgs e)
        {
            Entrainement entrainement = new Entrainement();
            entrainement.type = typeEntrainement.Text;
            entrainement.date = Convert.ToDateTime(dateEntrainement.Text+" "+heureEntrainement.Text);
            entities.Entrainement.Add(entrainement);


            EntrainementClubTerrain entrainementClubTerrain = new EntrainementClubTerrain();
            entrainementClubTerrain.Club = userConnected.Club;
            entrainementClubTerrain.Entrainement = entrainement;
            entrainementClubTerrain.id_Terrain = Int32.Parse(ListTerrainEntrainement.SelectedValue);
            entities.EntrainementClubTerrain.Add(entrainementClubTerrain);

            entities.SaveChanges();




        }
    }
}