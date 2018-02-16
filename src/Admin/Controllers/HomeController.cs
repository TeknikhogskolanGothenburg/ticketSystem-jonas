using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Admin.Models;
using TicketModel;
using TicketSystem.RestApiClient;


namespace Admin.Controllers
{


    public class HomeController : Controller
    {

        private EventAddTicketEvent adminEvent = new EventAddTicketEvent();
        private TicketApi ticketApi = new TicketApi();
        private VenueAddVenue adminVenue = new VenueAddVenue();
        
        //Index
        public IActionResult Index()
        {
            List<Venue> venues = new List<Venue> { };
            venues = ticketApi.VenueGet();
            return View(); 
        }

        //All actions relating to Venue
        public IActionResult Venue()
        {
            adminVenue.ExistingVenues = ticketApi.VenueGet();
            return View(adminVenue);
        }

        public IActionResult VenueAdd(VenueAddVenue venues)
        {

   
            ticketApi.VenueAdd(venues.NewVenue);
            return RedirectToAction("Venue");
            
        }

        public IActionResult VenueRemove(VenueAddVenue venues)
        {
            ticketApi.VenueRemove(venues.NewVenue);
            return RedirectToAction("Venue");
        }


        //All actions relating to Events
        public IActionResult Events()
        {

            adminEvent.ExistingEvents = ticketApi.EventGet();
            if (ticketApi.EventGet() != null)
            {
                return View(adminEvent);
            }
            else adminEvent.ExistingEvents = new List<TicketEvent>();
            return View(adminEvent);

        }

        public IActionResult EventAdd(EventAddTicketEvent events)
        {


            ticketApi.EventAdd(events.NewEvent);
            return RedirectToAction("Venue");

        }

        public IActionResult EventRemove(EventAddTicketEvent events)
        {
            ticketApi.EventRemove(events.NewEvent);
            return RedirectToAction("Venue");
        }





        //Suggested Action
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
