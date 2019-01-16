using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModelCommon.Model
{
    public class CustomPrincipal : IPrincipal
    {
        public IIdentity Identity { get; private set; }
        public bool IsInRole(string role)
        {
            if (roles > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public CustomPrincipal(string Username)
        {
            this.Identity = new GenericIdentity(Username);
        }

        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public int roles { get; set; }
        public string Avatar { get; set; }
    }
    public class CustomPrincipalSerializeModel
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public int roles { get; set; }
        public string Avatar { get; set; }

    }
}
