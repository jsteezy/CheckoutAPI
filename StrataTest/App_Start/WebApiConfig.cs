using System.Web;
using System.Web.Http;
using StrataTest.Interfaces;
using StrataTest.Repository;
using Unity;
using StrataTest.IOC;
using Unity.Injection;


namespace StrataTest
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes`
            string jsonDataFolder = HttpContext.Current.Server.MapPath("~/bin");
            var container = new UnityContainer();
            container.RegisterType<IUserRepository, UserRepository>(
                new InjectionConstructor($"{jsonDataFolder}/Store/Users.json"));
            config.DependencyResolver = new Resolver(container);
            config.MapHttpAttributeRoutes();

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
