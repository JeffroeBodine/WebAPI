using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;
using DataAccess;
using ObjectLibrary;

namespace WebAPI.Controllers
{
    public class UserController : ControllerBase
    {
        public UserController()
        {
            Repository = new RepositoryBase();
        }

        public IEnumerable<User> Get()
        {
            var users = Repository.Get<User>();

            return users;
        }

        public User Get(string id)
        {
            var user = Repository.Get<User>(long.Parse(id));
            return user;
        }

        public IHttpActionResult Add([FromBody] User user)
        {
            if (user == null)
                return InternalServerError();

            var userHostName = HttpContext.Current.Request.UserHostName;
            var userHostAddress = HttpContext.Current.Request.UserHostAddress;
            var userAgent = HttpContext.Current.Request.UserAgent;

            user.AuditApplication = userAgent;
            user.AuditUser = userHostName;

            var id = Repository.Add(user);

            var uri = new Uri(Request.RequestUri, id);
            return Created(uri, id);
        }

        //http://stackoverflow.com/questions/10954605/fluent-nhibernate-generated-audits
        /* Fiddler Body for testing
             {
            "Name": "username", 
            "Password": "password", 
            "Salt": "salt", 
            "EMail": "mail", 
            "FirstName": "fName", 
            "LastName": "lName"
            },
         */
    }
}