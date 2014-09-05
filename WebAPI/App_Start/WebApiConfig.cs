using System.Net.Http.Headers;
using System.Web.Http;

namespace WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute("ProgramTypeRoute", "api/Case/{id}/ProgramType", new { controller = "ProgramType", action = "Get" });

            config.Routes.MapHttpRoute("CaseClientAddressRoute", "api/Case/{id}/Client/{clientid}/Address", new { controller = "Address", action = "Get" });
            config.Routes.MapHttpRoute("ClientAddressRoute", "api/Client/{clientid}/Address", new { controller = "Address", action = "Get" });

            config.Routes.MapHttpRoute("CaseRoute", "api/Case/{id}", new { controller = "Case", action = "Get", id = RouteParameter.Optional });
            config.Routes.MapHttpRoute("ClientRoute", "api/Case/{caseId}/Client/{id}", new { controller = "Client", action = "Get", id = RouteParameter.Optional });

            config.Routes.MapHttpRoute("CaseDocumentRoute", "api/Case/{caseId}/Client/{id}/Document", new { controller = "Document", action = "Get" });
            config.Routes.MapHttpRoute("ClientDocumentRoute", "api/Client/{id}/Document", new { controller = "Document", action = "Get" });

            config.Routes.MapHttpRoute("CaseDocumentMetaDataRoute", "api/Case/{id}/Client/{clientid}/Document/{documentid}/MetaData", new { controller = "DocumentMetaData", action = "Get" });
            config.Routes.MapHttpRoute("ClientDocumentMetaDataRoute", "api/Client/{clientid}/Document/{documentid}/MetaData", new { controller = "DocumentMetaData", action = "Get" });
            config.Routes.MapHttpRoute("DocumentMetaDataRoute", "api/Document/{documentid}/MetaData", new { controller = "DocumentMetaData", action = "Get" });
        
            config.Routes.MapHttpRoute("CaseKeywordRoute", "api/Case/{caseId}/Client/{clientId}/Document/{id}/Keyword", new { controller = "Keyword", action = "Get" });
            config.Routes.MapHttpRoute("ClientKeywordRoute", "api/Client/{clientId}/Document/{id}/Keyword", new { controller = "Keyword", action = "Get" });
            config.Routes.MapHttpRoute("KeywordRoute", "api/Document/{id}/Keyword", new { controller = "Keyword", action = "Get" });

            config.Routes.MapHttpRoute("CaseFileRoute", "api/Case/{caseId}/Client/{clientId}/Document/{documentid}/File", new { controller = "File", action = "Get" });
            config.Routes.MapHttpRoute("ClientFileRoute", "api/Client/{clientId}/Document/{documentid}/File", new { controller = "File", action = "Get" });
            config.Routes.MapHttpRoute("FileRoute", "api/Document/{documentid}/File", new { controller = "File", action = "Get" });
            


            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional });
            config.Routes.MapHttpRoute("DefaultApiWithAction", "api/{controller}/{id}/{action}", new { id = RouteParameter.Optional });


            //  config.Routes.MapHttpRoute("FileRoute", "api/Document/{documentid}/File", new { controller = "File", action = "Get" });
            //  config.Routes.MapHttpRoute("FileRoute2", "api/Cases/{id}/Client/{clientid}/Document/{documentid}/File", new { controller = "File", action = "Get" });
           
            //  config.Routes.MapHttpRoute("AddClientWithCaseroute", "api/{controller}/{id}/Client", new { controller = "Case" });

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
            //json.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            json.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            GlobalConfiguration.Configuration.Formatters.Add(json);
        }
    }
}
