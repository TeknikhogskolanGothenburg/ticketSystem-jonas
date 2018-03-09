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


        /// GET: api/Venue
        /// Retreives a list of Venues used for displaying all venues in the DB
        [HttpGet]
        public IEnumerable<Venue> Get()
        {
            return ticketDB.VenueGet();
        }

        /// GET: api/Venue/5
        /// Premade controller that selects a specific Venue
        [HttpGet("{id}", Name = "GetVenue")]
        public string Get(int id)
        {
            return "value";
        }
        
        /// POST: api/Venue
        /// Posts new venues into the DB
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
        

        /// <summary>
        /// DELETE: api/Venue
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ticketDB.VenueRemove(id);
        }

    }
}
