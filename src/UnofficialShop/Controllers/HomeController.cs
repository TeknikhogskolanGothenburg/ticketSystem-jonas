using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.RestApiClient;
using UnofficialShop.Models;
using TicketSystem.RestApiClient.Model;


namespace UnofficialShop.Controllers
{
    public class HomeController : Controller
    {
       public static TicketApi ticketApi = new TicketApi();

        //public List<Ticket> ticketlist = TicketGet();
        //At the start of this I need to have the EVENT-list loaded into the index page.
        //public List<TicketEvent> EventFind()

        public IActionResult Index()
        {
           ticketApi.EventGet();
            return View();

        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
