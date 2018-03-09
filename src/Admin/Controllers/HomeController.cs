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

        //Index Loads the lists if there are any.
        public IActionResult Index()
        {
            List<Venue> venues = new List<Venue> { };
            venues = ticketApi.VenueGet();
            List<TicketEvent> events = new List<TicketEvent> { };
            events = ticketApi.EventGet();
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

        //Retreives the selected Venue as a string and parses it to int.
        public IActionResult VenueRemove(string VenueSelected)
        {
            string ID = Request.Form["VenueSelected"];
            
            ticketApi.VenueRemove(int.Parse(ID));
            return RedirectToAction("Venue");
        }


        //All actions relating to Events
        public IActionResult Events()
        {

            adminEvent.ExistingEvents = ticketApi.EventGet();
            
            {
                return View(adminEvent);
            }
         

        }


        public IActionResult EventDescription(EventAddTicketEvent events)
        {


            ticketApi.TicketEventGet(events.NewEvent);
            return RedirectToAction("Events");

        }


        public IActionResult EventAdd(EventAddTicketEvent events)
        {


            ticketApi.EventAdd(events.NewEvent);
            return RedirectToAction("Events");

        }

        public IActionResult EventRemove()
        {
            string Id = Request.Form["EventSelected"];
            ticketApi.EventRemove(int.Parse(Id));
            return RedirectToAction("Events");
        }





        //Suggested Action
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
