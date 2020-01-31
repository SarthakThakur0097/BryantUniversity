using System.Security.Principal;
using System.Web.Security;

namespace BryantUniversity.Security
{
    public class CustomIdentity : IIdentity
    {
        private FormsAuthenticationTicket ticket;

        public CustomIdentity(FormsAuthenticationTicket ticket)
        {
            this.ticket = ticket;
        }

        public string AuthenticationType
        {
            get
            {
                return "Custom";
            }
        }

        public bool IsAuthenticated
        {
            get
            {
                return true;
            }
        }

        public string Name
        {
            get
            {
                return ticket.Name;
            }
        }
    }
}