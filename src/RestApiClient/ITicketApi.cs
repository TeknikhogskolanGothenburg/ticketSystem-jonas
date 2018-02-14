using System.Collections.Generic;
using TicketSystem.RestApiClient.Model;
using TicketModel;


namespace TicketSystem.RestApiClient
{
    public interface ITicketApi
    {
        /// <summary>
        /// Get all tickets in the system 
        /// </summary>
        /// <returns></returns>
        List<TicketEvent> EventGet();

        /// <summary>
        /// Get a ticket by ID from the system Returns a single ticket
        /// </summary>
        /// <param name="ticketId">ID of the ticket</param>
        /// <returns></returns>
        Ticket TicketTicketIdGet(int ticketId);
    }
}
