using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace VehicleDB.Controllers
{
public class AddressController : Controller
{
    private readonly VehicleDbContext _context;

    public AddressController(VehicleDbContext context)
    {
        _context = context;
    }

    // GET: Address/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Address/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Street,City,State,Zip")] Address address)
    {
        if (ModelState.IsValid)
        {
            _context.Add(address);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(address);
    }

    // GET: Address/Index
    public async Task<IActionResult> Index()
    {
        return View(await _context.Addresses.ToListAsync());
    }
    
}

}