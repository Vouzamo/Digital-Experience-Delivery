using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using Common.Services;
using Core.Services;
using DD4T.ContentModel.Contracts.Logging;
using DD4T.ContentModel.Contracts.Resolvers;
using DD4T.DI.Autofac;
using log4net.Config;
using WebApp.Resolvers;

namespace WebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private ILifetimeScope BuildContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterFilterProvider();
            builder.UseDD4T();

            builder.RegisterType<PublicationResolver>().As<IPublicationResolver>();
            builder.RegisterType<DD4T.Logging.Log4net.DefaultLogger>().As<ILogger>();

            builder.RegisterType<LabelService>().As<ILabelService>();

            return builder.Build();
        }

        protected void Application_Start()
        {
            var container = BuildContainer();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            // Log4Net
            XmlConfigurator.Configure();

            AreaRegistration.RegisterAllAreas();
            //GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
