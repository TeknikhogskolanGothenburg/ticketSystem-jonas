﻿using System;
using Dapper;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using TicketSystem.DatabaseRepository.Model;
using TicketSystem.DatabaseRepository;

namespace QueryCommandWindowforTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            TicketDatabase DatabaseTester = new TicketDatabase();

            Console.WriteLine("Hello World!");

            //venueadd tester
            //Console.WriteLine("enter name of venue");
            //string query1 = Console.ReadLine();
            //Console.WriteLine("enter adress");
            //string query2 = Console.ReadLine();
            //Console.WriteLine("enter city");
            //string query3 = Console.ReadLine();
            //Console.WriteLine("enter country");
            //string query4 = Console.ReadLine();
            //DatabaseTester.VenueAdd(query1, query2, query3, query4);

            Console.WriteLine("enter name of venue to remove");
            string query1 = Console.ReadLine();
            DatabaseTester.VenueRemove(query1);
        }
    }
}
