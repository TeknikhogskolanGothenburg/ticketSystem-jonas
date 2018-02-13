﻿using RestSharp;
using System;
using System.Collections.Generic;
using TicketSystem.RestApiClient.Model;

namespace TicketSystem.RestApiClient
{
    public class TicketApi : ITicketApi
    {
        // Implemented using RestSharp: http://restsharp.org/
        static string connectionStringAPI = "http://localhost:59941/api";

        public List<Ticket> TicketGet()
        {
            var client = new RestClient(connectionStringAPI);
            var request = new RestRequest("ticket", Method.GET);
            var response = client.Execute<List<Ticket>>(request);
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

        public Ticket TicketEventGet(int TicketEventId)
        {
            var client = new RestClient(connectionStringAPI);
            var request = new RestRequest("Event/{id}", Method.GET);
            request.AddUrlSegment("id", TicketEventId);
            var response = client.Execute<Ticket>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new KeyNotFoundException(string.Format("Event not found", TicketEventId));
            }
            return response.Data;
        }



    }
}
