using System;
using GuestlogixDemo.Models;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace GuestlogixDemo.Data
{
    public class DataAccess
    {

        string unitTestBasePath = "../../../GuestlogixDemo/Data/";
        string serverBasePath = "~/Data/";

        /// <summary>
        /// Finds the shorest flight path between origin and destination airports partially using BFS
        /// </summary>
        /// <param name="originInput"></param>
        /// <param name="destinationInput"></param>
        /// <param name="testMode"></param>
        /// <returns></returns>
        public string GetShortestPath(string origin, string destination, bool testMode = false)
        {
            //testMode = true;

            string path = "full";
            if (testMode)
            {
                path = "test";
            }

            //Read the lists from the CSV files
            List<Airline> airlines = GetAirlinesFromCSV(path);
            List<Airport> airports = GetAirportsFromCSV(path);
            List<Route> routes = GetRoutesFromCSV(path);


            //Check for invalid origin/destination
            if (!airports.Any(o => o.IATA == origin) && !airports.Any(o => o.IATA == destination))
            {
                return "Invalid Origin and Destination. Please make sure the inputs are valid.";
            }

            //Check for invalid origin
            if (!airports.Any(o => o.IATA == origin))
            {
                return "Invalid Origin. Please make sure the inputs are valid.";
            }

            //Check for invalid destination
            if (!airports.Any(o => o.IATA == destination))
            {
                return "Invalid Destination. Please make sure the inputs are valid.";
            }

            //Stores the airports visited during BFS
            Queue<string> visitedAirports = new Queue<string>();

            //Key in dictionary will store airports visited. Value will be the parent in the constructed search tree
            Dictionary<string, string> shortestPaths = new Dictionary<string, string>();

            //
            shortestPaths.Add(origin, null);
            visitedAirports.Enqueue(origin);

            //Build a search tree from origin to destination using BFS
            while(visitedAirports.Count != 0)
            {
                string currentAirport = visitedAirports.Dequeue();
                //If the destination has been reached during the loop
                if(currentAirport == destination)
                {
                    break;
                }

                foreach(var routeFromAirport in routes.FindAll(r => r.Origin == currentAirport))
                {
                    //If the airport has not been encountered before
                    if (!shortestPaths.ContainsKey(routeFromAirport.Destination))
                    {
                        visitedAirports.Enqueue(routeFromAirport.Destination);
                        shortestPaths.Add(routeFromAirport.Destination, currentAirport);
                    }
                }

            }

            //If destination was not found while constructing the search tree, no path was found
            if(!shortestPaths.ContainsKey(destination)) {
                return "No Route Found. Please change the airports and try again.";
            }

            //Map the shorest path starting from destination back to origin by traversing the tree
            List<string> shortestCurrentPath = new List<string>();
            string start = destination;

            while(start != null)
            {
                shortestCurrentPath.Add(start);
                start = shortestPaths[start];
            }

            //Reverse the list to correct the order
            shortestCurrentPath.Reverse();
            return String.Join(" -> ", shortestCurrentPath);
        }

        /// <summary>
        /// Generate list of Airlines from CSV
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private List<Airline> GetAirlinesFromCSV(string path)
        {
            List<Airline> airlines = new List<Airline>();

            string[] lines;
            
            //For unit tests, when server is not running
            if (System.Web.HttpContext.Current == null)
            {
                lines = System.IO.File.ReadAllLines(unitTestBasePath + path + "/airlines.csv");
            }
            //If server is running
            else
            {
                lines = System.IO.File.ReadAllLines(System.Web.HttpContext.Current.Server.MapPath(serverBasePath + path + "/airlines.csv"));
            }
                

            foreach (string item in lines)
            {
                var values = item.Split(',');
                airlines.Add(new Airline(values[0], values[1], values[2], values[3]));              
            }
            return airlines;
        }

        /// <summary>
        /// Generate list of Airports from CSV
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private List<Airport> GetAirportsFromCSV(string path)
        {
            List<Airport> airports = new List<Airport>();

            string[] lines;
            
            //For unit tests, when server is not running
            if (System.Web.HttpContext.Current == null)
            {
                lines = System.IO.File.ReadAllLines(unitTestBasePath + path + "/airports.csv");
            }
            //If server is running
            else
            {
                lines = System.IO.File.ReadAllLines(System.Web.HttpContext.Current.Server.MapPath(serverBasePath + path + "/airports.csv"));
            }
            foreach (string item in lines)
            {
                var values = item.Split(',');
                airports.Add(new Airport(values[0], values[1], values[2], values[3], values[4], values[5]));
            }
            return airports;
        }

        /// <summary>
        /// Generate list of Routes from CSV
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private List<Route> GetRoutesFromCSV(string path)
        {
            List<Route> routes = new List<Route>();

            string[] lines;

            //For unit tests, when server is not running
            if (System.Web.HttpContext.Current == null)
            {
               lines = System.IO.File.ReadAllLines(unitTestBasePath + path + "/routes.csv");
            }
            //If server is running
            else
            {
                lines = System.IO.File.ReadAllLines(System.Web.HttpContext.Current.Server.MapPath(serverBasePath + path + "/routes.csv"));
            }
            foreach (string item in lines)
            {
                var values = item.Split(',');
                routes.Add(new Route(values[0], values[1], values[2]));
            }
            return routes;
        }

    }
}
