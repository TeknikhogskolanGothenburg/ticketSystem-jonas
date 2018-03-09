using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.DatabaseRepository;
using TicketModel;

namespace WebAPI.Controllers
{

    [Produces("application/json")]
    [Route("api/Event")]
    public class EventController : Controller
    {
        TicketDatabase ticketDB = new TicketDatabase();

        // GET api/Event
        [HttpGet]
        public IEnumerable<TicketEvent> Get()
        {
            
            return ticketDB.EventGet();
        }

        // GET api/Event/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        /// POST: api/Events
        /// Posts new event into the DB
        [HttpPost]
        public void Post([FromBody]TicketEvent ticketEvent)
        {
            ticketDB.EventAdd(ticketEvent);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ticketDB.EventRemove(id);
        }
    }
}
