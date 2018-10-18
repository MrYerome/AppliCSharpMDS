using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionDeClubs
{
    public partial class updateClub : System.Web.UI.Page

    {
        int idClub;
        public Club club;
        ClubFootEntities db = new ClubFootEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            
           
            if (Convert.ToInt32(Page.RouteData.Values["idClub"]) != 0)
            {
                idClub = Convert.ToInt32(Page.RouteData.Values["idClub"]);

                try
                {
                    
                    club = db.Club.FirstOrDefault(x => x.id == idClub);
                    if(club != null)
                    {
                        //!IsPostBack : Gets a value that indicates whether the page is being rendered for the first time or is being loaded in response to a postback.
                        //Obligatoire : Sinon la nouvelle valeur des champs n'est pas prise en compte
                        if (!IsPostBack)
                        {
                            clubName.Text = club.nom;
                            clubAddress.Text = club.adresse;
                            clubZipcode.Text = Convert.ToString(club.codePostal);
                            clubCity.Text = club.ville;
                        }
                    }
                    
                }
                catch (Exception exc)
                {
                    Console.WriteLine("Une erreur s'est produite", exc);

                }    
            }
           
        }

        protected void updateClubAction(object sender, EventArgs e)
        {
            
                club.nom = clubName.Text;
                club.adresse = clubAddress.Text;
                club.codePostal = Convert.ToInt32(clubZipcode.Text);
                club.ville = clubCity.Text;

                db.SaveChanges();
            

        }
    }
}