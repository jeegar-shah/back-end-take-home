using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuestlogixDemo.Models
{
    public class IndexViewModel
    {
        public string Origin;
        public string Destination;
        public bool Mode;
        public string Result;

        public IndexViewModel()
        {
            Origin = "";
            Destination = "";
            Mode = false;
            Result = "";
        }

    }
}