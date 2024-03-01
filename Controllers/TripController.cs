using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace VehicleDB.Controllers
{
public class TripController : Controller
{
    private readonly VehicleDbContext _context;

    public TripController(VehicleDbContext context)
    {
        _context = context;
    }

    public IActionResult Create()
    {
        var viewModel = new Trip
        {
        };


    return View(viewModel);
        
    }
    private IEnumerable<Vehicle> GetVehicles()
    {
    // Return your vehicles from the database or wherever they are stored
    return new List<Vehicle>(); // Placeholder
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Trip trip)
    {
        if (ModelState.IsValid)
        {
            // Your logic to save the trip
            _context.Trips.Add(trip);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // If model state is not valid, re-render the view with the model and select list
        var vehicles = _context.Vehicles.ToList();
        var vehicleSelectList = new SelectList(vehicles, "VIN", "MakeModel", trip.VehicleVIN);

        //TODO:
        
        
        return View(trip);
        
    }
    public IActionResult Index()
    {
        var trips = _context.Trips.ToList();
        return View(trips);
    }
    public IActionResult Details(int id)
    {
        var trip = _context.Trips.FirstOrDefault(t => t.Id == id);
        if (trip == null)
        {
            return NotFound();
        }
        
        return View(trip);
    }
    public IActionResult Delete(int id)
    {
        var trip = _context.Trips.FirstOrDefault(t => t.Id == id); 
        if (trip == null)
        {
            return NotFound();
        }

        return View(trip);
    }
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var trip = _context.Trips.FirstOrDefault(t => t.Id == id); 
        if (trip == null)
        {
            return NotFound();
        }

        _context.Trips.Remove(trip);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }


}

}