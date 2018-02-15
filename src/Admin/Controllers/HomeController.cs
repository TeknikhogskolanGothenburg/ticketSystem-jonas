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

        private TicketEvent ticketEvent = new TicketEvent();
        private Venue venue = new Venue();
        private TicketApi ticketApi = new TicketApi();
        private VenueAddVenue adminVenue = new VenueAddVenue();
        

        public IActionResult Index()
        {
            List<Venue> venues = new List<Venue> { };
            venues = ticketApi.VenueGet();
            return View(); 
        }
        public IActionResult Venue()
        {
            adminVenue.ExistingVenues = ticketApi.VenueGet();
            return View(adminVenue);
        }

        //public IActionResult GetVenues()
        //{
            
        //    return View(ticketApi.VenueGet());
        //}

        public IActionResult VenueAdd(Admin.Models.VenueAddVenue venues)
        {

   
            ticketApi.VenueAdd(venues.NewVenue);
            return RedirectToAction("Venue");
            
        }

        public IActionResult Events()
        {
            ViewData["Message"] = "Adding/removing Events";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
