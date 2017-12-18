using System.Collections.Generic;
using System.Linq;
using TuiGroupFlights.Models;

namespace TuiGroupFlights.Helper
{
    /// <summary>
    /// DTO Builder
    /// </summary>
    public class DtoBuilder
    {
        /// <summary>
        /// Populate the flight info dto, using flight model and list of airports
        /// </summary>
        /// <param name="flight">Flight model</param>
        /// <param name="listAirports">List of airports</param>
        /// <returns></returns>
        public static DTO.FlightInfoDTO populateFlight(Flight flight, List<Airport> listAirports)
        {
            var destinyAirport = listAirports.Where(air => air.AirportID.Equals(flight.DestinyAirportId)).FirstOrDefault();
            var originAirport = listAirports.Where(air => air.AirportID.Equals(flight.OriginAirportId)).FirstOrDefault();
            
            var distance = Utils.CalculateDistance(originAirport,destinyAirport);
            var fuel = Utils.CalculateFuel(distance);

            return new DTO.FlightInfoDTO()
            {
                DestinyAirportName = destinyAirport != null ? destinyAirport.Name : string.Empty,
                OriginAirportName = originAirport != null ? originAirport.Name : string.Empty,
                Distance = distance,
                Fuel = fuel,
                flightID = flight.ID
            };
        }

        
    }
}
