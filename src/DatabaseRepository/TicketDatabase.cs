using Dapper;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

using TicketModel;

namespace TicketSystem.DatabaseRepository
{
    public class TicketDatabase : ITicketDatabase
    {
        static string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=TicketSystem;Trusted_Connection=True";
        //string connectionString = ConfigurationManager.ConnectionStrings["TicketSystem"].ConnectionString;

        //Backoffice adding event
        public TicketEvent EventAdd(string name, string description)
        {
            
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.Query("insert into TicketEvents(EventName, EventHtmlDescription) values(@Name, @Description)", new { Name = name, Description = description });
                var addedEventQuery = connection.Query<int>("SELECT IDENT_CURRENT ('TicketEvents') AS Current_Identity").First();
                return connection.Query<TicketEvent>("SELECT * FROM TicketEvents WHERE TicketEventID=@Id", new { Id = addedEventQuery }).First();
            }
        }
         
        //Backoffice removing event
        public void EventRemove(int ID)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.Query("DELETE FROM TicketEvents  WHERE ID =" + "'" + ID + "'");
            }
        }
        //Backoffice Adding venue
        public Venue VenueAdd(Venue venue)
        {
            
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.Query("insert into Venues([VenueName],[Address],[City],[Country]) values(@Name,@Address, @City, @Country)", new { Name = venue.VenueName, Address= venue.Address, City = venue.City, Country = venue.Country });
                var addedVenueQuery = connection.Query<int>("SELECT IDENT_CURRENT ('Venues') AS Current_Identity").First();
                return connection.Query<Venue>("SELECT * FROM Venues WHERE VenueID=@Id", new { Id = addedVenueQuery }).First();
            }
        }
        //Backoffice removing venue
        public void VenueRemove(int Id)
        {
           
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.Query("DELETE FROM Venues  WHERE VenueID =" + "'" + Id +"'");
              
            }
        }

        //Backoffice only listing venues to allow easier deletion.
        public List<Venue> VenuesFind(string query)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                return connection.Query<Venue>("SELECT * FROM Venues WHERE VenueName like '%"+query+ "%' OR Address like '%" + query + "%' OR City like '%" + query + "%' OR Country like '%" + query + "%'").ToList();
            }
        }

        //Ticketshop choose an item through the list
        public List<TicketEvent> EventSelect(int Id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                return connection.Query<TicketEvent>("SELECT * FROM Venues WHERE VenueID = '" + Id + "'") .ToList();
            }
        }

        //Getall Events list
        public List<TicketEvent> EventGet()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                return connection.Query<TicketEvent>("SELECT EventName FROM TicketEvent ").ToList();
            }
        }

        //Getall Venues list
        public List<Venue> VenueGet()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                return connection.Query<Venue>("SELECT * FROM Venues ").ToList();
            }
        }


    }

    }

