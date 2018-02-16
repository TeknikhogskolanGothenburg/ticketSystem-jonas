using RestSharp;
using System;
using System.Collections.Generic;
using TicketSystem.RestApiClient.Model;
using TicketModel;
using Newtonsoft.Json;

namespace TicketSystem.RestApiClient
{
    public class TicketApi : ITicketApi
    {
        // Implemented using RestSharp: http://restsharp.org/
        static string connectionStringAPI = "http://localhost:59941/api/";


        //Event method requests
        public List<TicketEvent> EventGet()
        {
            var client = new RestClient(connectionStringAPI);
            var request = new RestRequest("events", Method.GET);
            var response = client.Execute<List<TicketEvent>>(request);
            return response.Data;
        }

        public Ticket TicketTicketIdGet(int ticketId)
        {
            var client = new RestClient(connectionStringAPI);
            var request = new RestRequest("ticket/{id}", Method.GET);
            request.AddUrlSegment("id", ticketId);
            var response = client.Execute<Ticket>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new KeyNotFoundException(string.Format("Ticket with ID: {0} is not found", ticketId));
            }

            return response.Data;
        }


        public Ticket TicketEventGet(int Id)
        {
            var client = new RestClient(connectionStringAPI);
            var request = new RestRequest("Events/{id}", Method.GET);
            request.AddUrlSegment("id", Id);
            var response = client.Execute<Ticket>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new KeyNotFoundException(string.Format("Event not found", Id));
            }
            return response.Data;
        }


        public void EventAdd(TicketEvent ticketEvent)
        {
            var output = JsonConvert.SerializeObject(ticketEvent);

            var client = new RestClient(connectionStringAPI);
            var request = new RestRequest("Events", Method.POST);
            request.AddParameter("application/json", output, ParameterType.RequestBody);
            var response = client.Execute<TicketEvent>(request);

        }
        public void EventRemove(TicketEvent events)
        {
            var output = JsonConvert.SerializeObject(events);
            var client = new RestClient(connectionStringAPI);
            var request = new RestRequest("Events", Method.DELETE);
            request.AddParameter("application/json", output, ParameterType.RequestBody);
            var response = client.Execute<Venue>(request);
        }




        //Venue method requests
        public List<Venue> VenueGet()
        {
            var client = new RestClient(connectionStringAPI);
            var request = new RestRequest("Venue", Method.GET);
            var response = client.Execute<List<Venue>>(request);
            return response.Data;
        }




        public void VenueAdd(Venue venue)
        {
            var output = JsonConvert.SerializeObject(venue);
            var client = new RestClient(connectionStringAPI);
            var request = new RestRequest("Venue", Method.POST);
            request.AddParameter("application/json", output, ParameterType.RequestBody);
            var response = client.Execute<Venue>(request);
        }
        public void VenueRemove(Venue venue)
        {
            var output = JsonConvert.SerializeObject(venue);
            var client = new RestClient(connectionStringAPI);
            var request = new RestRequest("Venues", Method.DELETE);
            request.AddParameter("application/json", output, ParameterType.RequestBody);
            var response = client.Execute<Venue>(request);
        }


    }
}
