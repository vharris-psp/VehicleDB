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
        // Retrieve vehicles from the database
    var vehicles = _context.Vehicles.ToList();
    
    // Create a select list for vehicles
    var vehicleSelectList = new SelectList(vehicles, "VIN", "MakeModel");
    
    // Create an empty Trip object
    var trip = new Trip();

    // Pass the Trip object and VehicleSelectList to the view
    ViewData["VehicleSelectList"] = vehicleSelectList;
    return View(trip);
        
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
        
        var viewModel = new TripCreateViewModel
        {
            Trip = trip,
            VehicleSelectList = vehicleSelectList
        };
        
        return View(viewModel);
        
    }
}
public class TripCreateViewModel
{
    public Trip Trip { get; set; }
    public SelectList VehicleSelectList { get; set; }
}
}