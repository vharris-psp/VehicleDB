
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace VehicleDB.Co
{
public class PersonController : Controller
{
    private readonly VehicleDbContext _context;

    public PersonController(VehicleDbContext context)
    {
        _context = context;
    }

    // GET: Person/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Person/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,DOB")] Person person)
    {
        if (ModelState.IsValid)
        {
            _context.Add(person);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(person);
    }

    // GET: Person/Index
    public async Task<IActionResult> Index()
    {
        return View(await _context.Persons.ToListAsync());
    }

    // GET: Person/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var person = await _context.Persons
            .FirstOrDefaultAsync(m => m.Id == id);
        if (person == null)
        {
            return NotFound();
        }

        return View(person);
    }

        // GET: Person/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var person = await _context.Persons.FindAsync(id);
        if (person == null)
        {
            return NotFound();
        }
        return View(person);
    }

    // POST: Person/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,DOB")] Person person)
    {
        if (id != person.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(person);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(person.Id))
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
        return View(person);
    }

    private bool PersonExists(int id)
    {
        return _context.Persons.Any(e => e.Id == id);
    }
}

}