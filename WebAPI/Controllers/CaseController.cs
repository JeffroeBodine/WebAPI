using System;
using System.Web.Http;
using ObjectLibrary;

namespace WebAPI.Controllers
{
    public class CaseController : ControllerBase
    {
        public Case Get(string id)
        {
            return Repository.Get<Case>(long.Parse(id));
        }

        public IHttpActionResult Add([FromBody]Case value)
        {
            var id = Repository.Add(value);
            var uri = new Uri(Request.RequestUri, id);
            return Created(uri, value);
        }

        //public IHttpActionResult Update([FromBody]Case value)
        //{
        //    Repository.Update(value);
        //    return Ok();
        //}

        //public IHttpActionResult Delete([FromBody]Case value)
        //{
        //    Repository.Update(value);
        //    return Ok();
        //}
    }
}
