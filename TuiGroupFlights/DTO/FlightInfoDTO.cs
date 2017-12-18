using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TuiGroupFlights.DTO
{
    /// <summary>
    /// Flight information DTO
    /// </summary>
    public class FlightInfoDTO
    {
        public int flightID { get; set; }

        [DisplayName("Origin Airport")]
        public string OriginAirportName { get; set; }

        [DisplayName("Destiny Airport")]
        public string DestinyAirportName { get; set; }

        [DisplayName("Fuel")]
        [DisplayFormat(DataFormatString = "{0:#.##} liters")]
        public double Fuel { get; set; }

        [DisplayName("Distance")]
        [DisplayFormat(DataFormatString = "{0:#.##} kms")]
        public double Distance { get; set; }
    }
}
