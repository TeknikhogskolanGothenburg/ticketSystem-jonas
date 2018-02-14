using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketModel;
using TicketSystem.DatabaseRepository;

namespace WebAPI.Controllers
{
    
    [Produces("application/json")]
    [Route("api/Venue")]
    public class VenueController : Controller
    {
        TicketDatabase ticketDB = new TicketDatabase();


        // GET: api/Venue
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Venue/5
        [HttpGet("{id}", Name = "GetVenue")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Venue
        [HttpPost]
        public void Post([FromBody]Venue venue)
        {
            ticketDB.VenueAdd(venue);
        }
        
        // PUT: api/Venue/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {

        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {

        }

    }
}
