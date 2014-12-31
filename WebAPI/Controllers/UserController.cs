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

        public IHttpActionResult Post([FromBody] User user)
        {
            if (user == null)
                return InternalServerError();

            AddAuditInformation(user);

            var id = Repository.Add(user);

            var uri = new Uri(Request.RequestUri, id);
            return Created(uri, id);
        }

        public IHttpActionResult Put(long id, [FromBody] User user)
        {
            if (user == null)
                return BadRequest("user can not be null");

            AddAuditInformation(user);
            user.Id = id;

            Repository.Update(user);

            var uri = new Uri(Request.RequestUri, user.Id.ToString());
            return Created(uri, id);
        }

        public IHttpActionResult Delete(long id)
        {
            var user = Repository.Get<User>(id);
            if (user != null)
            {
                AddAuditInformation(user);
                //TODO: Find out why the audit info ist't being updated with the delete.
                Repository.Delete(user);
                return Ok();
            }
            return BadRequest("User does not exist");
        }

        //http://stackoverflow.com/questions/10954605/fluent-nhibernate-generated-audits
        /* Fiddler Body for Post testing
             {
            "UserName": "username", 
            "Password": "password", 
            "Salt": "salt", 
            "EMail": "mail", 
            "FirstName": "fName", 
            "LastName": "lName"
            }
         */

        /* Fiddler Body for Put testing
         {
        "Id": 10003,
        "UserName": "username", 
        "Password": "password", 
        "Salt": "salt", 
        "EMail": "mail", 
        "FirstName": "fName", 
        "LastName": "lName"
        }
     */
    }
}