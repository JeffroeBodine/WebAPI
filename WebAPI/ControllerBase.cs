using System.Web;
using System.Web.Http;
using DataAccess;
using ObjectLibrary;

namespace WebAPI
{
    public class ControllerBase : ApiController
    {
        public RepositoryBase Repository;

        public ControllerBase()
        {
            Repository = new RepositoryBase();
        }

        public ControllerBase(RepositoryBase repository)
        {
            Repository = repository;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (Repository != null)
                Repository.Dispose();
        }

        protected void AddAuditInformation<T>(T obj)
        {
            var auditableBaseObject = obj as AuditableBaseObject<T>;

            if (auditableBaseObject != null)
            {
                var userHostName = HttpContext.Current.Request.UserHostName;
                var userHostAddress = HttpContext.Current.Request.UserHostAddress;
                var userAgent = HttpContext.Current.Request.UserAgent;

                auditableBaseObject.AuditApplication = userAgent;
                auditableBaseObject.AuditUser = userHostName;
            }
        }

        public static string LocalConnectionString =
            @"Data Source=.;Initial Catalog=webAPI;Persist Security Info=False;User ID=sa;Password=northwoods";

    }
}