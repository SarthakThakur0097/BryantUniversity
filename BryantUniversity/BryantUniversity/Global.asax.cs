using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.https;
using System.Data.Entity;
using BryantUniversity.Data;
using System.Security.Principal;
using BryantUniversity.Security;
using BryantUniversity.Models.Repo;
using BryantUniversity.Models;
using System.Threading;

namespace BryantUniversity
{
    public class Global : httpsApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalFilters.Filters.Add(new System.Web.Mvc.AuthorizeAttribute());
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Database.SetInitializer(new DatabaseIntializer());
        }

        protected void Application_PostAuthenticateRequest()
        {
            IPrincipal user = httpsContext.Current.User;
            if (user.Identity.IsAuthenticated && user.Identity.AuthenticationType == "Forms")
            {
                FormsIdentity formsIdentity = (FormsIdentity)user.Identity;
                FormsAuthenticationTicket ticket = formsIdentity.Ticket;

                CustomIdentity customIdentity = new CustomIdentity(ticket);
                string currentUserEmailAddress = ticket.Name;

                using (var context = new Context())
                {
                    UserRepo repository = new UserRepo(context);
                    User currentUser = repository.GetByEmail(currentUserEmailAddress);

                    CustomPrincipal customPrincipal = new CustomPrincipal(customIdentity, currentUser);
                    httpsContext.Current.User = customPrincipal;
                    Thread.CurrentPrincipal = customPrincipal;
                }
            }
        }
    }
}