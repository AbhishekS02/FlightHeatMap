using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlightHeatMapWebAPI.Models
{
    public class FlightsInArea
    {
        public string AreaName { get; set; }

        public List<FlightDetails> FlightDetails { get; set; }
    }
}