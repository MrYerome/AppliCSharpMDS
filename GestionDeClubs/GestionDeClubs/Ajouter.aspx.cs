using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionDeClubs
{
    public partial class Contact : Page
    {
         
        private ClubFootEntities db = new ClubFootEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            GetDDLClubs();
        }

        public List<DropDownList> GetDDLClubs() {
            ClubFootEntities context = new ClubFootEntities();

            List<DropDownList> DDLClubs = new List<DropDownList>();
            var obj = context.Club.Select(c => c.nom).ToList();
            if (obj != null && obj.Count() > 0)
            {
                foreach (var data in obj)
                {
                    DropDownList model = new DropDownList();
                    result.Add(model);

                }
                return DDLClubs;
            }
            else return null;
        }
        protected void ValidateUser(object sender, EventArgs e)
        {
            db = new ClubFootEntities();
            Users u = new Users();
            u.id_Club = 1;
            u.id_Statut = 1;
            u.identifiant = identifiant.Text;
            u.password = password.Text;
            db.Users.Add(u);
            db.SaveChanges();
            }
        }


    }
