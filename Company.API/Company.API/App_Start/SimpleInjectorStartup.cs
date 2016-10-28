using Company.Domain.Repository.UserRepository;
using MongoDB.Driver;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System.Web.Http;

namespace Company.API.App_Start
{
    public class SimpleInjectorStartup
    {
        public static void RegisterDependencies(HttpConfiguration config)
        {
            // Create the dependency injection container.
            var container = new Container();
            // Set the container to by default dispose of objects after requests.
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();

            // This is an extension method from the integration package.
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            // Register Simple Injector with the WebAPI Dependency Resolver.
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);

            RegisterServices(container);
        }

        private static void RegisterServices(Container container)
        {
            // Add services below...

            // Register mongoDb with SimpleInjector
            container.Register<IMongoDatabase>(() =>
            {
                // Create a connection to the mongoDb server.
                var client = new MongoClient("mongodb://localhost:27017");

                // Return a reference to the orders database.
                return client.GetDatabase("orders");
            }, Lifestyle.Scoped);

            container.Register<IUserRepository, UserRepository>();
        }
    }
}