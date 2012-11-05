using Care.Web.Abstract;
using System;
using System.Web.Security;

namespace Care.Web.Concrete
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
