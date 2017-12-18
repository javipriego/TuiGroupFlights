using System.Linq;
using TuiGroupFlights.Models;

namespace TuiGroupFlights.Data
{
    /// <summary>
    /// Database initializer
    /// </summary>
    public class DbInitializer
    {
        public static void Initialize(TuiGroupFlightsContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Airport.Any())
            {
                return;   // DB has been seeded
            }           
            else
            {
                var airportMalaga = new Airport()
                {
                    Name = "Málaga (AGP)",
                    latitude = (float)36.7585406465564,
                    Longitude = (float)-4.3971722687
                };
                context.Airport.Add(airportMalaga);

                var airportSevilla = new Airport()
                {
                    Name = "Sevilla (SEV)",
                    latitude = (float)37.3891,
                    Longitude = (float)-5.9845
                };
                context.Airport.Add(airportSevilla);

                var airportMadrid = new Airport()
                {
                    Name = "Madrid (MAD)",
                    latitude = (float)40.4168,
                    Longitude = (float)-3.7038
                };
                context.Airport.Add(airportMadrid);

                var airportBarcelona = new Airport()
                {
                    Name = "Barcelona (BAR)",
                    latitude = (float)41.3818,
                    Longitude = (float)2.1685
                };
                context.Airport.Add(airportBarcelona);
                
                context.SaveChanges();
            }
        }
    }
}
