using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace TuiGroupFlights.Models
{
    /// <summary>
    /// Model for flight
    /// </summary>
    public class Flight
    {
        public int ID { get; set; }        

        [DisplayName("Origin Airport")]
        public int OriginAirportId { get; set; }

        [DisplayName("Destiny Airport")]
        public int DestinyAirportId { get; set; }
    }
}
