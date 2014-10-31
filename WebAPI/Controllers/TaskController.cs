﻿using System;
using System.Collections.Generic;
using System.Web.Http;
using DataAccess;
using ObjectLibrary;
using WebAPI;

namespace WebAPI.Controllers
{
    public class TaskController : ControllerBase
    {
        public TaskController()
        {
            Repository = new TaskRepository();
        }

        public IEnumerable<Task> Get()
        {
            var tasks = Repository.Get<Task>();

            return tasks;
        }

        public Task Get(string id)
        {
            var task = Repository.Get<Task>(long.Parse(id));
            return task;
        }

        public IHttpActionResult Add([FromBody] Task task)
        {
            if (task == null) 
                return InternalServerError();

            var id = Repository.Add(task);

            var uri = new Uri(Request.RequestUri, id);
            return Created(uri, id);
        }
    }
}