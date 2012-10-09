using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using Care.Data.Abstract;
using Care.Data.Concrete;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject.Web.Common;

namespace Care
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;

        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            //return base.GetControllerInstance(requestContext, controllerType);
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }



        private void AddBindings()
        {
            //put additional bindings here
            //Mock implementation of the IProductRepository Interface
            //Mock<IProductRepository> mock = new Mock<IProductRepository>();
            //mock.Setup(m => m.Products).Returns(new List<Product>{
            //    new Product {Name = "Football", Price = 25},
            //    new Product {Name = "Surf board", Price = 179},
            //    new Product {Name = "Running shoes", Price = 95}
            //}.AsQueryable());
            //ninjectKernel.Bind<IProductRepository>().ToConstant(mock.Object);
            //ninjectKernel.Bind<IProductRepository>().To<EFProductRepository>();

            //EmailSettings emailSettings = new EmailSettings
            //{
            //    WriteAsFile = bool.Parse(ConfigurationManager.AppSettings["Email.WriteAsFile"] ?? "false")
            //};

            //ninjectKernel.Bind<IOrderProcessor>().To<EmailOrderProcessor>().WithConstructorArgument("settings", emailSettings);
            ninjectKernel.Bind<RepositoryFactories>().To<RepositoryFactories>()
               .InSingletonScope();
            ninjectKernel.Bind<IRepositoryProvider>().To<RepositoryProvider>();
            ninjectKernel.Bind<ICareUow>().To<CareUow>().InRequestScope();
            //ninjectKernel.Bind<ICareUow>().To<CareUow>();
        }
    }
}