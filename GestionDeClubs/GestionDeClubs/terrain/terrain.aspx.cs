using System;
using System.Collections.Generic;
using System.Drawing;
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
                showGestion();
                if (!IsPostBack)
                {
                    loadDatagrid();
                    
                }
            }
            else
            {
                Response.Redirect("../connexion/connexion");
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

                if(!isNameTerrainAlreadyExist(nameTerrain.Text))
                {
                    Terrain terrain = new Terrain();
                    terrain.nom = nameTerrain.Text;
                    terrain.adresse = addressTerrain.Text;
                    terrain.Club = userConnected.Club;
                    entities.Terrain.Add(terrain);
                    saveChanges();
                    emptyForm();
                    loadDatagrid();
                    Util.alerteMessage(true, messageValidate, ContainerMessageValidate, true, "Le terrain ajouté avec succès");
                }
                else
                {
                    Util.alerteMessage(true, messageValidate, ContainerMessageValidate, false, "Erreur: un terrain existe déjà avec ce nom");
                }



            }
            catch (Exception)
            {
                Util.alerteMessage(true, messageValidate, ContainerMessageValidate, false, "Erreur: le terrain n'a pas été ajouté");
            }
        }

        /// <summary>
        /// Load data into the gridview
        /// </summary>
        protected void loadDatagrid()
        {
            gridViewTerrain.DataSource = entities.Terrain.ToList();
            gridViewTerrain.DataBind();
        }

        /// <summary>
        /// Save changes into the database
        /// </summary>
        protected void saveChanges()
        {
            entities.SaveChanges();
        }

        /// <summary>
        /// Empty the terrain form
        /// </summary>
        protected void emptyForm()
        {
            nameTerrain.Text = "";
            addressTerrain.Text = "";
            
        }

        /// <summary>
        /// On selected button get the row index and search the terrain in database to load form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridViewTerrain_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gridViewTerrain.SelectedRow;

            foreach (GridViewRow row1 in gridViewTerrain.Rows)
            {
                if (row1 == row)
                {
                    row1.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                    row1.ToolTip = string.Empty;
                }
                else
                {
                    row1.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    row1.ToolTip = "Cliquer pour selectionner le terrain";
                }
            }

            Util.alerteMessage(false, messageValidate, ContainerMessageValidate);

            int selectedTerrainId = Convert.ToInt32(gridViewTerrain.DataKeys[row.RowIndex].Value.ToString());
            selectedTerrain = new Terrain();
            selectedTerrain = entities.Terrain.FirstOrDefault(t => t.id == selectedTerrainId);

            loadFormModif(selectedTerrain);
        }

        /// <summary>
        /// Set the row click and tooltip
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridViewTerrain_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (Util.hasRight(new List<int>() { 1, 2 }, userConnected ))
                {
                    
                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gridViewTerrain, "Select$" + e.Row.RowIndex);
                    e.Row.ToolTip = "Cliquer pour selectionner le terrain";

                }
            }
        }

        /// <summary>
        /// load the form with the information of the selected terrain
        /// </summary>
        /// <param name="t"></param>
        protected void loadFormModif(Terrain t)
        {
            idTerrain.Value = t.id.ToString();
            nameTerrain.Text = t.nom;
            addressTerrain.Text = t.adresse;
        }

        /// <summary>
        /// Save changes of the selected terrain
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void modifTerrainButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!isNameTerrainAlreadyExist(nameTerrain.Text))
                {

                    int idSelectedTerrain = Convert.ToInt32(idTerrain.Value);

                    selectedTerrain = entities.Terrain.FirstOrDefault(t => t.id == idSelectedTerrain);

                    selectedTerrain.nom = nameTerrain.Text;
                    selectedTerrain.adresse = addressTerrain.Text;

                    saveChanges();
                    emptyForm();

                    Util.alerteMessage(true, messageValidate, ContainerMessageValidate, true, "Le terrain modifié avec succès");
                    loadDatagrid();
                    selectedTerrain = null;
                }
                else
                {
                    Util.alerteMessage(true, messageValidate, ContainerMessageValidate, false, "Erreur: un terrain existe déjà avec ce nom");
                }
            }
            catch (Exception)
            {
                Util.alerteMessage(true, messageValidate, ContainerMessageValidate, false, "Erreur: le terrain n'a pas été modifié");
               
            }

        }

        /// <summary>
        /// Delete the selected terrain
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void suppTerrainButton_Click(object sender, EventArgs e)
        {
            try
            {
                int idSelectedTerrain = Convert.ToInt32(idTerrain.Value);
                selectedTerrain = entities.Terrain.FirstOrDefault(t => t.id == idSelectedTerrain);

                entities.Terrain.Remove(selectedTerrain);
                saveChanges();
                emptyForm();

                Util.alerteMessage(true, messageValidate, ContainerMessageValidate, true, "Le terrain a été supprimé avec succès");

                loadDatagrid();
                selectedTerrain = null;
            }
            catch (Exception)
            {
                Util.alerteMessage(true, messageValidate, ContainerMessageValidate, false, "Erreur : Le terrain n'a pas été modifié");

            }
            
        }


        /// <summary>
        /// Check if a terrain already exist with this name
        /// </summary>
        /// <param name="nom"></param>
        /// <returns></returns>
        protected Boolean isNameTerrainAlreadyExist(String nom)
        {
            Terrain terrain = entities.Terrain.FirstOrDefault(t => t.nom == nom);
            return terrain != null;
            
        }

        /// <summary>
        /// Show the gestion div if the user is a Dirigeant or admin
        /// </summary>
        protected void showGestion()
        {
            if(Util.hasRight(new List<int>() { 1, 2 }, userConnected))
            {
                gestionTerrain.Style.Add("Display", "auto");
            }
        }


    }
}