using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionDeClubs
{
    public partial class readClub : System.Web.UI.Page

    {

        ClubFootEntities db = new ClubFootEntities();

        
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridViewClub.DataSource = db.Club.ToList();
                GridViewClub.DataBind();
            }
        }

        protected void doNothing(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("do nothing");
        }

        public void SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        public void redirectToEdit(object sender, EventArgs e)
        {

            //Get the button that raised the event
            Button btn = (Button)sender;

            //Get the row that contains this button
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;

            //System.Diagnostics.Debug.WriteLine(gvr);

            int id = Convert.ToInt32(GridViewClub.DataKeys[gvr.DataItemIndex].Value);


            Response.RedirectToRoute("updateClub", new { idClub = id});



        }


    }



}