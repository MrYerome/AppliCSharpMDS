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
        protected Terrain selectedTerrain;
        protected void Page_Load(object sender, EventArgs e)
        {
#if DEBUG
            Users user = entities.Users.FirstOrDefault(x => x.identifiant == "admin" && x.password == "admin");
            Page.Session["userConnected"] = user;
#endif
            if (Page.Session["userConnected"] != null)
            {
                userConnected = (Users)Page.Session["userConnected"];
                if (!IsPostBack)
                {
                    loadDatagrid();
                    
                }
            }
            else
            {
                Response.Redirect("../Default");
            }
        }

        /// <summary>
        /// Add a new terrain
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                emptyForm();
                messageValidation(true, "Le terrain ajouté avec succès");

            }
            catch (Exception)
            {
                messageValidation(false, "Erreur: le terrain n'a pas été ajouté");
            }
        }

        /// <summary>
        /// Load data in the gridview
        /// </summary>
        protected void loadDatagrid()
        {
            gridViewTerrain.DataSource = entities.Terrain.ToList();
            gridViewTerrain.DataBind();
        }

        protected void saveChanges()
        {
            entities.SaveChanges();
        }

        protected void emptyForm()
        {
            nameTerrain.Text = "";
            addressTerrain.Text = "";
        }

        protected void gridViewTerrain_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gridViewTerrain.SelectedRow;

            int selectedTerrainId = Convert.ToInt32(gridViewTerrain.DataKeys[row.RowIndex].Value.ToString());
            selectedTerrain = new Terrain();
            selectedTerrain = entities.Terrain.FirstOrDefault(t => t.id == selectedTerrainId);

            loadFormModif(selectedTerrain);
        }

        protected void loadFormModif(Terrain t)
        {
            idTerrain.Value = t.id.ToString();
            nameTerrain.Text = t.nom;
            addressTerrain.Text = t.adresse;
        }

        protected void modifTerrainButton_Click(object sender, EventArgs e)
        {
            try
            {
                int idSelectedTerrain = Convert.ToInt32(idTerrain.Value);

                selectedTerrain = entities.Terrain.FirstOrDefault(t => t.id == idSelectedTerrain);

                selectedTerrain.nom = nameTerrain.Text;
                selectedTerrain.adresse = addressTerrain.Text;

                saveChanges();
                emptyForm();

                messageValidation(true, "Le terrain modifié avec succès");
                loadDatagrid();
                selectedTerrain = null;
            }
            catch (Exception)
            {
                messageValidation(false, "Erreur: le terrain n'a pas été modifié");
                selectedTerrain = null;
            }

        }

        protected void suppTerrainButton_Click(object sender, EventArgs e)
        {
            try
            {
                int idSelectedTerrain = Convert.ToInt32(idTerrain.Value);
                selectedTerrain = entities.Terrain.FirstOrDefault(t => t.id == idSelectedTerrain);

                entities.Terrain.Remove(selectedTerrain);
                saveChanges();
                emptyForm();

                messageValidation(true, "Le terrain a été supprimé avec succès");

                loadDatagrid();
                selectedTerrain = null;
            }
            catch (Exception)
            {
                messageValidation(false, "Erreur : Le terrain n'a pas été modifié");
                    selectedTerrain = null;
            }
            
        }

       protected void messageValidation(bool status, string message)
        {
            if (status)
            {
                messageValidate.InnerText = message;
                messageValidate.Attributes["class"] = "alert alert-success alert-dismissible fade show";
            }
            else
            {
                messageValidate.InnerText = message;
                messageValidate.Attributes["class"] = "alert alert-danger alert-dismissible fade show";
            }
        }
    }
}