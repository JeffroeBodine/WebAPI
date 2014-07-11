using System;
using System.Collections.Generic;
using System.Web.Http;
using WebAPI.Areas.HelpPage;

namespace WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional }
            );

            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();

            // To disable tracing in your application, please comment out or remove the following line of code
            // For more information, refer to: http://www.asp.net/web-api
            config.EnableSystemDiagnosticsTracing();

            //var dts = new List<DocumentType>
            //    {
            //        new DocumentType(1, "First"),
            //        new DocumentType(2, "Second"),
            //        new DocumentType(3, "Third")
            //    };
            //dts[0].DocumentTypes.Add(new DocumentType(11, "FirstFirst"));
            //dts[0].DocumentTypes.Add(new DocumentType(12, "SecondSecond"));
            //dts[0].DocumentTypes.Add(new DocumentType(13, "SecondSecond"));

            //config.SetSampleObjects(new Dictionary<Type, object>
            //{
            //    {typeof(DocumentType), "sample string"},
            //    {typeof(IEnumerable<DocumentType>), dts.ToArray()}
            //});

   }
    }
}
