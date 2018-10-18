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

        protected void gridViewTerrain_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridViewTerrain.EditIndex = e.NewEditIndex;
            loadDatagrid();

        }

        protected void gridViewTerrain_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridViewTerrain.EditIndex = -1;
            loadDatagrid();
        }

        protected void gridViewTerrain_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int terrainId = Convert.ToInt32(gridViewTerrain.DataKeys[e.RowIndex].Value.ToString());
            GridViewRow row = (GridViewRow)gridViewTerrain.Rows[e.RowIndex];

            TextBox textName = (TextBox)row.Cells[0].Controls[0];
            TextBox textadd = (TextBox)row.Cells[1].Controls[0];

            Terrain terrain = entities.Terrain.FirstOrDefault(x => x.id == terrainId);
            if(terrain != null)
            {
                terrain.nom = textName.Text;
                terrain.adresse = textadd.Text;
                try
                {
                    saveChanges();
                    messageValidate.InnerText = "Terrain modifié avec succès";
                    messageValidate.Attributes["class"] = "visible alert alert-success";
                }
                catch (Exception)
                {
                    messageValidate.InnerText = "Erreur: le terrain n'a pas été modifié";
                    messageValidate.Attributes["class"] = "visible alert alert-danger";
                }
            }
            

            gridViewTerrain.EditIndex = -1;

            loadDatagrid();
        }
    }
}