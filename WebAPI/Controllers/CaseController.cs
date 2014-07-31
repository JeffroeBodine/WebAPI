﻿using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ObjectLibrary;
using DataAccess;

namespace WebAPI.Controllers
{
    public class CaseController : ApiController
    {
        public Case Get(string id)
        {
            using (var rb = new RepositoryBase())
            {
                return rb.Get<Case>(long.Parse(id));
            }
        }

        public IHttpActionResult Add([FromBody]Case value)
        {
            using (var rb = new RepositoryBase())
            {
                var id = rb.Add(value);
                var uri = new Uri(Request.RequestUri, id.ToString());
                return Created(uri, value);
            }
        }
    }
}
