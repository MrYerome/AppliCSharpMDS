using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace GestionDeClubs
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Permanent;
            routes.EnableFriendlyUrls(settings);

            routes.MapPageRoute("default", "default", "~/Default.aspx");

            /* ROUTE UPDATECLUB */
            routes.MapPageRoute("updateClub",
            "majClub/{idClub}",
            "~/updateClub.aspx");




        }
    }
}
