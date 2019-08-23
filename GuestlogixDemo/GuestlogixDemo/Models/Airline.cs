using System;

namespace GuestlogixDemo.Models
{
    public class Airline
    {
        public string Name { get; set; }
        public string TwoDigitCode { get; set; }
        public string ThreeDigitCode { get; set; }
        public string Country { get; set; }

        public Airline()
        {   

        }

        public Airline(string name, string twoDigitCode, string threeDigitCode, string country){

            Name = name;
            TwoDigitCode = twoDigitCode;
            ThreeDigitCode = threeDigitCode;
            Country = country;

        }

    }
}
