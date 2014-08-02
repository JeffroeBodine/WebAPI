using System.Web.Http;
using DataAccess;

namespace WebAPI
{
    public class ControllerBase : ApiController
    {
         public readonly RepositoryBase Repository;

         public ControllerBase()
        {
            Repository = new RepositoryBase();
        }

         protected override void Dispose(bool disposing)
         {
             base.Dispose(disposing);
             if (Repository != null)
                 Repository.Dispose();
         }
    }
}