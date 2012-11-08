using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Domain.Abstract
{
    public interface IAuthentication
    {
        void AuthenticateForms(String user, bool rememberMe);
        void LogOff();
    }
}
