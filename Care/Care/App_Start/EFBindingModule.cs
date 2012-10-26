using Care.Domain.Abstract;
using Care.Data.Concrete;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Web.Common;
using Care.Data.Abstract;
using Care.Domain.Concrete;

namespace Care
{
    public class EFBindingModule : NinjectModule
    {
        public override void Load()
        {
            Bind<RepositoryFactories>().To<RepositoryFactories>().InSingletonScope();
            Bind<IRepositoryProvider>().To<RepositoryProvider>();
            Bind<ICareUow>().To<CareUow>().InRequestScope();
            Bind<ITestLogic>().To<SysrTestLogic>();
            Bind<IQuestionGenerator>().To<QuestionGenerator>();
            Bind<ITestService>().To<TestService>();
            Bind<IAuthentication>().To<FormsAuthenticate>();
        }
    }
}