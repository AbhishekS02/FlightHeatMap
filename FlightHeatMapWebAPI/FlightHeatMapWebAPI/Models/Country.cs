using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlightHeatMapWebAPI.Models
{
    public class Country
    {
        public string Name { get; set; }

        public List<State> States { get; set; }
    }
}