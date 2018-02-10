using Dapper;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using TicketSystem.DatabaseRepository.Model;

namespace TicketSystem.DatabaseRepository
{
    public class TicketDatabase : ITicketDatabase
    {
        static string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=TicketSystem;Trusted_Connection=True";
        //string connectionString = ConfigurationManager.ConnectionStrings["TicketSystem"].ConnectionString;


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

        public Venue VenueAdd(string name, string address, string city, string country)
        {
            
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.Query("insert into Venues([VenueName],[Address],[City],[Country]) values(@Name,@Address, @City, @Country)", new { Name = name, Address= address, City = city, Country = country });
                var addedVenueQuery = connection.Query<int>("SELECT IDENT_CURRENT ('Venues') AS Current_Identity").First();
                return connection.Query<Venue>("SELECT * FROM Venues WHERE VenueID=@Id", new { Id = addedVenueQuery }).First();
            }
        }

        public void VenueRemove(string name)
        {
           
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.Query("DELETE FROM Venues  WHERE VenueName =" + "'" + name +"'");
              
            }
        }


        public List<Venue> VenuesFind(string query)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                return connection.Query<Venue>("SELECT * FROM Venues WHERE VenueName like '%"+query+ "%' OR Address like '%" + query + "%' OR City like '%" + query + "%' OR Country like '%" + query + "%'").ToList();
            }
        }


        }

    }

