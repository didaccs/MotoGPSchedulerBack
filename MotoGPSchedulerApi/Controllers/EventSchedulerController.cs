using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MotoGPSchedulerApi.Models;
using MotoGPSchedulerApi.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MotoGPSchedulerApi.Controllers
{
    [Route("api/[controller]")]
    public class EventSchedulerController : Controller
    {
        private IRepository<Event> repoEvent;
        
        public EventSchedulerController(IRepository<Event> repoEvent)
        {
            this.repoEvent = repoEvent;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return repoEvent.GetAll();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Event Get(int id)
        {
            return repoEvent.Get(id);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
            throw new NotImplementedException();
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
