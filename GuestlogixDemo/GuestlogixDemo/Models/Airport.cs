using System;
namespace GuestlogixDemo.Models
{
    public class Airport
    {

        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string IATA { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public Airport()
        {


        }

        public Airport(string name, string city, string country, string iata, string latitude, string longitude)
        {
            Name = name;
            City = city;
            Country = country;
            IATA = iata;
            Latitude = latitude;
            Longitude = longitude;

        }
    }
}
