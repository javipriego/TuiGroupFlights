using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TuiGroupFlights.Data;
using TuiGroupFlights.Helper;
using TuiGroupFlights.Models;

namespace TuiGroupFlights.Controllers
{
    /// <summary>
    /// Flights controller
    /// </summary>
    public class FlightsController : Controller
    {
        private readonly TuiGroupFlightsContext _context;

        public FlightsController(TuiGroupFlightsContext context)
        {
            _context = context;
        }

        // GET: Flights
        public async Task<IActionResult> Index()
        {
            var listAirports = await _context.Airport.ToListAsync();

            var listFlights = await _context.Flight.ToListAsync();

            var listFlightPopulated = listFlights.Select(fli => DtoBuilder.populateFlight(fli,listAirports));

            return View(listFlightPopulated);
        }

        // GET: Flights/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = await _context.Flight
                .SingleOrDefaultAsync(m => m.ID.Equals(id));
            if (flight == null)
            {
                return NotFound();
            }


            var listAirports = await _context.Airport.ToListAsync();

            var flightPopulated = DtoBuilder.populateFlight(flight, listAirports);
           
            return View(flightPopulated);
        }
                
        // GET: Flights/Create
        public IActionResult Create()
        {
            ViewData["Airports"] = _context.Airport.Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = a.AirportID.ToString()
            });
            
            return View();
        }

        // POST: Flights/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,OriginAirportId,DestinyAirportId")] Flight flight)
        {
            if (ModelState.IsValid)
            {
                _context.Add(flight);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(flight);
        }

        // GET: Flights/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewData["Airports"] = _context.Airport.Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = a.AirportID.ToString()
            });

            if (id == null)
            {
                return NotFound();
            }

            var flight = await _context.Flight.SingleOrDefaultAsync(m => m.ID.Equals(id));
            if (flight == null)
            {
                return NotFound();
            }
            return View(flight);
        }

        // POST: Flights/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,OriginAirportId,DestinyAirportId")] Flight flight)
        {
            if (!id.Equals(flight.ID))
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(flight);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlightExists(flight.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(flight);
        }

        // GET: Flights/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = await _context.Flight
                .SingleOrDefaultAsync(m => m.ID.Equals(id));
            if (flight == null)
            {
                return NotFound();
            }

            return View(flight);
        }

        // POST: Flights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var flight = await _context.Flight.SingleOrDefaultAsync(m => m.ID.Equals(id));
            _context.Flight.Remove(flight);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FlightExists(int id)
        {
            return _context.Flight.Any(e => e.ID.Equals(id));
        }
    }
}
