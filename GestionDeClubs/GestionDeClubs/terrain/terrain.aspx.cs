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
                    messageValidation(true, true, "Le terrain ajouté avec succès");
                }
                else
                {
                    messageValidation(true, false, "Erreur: un terrain existe déjà avec ce nom");
                }



            }
            catch (Exception)
            {
                messageValidation(true, false, "Erreur: le terrain n'a pas été ajouté");
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

            messageValidation(false);

            int selectedTerrainId = Convert.ToInt32(gridViewTerrain.DataKeys[row.RowIndex].Value.ToString());
            selectedTerrain = new Terrain();
            selectedTerrain = entities.Terrain.FirstOrDefault(t => t.id == selectedTerrainId);

            loadFormModif(selectedTerrain);
        }
        protected void gridViewTerrain_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (hasRight())
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

                    messageValidation(true, true, "Le terrain modifié avec succès");
                    loadDatagrid();
                    selectedTerrain = null;
                }
                else
                {
                    messageValidation(true, false, "Erreur: un terrain existe déjà avec ce nom");
                }
            }
            catch (Exception)
            {
                messageValidation(true, false, "Erreur: le terrain n'a pas été modifié");
               
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

                messageValidation(true, true, "Le terrain a été supprimé avec succès");

                loadDatagrid();
                selectedTerrain = null;
            }
            catch (Exception)
            {
                messageValidation(true, false, "Erreur : Le terrain n'a pas été modifié");

            }
            
        }

       protected void messageValidation(bool isShow, bool status = true, string message = "")
        {
            if (isShow)
            {
                if (status)
                {
                    messageValidate.InnerText = message;
                    ContainerMessageValidate.Attributes["class"] = "alert alert-success alert-dismissible show";
                }
                else
                {
                    messageValidate.InnerText = message;
                    ContainerMessageValidate.Attributes["class"] = "alert alert-danger alert-dismissible show";
                }
            }
            else
            {
                ContainerMessageValidate.Attributes["class"] = "hide";
            }

        }

        protected Boolean isNameTerrainAlreadyExist(String nom)
        {
            Terrain terrain = entities.Terrain.FirstOrDefault(t => t.nom == nom);
            return terrain != null;
            
        }

        protected void showGestion()
        {
            if(hasRight())
            {
                gestionTerrain.Style.Add("Display", "auto");
            }
            else
            {
                gestionTerrain.Style.Add("Display", "none");
            }
        }

        protected Boolean hasRight()
        {
            return (userConnected.id_Statut == 1 || userConnected.id_Statut == 2);
        }

    }
}