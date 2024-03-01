using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehicleDB.Models;

namespace VehicleDB.Controllers
{
    public class StoreController : Controller
    {

        private readonly VehicleDbContext _context;

        public StoreController (VehicleDbContext context)
        {
            _context = context;
        }
        // GET: Store
        
        public IActionResult Index()
        {
        // Retrieve the list of stores from the database or another source
        var stores = _context.Stores.ToList(); // Assuming _context is your DbContext
        return View(stores);
        }


        public IActionResult Details(int id)
        {
            // Retrieve store details based on ID and return the view
            return View();
        }

        [HttpPost]
        public IActionResult Create(Store store)
        {
            if (ModelState.IsValid)
            {
            // Save the new store to the database
            // Redirect to the appropriate action (e.g., Index) after successful creation
            return RedirectToAction("Index");
            }
        // If model validation fails, return the view with the validation errors
        return View(store);
        }
        public Address Address { get; set; }

        // Other CRUD actions can be added as needed

        public class StoreHours
        {
            public DayOfWeek Day { get; set; }
            public TimeSpan OpeningTime { get; set; }
            public TimeSpan ClosingTime { get; set; }
        }

        public class StoreViewModel
        {
            public int StoreID { get; set; }
            public string Location { get; set; }
            public List<StoreHours> Hours { get; set; }
        }
    }
}
