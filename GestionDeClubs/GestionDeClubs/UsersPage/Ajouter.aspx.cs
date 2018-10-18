using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionDeClubs.UsersPage
{
    public partial class Ajouter : Page
    {

        private ClubFootEntities db = new ClubFootEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { 
                GetDDLClubs();
        }
    }

        public void GetDDLClubs()
        {
            DDLClubs.DataSource = db.Club.ToList();
            DDLClubs.DataTextField = "nom";
            DDLClubs.DataValueField = "id";
            DDLClubs.DataBind();
        }
        protected void ValidateUser(object sender, EventArgs e)
        {
            try
            {
                db = new ClubFootEntities();
            Users u = new Users();
            u.nom = name.Text;
            u.prenom = surname.Text;
            u.id_Statut = 1;
            u.id_Club = int.Parse(DDLClubs.SelectedValue);
                u.poste = poste.Text;
            u.identifiant = identifiant.Text;
            u.password = password.Text;
            
            db.Users.Add(u);
            db.SaveChanges();
                messageValidateOK.InnerHtml = "<p>Le joueur a bien été créé</p></br><a href ='#'>redirection</a>";
                messageValidateOK.Attributes["class"] = "visible alert alert-success";


            }
            catch (Exception error)
            {
                messageValidateOK.InnerHtml = "Erreur au moment de la création du joueur";
                messageValidateOK.Attributes["class"] = "visible alert alert-success";
                Console.WriteLine(error.Message);

            }


        }
        
    }
}
