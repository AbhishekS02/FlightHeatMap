using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlightHeatMapWebAPI.Models
{
    public class FlightDetails
    {
        public string CountryName { get; set; }
        public string StateName { get; set; }
        public string FlightNumber { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public decimal CurrentAltitude { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }
        public int NumberOfPassengers { get; set; }
        public int TotalPersons { get; set; }
    }
}