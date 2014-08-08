using System.Web.Http;
using DataAccess;

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
    }
}