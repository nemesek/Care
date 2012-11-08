using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Ninject.Web.Common;
using Ninject;
using System.Reflection;
//using Ninject.Modules;
//using Care.Data.Concrete;

namespace Care
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    //public class MvcApplication : System.Web.HttpApplication
    //public class MvcApplication : NinjectHttpApplication
    //public class MvcApplication : System.Web.HttpApplication
    //{
    //    protected void Application_Start()
    //    {
    //        AreaRegistration.RegisterAllAreas();
    //        //IocConfig.RegisterIoc(GlobalConfiguration.Configuration);   
    //        ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());
    //        WebApiConfig.Register(GlobalConfiguration.Configuration);
    //        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
    //        RouteConfig.RegisterRoutes(RouteTable.Routes);
    //        BundleConfig.RegisterBundles(BundleTable.Bundles);
    //        AuthConfig.RegisterAuth();
    //    }
    //}

    public class MvcApplication : NinjectHttpApplication
    {
        protected override Ninject.IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly(),
                Assembly.Load("Care.Data"),
                Assembly.Load("Care.Model"),
                Assembly.Load("Care.Ioc"));
            return kernel;
        }

        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();
            AreaRegistration.RegisterAllAreas();
            //IocConfig.RegisterIoc(GlobalConfiguration.Configuration);   
            //ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
        }

        //public class EFBindingModule : NinjectModule
        //{
        //    public override void Load()
        //    {
        //        //Bind<IDataContext>().To<DataContext>().InRequestScope();
        //        //Bind<IArchivesRepository>().To<ArchivesRepository>().InRequestScope();
        //        //Bind<IMessagesRepository>().To<MessagesRepository>().InRequestScope();
        //        Bind<RepositoryFactories>().To<RepositoryFactories>().InSingletonScope();
        //        Bind<IRepositoryProvider>().To<RepositoryProvider>();
        //        Bind<ICareUow>().To<CareUow>().InRequestScope();
        //    }
        //}


    }
}