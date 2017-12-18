using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TuiGroupFlights.Models;

namespace TuiGroupFlights.Controllers
{
    /// <summary>
    /// Home controller
    /// </summary>
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Contact()
        {
            ViewData["Message"] = "Application about the interview with Tui Group";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
