using Care.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace Care.Domain.Concrete
{
    public class FormsAuthenticate : IAuthentication
    {
        public virtual void AuthenticateForms(String user, bool rememberMe)
        {
            FormsAuthentication.SetAuthCookie(user, rememberMe);
        }

        public virtual void LogOff()
        {
            FormsAuthentication.SignOut();
        }

    }
}
