using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MongoDB.Driver;
using SimpleInjector.Integration.WebApi;

namespace Company.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void SetupDependencyInjection()
        {
            // Create the dependency injection container.
            var container = new Container();
            // Set the container to by default dispose of objects after requests.
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();

            // Register
            container.Register(() =>
            {
                var client = new MongoClient();
                return client.GetDatabase("db");
            }, Lifestyle.Scoped);
        }
    }
}
