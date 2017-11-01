using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClubsAndSocieties.Data;
using ClubsAndSocieties.Models;

namespace ClubsAndSocieties.Controllers
{
    public class ClubsAndSocietiesController : Controller
    {
        private readonly ClubAndSocContext _context;

        public ClubsAndSocietiesController(ClubAndSocContext context)
        {
            _context = context;
        }

        // GET: ClubsAndSocieties
        public async Task<IActionResult> Index(
                                string currentFilter,
                                string searchString,
                                int? page)
        {
            ViewData["CurrentFilter"] = searchString;

            var clubsAndSocs = from c in _context.ClubsAndSocieties
                           select c;
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                clubsAndSocs = clubsAndSocs.Where(c => c.Name.Contains(searchString));
            }

            /*suppose you change the reference to _context.ClubsAndSocieties so that 
             * instead of an EF DbSet it references a repository method that returns
             * an IEnumerable collection.) The result would normally be the same 
             * but in some cases may be different.*/

            //return View(await _context.ClubsAndSocieties.ToListAsync());
            int pageSize = 10;
            return View(await PaginatedList<ClubsAndSociety>.CreateAsync(clubsAndSocs.AsNoTracking(), page ?? 1, pageSize));
        }

        // GET: ClubsAndSocieties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clubsAndSociety = await _context.ClubsAndSocieties
                .SingleOrDefaultAsync(m => m.Id == id);
            if (clubsAndSociety == null)
            {
                return NotFound();
            }

            return View(clubsAndSociety);
        }

        // GET: ClubsAndSocieties/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClubsAndSocieties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]              //took out AdminID
        public async Task<IActionResult> Create([Bind("Name,Chairperson,Secretary,Treasurer,Phone,Email,Description")] ClubsAndSociety clubsAndSociety)
        {
            /*
             * This try catch adds the ClubsAndSocieties entity created by the ASP.NET MVC
             * model binder to the ClubsAndSocieties entity set and then saves the 
             * changes to the database. (Model binder refers to the ASP.NET
             * MVC functionality that makes it easier for you to work with 
             * data submitted by a form; a model binder converts posted 
             * form values to CLR types and passes them to the action 
             * method in parameters. In this case, the model binder 
             * instantiates a ClubsAndSociety entity for you using property values 
             * from the Form collection.)
             */
            try
            {
                    if (ModelState.IsValid)
                    {
                        _context.Add(clubsAndSociety);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists " +
                        "see your system administrator.");
                }
                if (ModelState.IsValid)
            {
                _context.Add(clubsAndSociety);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clubsAndSociety);
        }

        // GET: ClubsAndSocieties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clubsAndSociety = await _context.ClubsAndSocieties.SingleOrDefaultAsync(m => m.Id == id);
            if (clubsAndSociety == null)
            {
                return NotFound();
            }
            return View(clubsAndSociety);
        }

        // POST: ClubsAndSocieties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AdminID,Name,Chairperson,Secretary,Treasurer,Phone,Email,Description")] ClubsAndSociety clubsAndSociety)
        {
            if (id != clubsAndSociety.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clubsAndSociety);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClubsAndSocietyExists(clubsAndSociety.Id))
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
            return View(clubsAndSociety);
        }

        // GET: ClubsAndSocieties/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clubsAndSociety = await _context.ClubsAndSocieties
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.Id == id);
            if (clubsAndSociety == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Delete failed. Try again, and if the problem persists " +
                    "see your system administrator.";
            }
            return View(clubsAndSociety);
        }

        // POST: ClubsAndSocieties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clubsAndSociety = await _context.ClubsAndSocieties.SingleOrDefaultAsync(m => m.Id == id);
            _context.ClubsAndSocieties.Remove(clubsAndSociety);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClubsAndSocietyExists(int id)
        {
            return _context.ClubsAndSocieties.Any(e => e.Id == id);
        }
    }
}
