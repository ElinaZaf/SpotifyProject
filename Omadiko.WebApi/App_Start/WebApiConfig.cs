using Newtonsoft.Json.Serialization;
using System.Web.Http;
using Newtonsoft.Json;
using System.Web.Http.Cors;

namespace Omadiko.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //var settings = config.Formatters.JsonFormatter.SerializerSettings;
            //settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            //settings.Formatting = Formatting.Indented;

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            EnableCorsAttribute cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);
        }
    }
}
