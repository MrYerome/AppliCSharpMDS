using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionDeClubs
{
    public class Util
    {
        public static int SendByMail(string csMailDestinataire, string objetMessage, string subject)
        {
            System.Net.Mail.MailMessage oMsg = new System.Net.Mail.MailMessage();

            oMsg.From = new System.Net.Mail.MailAddress("jerome.vinet@yahoo.fr");

            oMsg.Subject = subject;
            oMsg.To.Add(csMailDestinataire);
            oMsg.Body = objetMessage;
            oMsg.IsBodyHtml = true;

            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = "smtp.mail.yahoo.com";
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("jerome.vinet@yahoo.fr", "marite52");
            client.Timeout = 5000;

            try
            {
                client.Send(oMsg);
                System.Diagnostics.Debug.WriteLine("mail envoyé avec succès");
                return 1;
            }
            catch (SmtpFailedRecipientsException ex)
            {
                for (int i = 0; i < ex.InnerExceptions.Length; i++)
                {
                    SmtpStatusCode status = ex.InnerExceptions[i].StatusCode;
                    System.Diagnostics.Debug.WriteLine(status);

                    if (status == SmtpStatusCode.MailboxBusy ||
                        status == SmtpStatusCode.MailboxUnavailable)
                    {
                        Console.WriteLine("Delivery failed - retrying in 5 seconds.");
                        System.Threading.Thread.Sleep(5000);
                        client.Send(oMsg);
                        return 0;
                    }
                    else
                    {
                        Console.WriteLine("Failed to deliver message to {0}",
                            ex.InnerExceptions[i].FailedRecipient);
                        return 0;
                    } 
                }
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in RetryIfBusy(): {0}",
                        ex.ToString());
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                return 0;
            }

        }

        /// <summary>
        /// Show or hide the validation message
        /// <para>-> isShow : True pour afficher l'alerte, false pour la cacher.</para>
        /// <para>-> spanMessage : Id du span devant contenir le message.</para>
        /// <para>-> divContainer : Id de la div contenant la span du message et qui aura le css.</para>
        /// <para>-> status : True pour OK (alerte verte), false pour KO (alerte rouge).</para>
        /// <para>-> message : Message à afficher.</para>
        /// </summary>
        /// <param name="isShow">param to say if the alert must be show</param>
        /// <param name="spanMessage">Span devant contenir le message</param>
        /// <param name="divContainer">div contenant la span et qui aura le css</param>
        /// <param name="status">statut of the alert true for OK and false for KO</param>
        /// <param name="message">string of the message </param>
        public static void alerteMessage(bool isShow, System.Web.UI.HtmlControls.HtmlGenericControl spanMessage, System.Web.UI.HtmlControls.HtmlGenericControl divContainer, bool status = true, string message = "" )
        {
            if (isShow)
            {
                if (status)
                {
                    spanMessage.InnerHtml = message;
                    divContainer.Attributes["class"] = "alert alert-success alert-dismissible show";
                }
                else
                {
                    spanMessage.InnerHtml = message;
                    divContainer.Attributes["class"] = "alert alert-danger alert-dismissible show";
                }
            }
            else
            {
                divContainer.Attributes["class"] = "hide";
            }

        }

        /// <summary>
        /// Tester le statut d'un utilisateur selon un seul statut
        /// </summary>
        /// <param name="statutId"></param>
        /// <param name="u"></param>
        /// <returns>Boolean</returns>
        public static Boolean isStatut(int statutId, Users u)
        {
            return (u.id_Statut == statutId);
        }

        /// <summary>
        /// Tester le statut d'un utilisateur selon une liste de statut
        /// <para>exemple : Util.hasRight(new List<int>() { 1, 2 }, userConnected )</para>
        /// </summary>
        /// <param name="statutsId"></param>
        /// <param name="u"></param>
        /// <returns>Boolean</returns>
        public static Boolean isStatut(List<int> statutsId, Users u)
        {
            return statutsId.Contains(u.id_Statut);
        }
        
        /// <summary>
        /// Vérifier que l'utilisateur fourni est différent de null
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public static Boolean isConnected(Users users)
        {
            return (users != null);
        }
    }

    
}