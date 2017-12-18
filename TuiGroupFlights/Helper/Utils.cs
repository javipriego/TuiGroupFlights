using TuiGroupFlights.Models;

namespace TuiGroupFlights.Helper
{
    /// <summary>
    /// Utils
    /// </summary>
    public class Utils
    {
        /// <summary>
        /// Factor of fuel for each km in flight
        /// </summary>
        const double FuelFactor = 12;

        /// <summary>
        /// Constant for the take off effort
        /// </summary>
        const double TakeoffEffort = 45;

        /// <summary>
        /// Obtain the distance using as reference origin and destiny airports
        /// </summary>
        /// <param name="originAirport">Origin airport</param>
        /// <param name="destinyAirport">Destiny airport</param>
        /// <returns></returns>
        public static double CalculateDistance(Airport originAirport, Airport destinyAirport)
        {
            // set the Geocoordinate related to origin airport
            var destinyCoord = new System.Device.Location.GeoCoordinate(originAirport.latitude, originAirport.Longitude);

            // set the Geocoordinate related to destiny airport
            var originCoord = new System.Device.Location.GeoCoordinate(destinyAirport.latitude, destinyAirport.Longitude);
            
            // return the distance in kms
            return originCoord.GetDistanceTo(destinyCoord) / 1000;
        }

        /// <summary>
        /// Calcula the fuel that spends related to the distance and the factor of liters per each km
        /// </summary>
        /// <param name="distance"></param>
        /// <returns></returns>
        public static double CalculateFuel(double distance)
        {
            // return the fuel using the distance in kms as reference
            return (distance * FuelFactor) + TakeoffEffort;
        }
    }
}
