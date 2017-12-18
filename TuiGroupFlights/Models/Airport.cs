using System.ComponentModel.DataAnnotations;

namespace TuiGroupFlights.Models
{
    /// <summary>
    /// Model of airport
    /// </summary>
    public class Airport
    {
        [Key]
        public int AirportID { get; set; }
        public string Name { get; set; }
        public float latitude { get; set; }
        public float Longitude { get; set; }
    }
}
