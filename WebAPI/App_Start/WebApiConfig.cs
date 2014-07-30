using System.Net.Http.Headers;
using System.Web.Http;
using Newtonsoft.Json.Serialization;

namespace WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute("FileRoute", "api/Document/{id}/File", new { controller = "File", action = "Get" });
            config.Routes.MapHttpRoute("KeywordRoute", "api/Document/{id}/Keyword", new { controller = "Keyword", action = "Get" });
            config.Routes.MapHttpRoute("ProgramTypeRoute", "api/Case/{id}/ProgramType", new { controller = "ProgramType", action = "Get" });
            config.Routes.MapHttpRoute("ClientRoute", "api/Case/{id}/Client", new { controller = "Client", action = "Get" });
            config.Routes.MapHttpRoute("AddressRoute", "api/Case/{id}/Client/{clientid}/Address", new { controller = "Address", action = "Get" });

            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional });
          
            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();

            // To disable tracing in your application, please comment out or remove the following line of code
            // For more information, refer to: http://www.asp.net/web-api
            config.EnableSystemDiagnosticsTracing();

            //config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            json.UseDataContractJsonSerializer = true;
            json.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc;
            json.SerializerSettings.DateFormatHandling = Newtonsoft.Json.DateFormatHandling.MicrosoftDateFormat;
            json.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            json.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            json.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
        }
    }
}
