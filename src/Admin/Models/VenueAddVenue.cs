using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketModel;

namespace Admin.Models
{
    public class VenueAddVenue
    {
        public Venue NewVenue { get; set; }
        public List<Venue> ExistingVenues { get; set; }
    }
}
