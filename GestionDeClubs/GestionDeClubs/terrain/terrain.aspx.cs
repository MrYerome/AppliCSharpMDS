using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace GestionDeClubs.terrain
{
    public partial class terrain : Page
    {
        private ClubFootEntities entities = new ClubFootEntities();
        private Users userConnected = new Users();
        protected void Page_Load(object sender, EventArgs e)
        {
#if DEBUG
            Users user = entities.Users.FirstOrDefault(x => x.identifiant == "cgouin" && x.password == "password");
            Page.Session["userConnected"] = user;
#endif
            if (Page.Session["userConnected"] != null)
            {
                userConnected = (Users)Page.Session["userConnected"];
            }
            else
            {
                Response.Redirect("../Default");
            }
        }

        protected void addTerrainButton_Click(object sender, EventArgs e)
        {
            try
            {
                Terrain terrain = new Terrain();
                terrain.nom = nameTerrain.Text;
                terrain.adresse = addressTerrain.Text;
                terrain.Club = userConnected.Club;
                entities.Terrain.Add(terrain);
                saveChanges();
                nameTerrain.Text = "";
                addressTerrain.Text = "";
                messageValidate.InnerText = "Le terrain ajouté avec succès";
                messageValidate.Attributes["class"] = "visible alert alert-success";

            }
            catch (Exception)
            {
                messageValidate.InnerText = "Erreur: le terrain n'a pas été ajouté";
                messageValidate.Attributes["class"] = "visible alert alert-danger";
            }
        }

        protected void saveChanges()
        {
            entities.SaveChanges();
        }
    }
}