using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketModel;


namespace UnofficialShop.Models
{
    public class Model
    {
        public List<Venue> venues = new List<Venue>();
        public List<TicketEvent> events = new List<TicketEvent>();
        public TicketEvent ticketEvent = new TicketEvent();
        
    }
}
