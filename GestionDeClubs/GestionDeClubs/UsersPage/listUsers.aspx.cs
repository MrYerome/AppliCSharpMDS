using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionDeClubs.UsersPage
{
    public partial class listUsers : System.Web.UI.Page
    {
        private ClubFootEntities db = new ClubFootEntities();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                GridViewUsers.DataSource = db.Users.ToList();
                GridViewUsers.DataBind();
            }


        }

        protected void updateUser(Object sender, EventArgs e)
        {

            Button btn = (Button)sender;
            string idText = btn.CommandArgument;
            int id = int.Parse(idText);
            db.Users.ToList();
            //Users u1 = db.Users.Where(u => u.id == id).FirstOrDefault();
            //db.Users.Where(u => u.id == id).Select(u => u).FirstOrDefault();
            Users userAModif = db.Users.FirstOrDefault(x => x.id == id);



        }
    }
}