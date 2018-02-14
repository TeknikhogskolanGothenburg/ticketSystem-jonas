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

        public IActionResult Index()
        {

            return View(); //Will return a view of all venues and events
        }

        public IActionResult AddVenue()
        {

            venue.VenueName = "Ullevi";
            venue.Country = "Swe";
            venue.City = "gbg";
            venue.Address = "gbg";

            ticketApi.VenueAdd(venue);

            return View();
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
