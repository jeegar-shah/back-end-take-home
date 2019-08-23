using System;
namespace GuestlogixDemo.Models
{
    public class Route
    {
        public string AirlineId { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }


        public Route()
        {

        }

        public Route(string airlineId, string origin, string destination)
        {
            AirlineId = airlineId;
            Origin = origin;
            Destination = destination;
        }
    }
}
