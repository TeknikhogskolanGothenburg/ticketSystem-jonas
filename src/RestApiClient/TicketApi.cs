using RestSharp;
using System;
using System.Collections.Generic;
using TicketSystem.RestApiClient.Model;
using TicketModel;


namespace TicketSystem.RestApiClient
{
    public class TicketApi : ITicketApi
    {
        // Implemented using RestSharp: http://restsharp.org/
        static string connectionStringAPI = "http://localhost:59941/api/";

        public List<TicketEvent> EventGet()
        {
            var client = new RestClient(connectionStringAPI);
            var request = new RestRequest("event", Method.GET);
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
            var request = new RestRequest("Event/{id}", Method.GET);
            request.AddUrlSegment("id", Id);
            var response = client.Execute<Ticket>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new KeyNotFoundException(string.Format("Event not found", Id));
            }
            return response.Data;
        }

        public Ticket VenueDel(int Id)
        {
            var client = new RestClient(connectionStringAPI);
            var request = new RestRequest("Venue/{id}", Method.DELETE);
            request.AddUrlSegment("id", Id);
            var response = client.Execute<Ticket>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new KeyNotFoundException(string.Format("Venue not found", Id));
            }
            return response.Data;
        }


    }
}
