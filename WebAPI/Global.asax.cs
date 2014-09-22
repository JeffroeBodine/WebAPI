using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using DMSPlugins;

namespace WebAPI
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_End()
        {
            Cache.Clear();
        }
    }
}