using Microsoft.EntityFrameworkCore;

namespace TuiGroupFlights.Data
{
    /// <summary>
    /// Context for data base
    /// </summary>
    public class TuiGroupFlightsContext : DbContext
    {
        public TuiGroupFlightsContext (DbContextOptions<TuiGroupFlightsContext> options)
            : base(options)
        {
             DbInitializer.Initialize(this);
        }

        public DbSet<TuiGroupFlights.Models.Flight> Flight { get; set; }

        public DbSet<TuiGroupFlights.Models.Airport> Airport { get; set; }
                
    }
}
