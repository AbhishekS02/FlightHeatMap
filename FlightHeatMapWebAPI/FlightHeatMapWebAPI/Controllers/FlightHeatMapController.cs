using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using FlightHeatMapWebAPI.Models;
using System.Web.Http.Cors;

namespace FlightHeatMapWebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class FlightHeatMapController : ApiController
    {
        Random random = new Random();
        // GET: api/FlightHeatMap
        [HttpGet]
        [ActionName("GetFlightsInArea")]
        public string GetFlightsInArea()
        {
            return JsonConvert.SerializeObject(Flights);
        }

        [HttpGet]
        [ActionName("UpdatedFlightsInArea")]
        public string UpdatedFlightsInArea()
        {
            Flights.ForEach(s => GetCurrentState(s));
           // Countries.ForEach(s => UpdateCountry(s));
            return JsonConvert.SerializeObject(Flights);
        }
        // GET: api/FlightHeatMap/5
        [HttpGet]
        [ActionName("GetCountryAndStates")]
        public string GetCountryAndStates()
        {
            return JsonConvert.SerializeObject(Countries);
        }
        [HttpGet]
        [ActionName("UpdatedCountryAndStates")]
        public string UpdatedCountryAndStates()
        {
            Countries.ForEach(c => UpdateCountry(c));
            return JsonConvert.SerializeObject(Countries);
        }

        private void GetCurrentState(FlightDetails flight)
        {
            //if (Countries.Single(s => s.Name == flight.CountryName).States.Single(s => s.Name == flight.StateName).TotalNumberOfFlights > 0)
            //{
            //    var state = Countries.Single(s => s.Name == flight.CountryName).States.Single(s => s.Name == flight.StateName);
            //    state.TotalNumberOfFlights = state.TotalNumberOfFlights - 1;
            //}
            int randomNumber = random.Next(Countries.Count());
            var selectedCountry = Countries[randomNumber].Name;
            int randomNumber1 = random.Next(Countries.Single(s => s.Name == selectedCountry).States.Count());
            flight.CountryName = selectedCountry;
            flight.StateName = Countries.Single(s => s.Name == flight.CountryName).States[randomNumber1].Name;
           // var newState = Countries.Single(s => s.Name == flight.CountryName).States.Single(s => s.Name == flight.StateName);
            //newState.TotalNumberOfFlights = newState.TotalNumberOfFlights + 1;
        }
        
        List<FlightDetails> Flights = new List<FlightDetails>
                {
                    new FlightDetails {CountryName="India",StateName="Punjab", FlightNumber = "US 456"},
                      new FlightDetails {CountryName="India",StateName="Bihar", FlightNumber = "US 123"},
                        new FlightDetails {CountryName="India",StateName="Del", FlightNumber = "AI 756"},
                          new FlightDetails {CountryName="USA",StateName="AZ", FlightNumber = "US 756"},
                            new FlightDetails {CountryName="India",StateName="UP", FlightNumber = "AI 345"},
                              new FlightDetails {CountryName="USA",StateName="NY", FlightNumber = "US 999"},

                  new FlightDetails { CountryName="India", StateName="Del", FlightNumber = "US 233"},
                  new FlightDetails {CountryName="USA", StateName="CA", FlightNumber = "DI 756"},
                    new FlightDetails { CountryName="USA",StateName="GA", FlightNumber = "AI 233"}
                };

        List<Country> Countries = new List<Country>
            {
                new Country { Name = "India", States = new List<State> {
                    new State { Name = "UP", Color = "LightBlue", TotalNumberOfFlights = 0 },
                    new State { Name = "Bihar", Color = "LightBlue", TotalNumberOfFlights = 0 },
                    new State { Name = "Del", Color = "LightBlue", TotalNumberOfFlights = 0 },
                    new State { Name = "Punjab", Color = "LightBlue", TotalNumberOfFlights = 0 }
                }
                },
                new Country {Name = "USA",  States=new List<State> {
                    new State { Name = "AZ", Color = "LightBlue", TotalNumberOfFlights = 0 },
                    new State { Name = "CA", Color = "LightBlue", TotalNumberOfFlights = 0 },
                    new State { Name = "GA", Color = "LightBlue", TotalNumberOfFlights = 0 },
                    new State { Name = "NY", Color = "LightBlue", TotalNumberOfFlights = 0 }
                } }
            };

        private void UpdateCountry(Country country)
        {
            country.States.ForEach(s => UpdateState(s));
        }

        private void UpdateState(State state)
        {
            var stateName = state.Name;
            state.TotalNumberOfFlights = Flights.Count(c => c.StateName == stateName);
            if (state.TotalNumberOfFlights == 0)
            {
                state.Color = "LightBlue";
            }
            else if (state.TotalNumberOfFlights >= 2)
            {
                state.Color = "Red";
            }
            else
            {
                state.Color = "LightGreen";
            }
        }
    }
}
