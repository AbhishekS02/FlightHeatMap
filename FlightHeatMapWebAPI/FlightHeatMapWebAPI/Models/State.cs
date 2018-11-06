using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlightHeatMapWebAPI.Models
{
    public class State
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public int TotalNumberOfFlights { get; set; }
    }
}