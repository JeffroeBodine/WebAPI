using System;
using System.Web.Http;
using ObjectLibrary;
using DataAccess;

namespace WebAPI.Controllers
{
    public class CaseController : ApiController
    {
        private readonly RepositoryBase _repository;

        public CaseController()
        {
            _repository = new RepositoryBase();
        }

        public Case Get(string id)
        {
            using (var rb = new RepositoryBase())
            {
                return rb.Get<Case>(long.Parse(id));
            }
        }

        public IHttpActionResult Add([FromBody]Case value)
        {
            var id = _repository.Add(value);
            var uri = new Uri(Request.RequestUri, id);
            return Created(uri, value);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (_repository != null)
                _repository.Dispose();
        }
    }
}
