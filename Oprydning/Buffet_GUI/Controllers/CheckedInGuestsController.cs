using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Buffet_GUI.Data;
using Buffet_GUI.Data.DBModels;

namespace Buffet_GUI.Controllers
{
    public class CheckedInGuestsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CheckedInGuestsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CheckedInGuests
        public async Task<IActionResult> Index()
        {
            return View(await _context.CheckedInGuests.ToListAsync());
        }

        // GET: CheckedInGuests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkedInGuest = await _context.CheckedInGuests
                .FirstOrDefaultAsync(m => m.RoomNumber == id);
            if (checkedInGuest == null)
            {
                return NotFound();
            }

            return View(checkedInGuest);
        }

        // GET: CheckedInGuests/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CheckedInGuests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoomNumber,NumberOfAdultsCheckedIn,NumberOfChildrenCheckedIn,Date")] CheckedInGuest checkedInGuest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(checkedInGuest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(checkedInGuest);
        }

        // GET: CheckedInGuests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkedInGuest = await _context.CheckedInGuests.FindAsync(id);
            if (checkedInGuest == null)
            {
                return NotFound();
            }
            return View(checkedInGuest);
        }

        // POST: CheckedInGuests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoomNumber,NumberOfAdultsCheckedIn,NumberOfChildrenCheckedIn,Date")] CheckedInGuest checkedInGuest)
        {
            if (id != checkedInGuest.RoomNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(checkedInGuest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CheckedInGuestExists(checkedInGuest.RoomNumber))
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
            return View(checkedInGuest);
        }

        // GET: CheckedInGuests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkedInGuest = await _context.CheckedInGuests
                .FirstOrDefaultAsync(m => m.RoomNumber == id);
            if (checkedInGuest == null)
            {
                return NotFound();
            }

            return View(checkedInGuest);
        }

        // POST: CheckedInGuests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var checkedInGuest = await _context.CheckedInGuests.FindAsync(id);
            _context.CheckedInGuests.Remove(checkedInGuest);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CheckedInGuestExists(int id)
        {
            return _context.CheckedInGuests.Any(e => e.RoomNumber == id);
        }
    }
}
