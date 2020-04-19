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
    public class BuffetReservationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BuffetReservationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BuffetReservations
        public async Task<IActionResult> Index()
        {
            return View(await _context.BuffetReservations.ToListAsync());
        }

        // GET: BuffetReservations/Details/5
        public async Task<IActionResult> Details(DateTime? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buffetReservation = await _context.BuffetReservations
                .FirstOrDefaultAsync(m => m.Date == id);
            if (buffetReservation == null)
            {
                return NotFound();
            }

            return View(buffetReservation);
        }

        // GET: BuffetReservations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BuffetReservations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AllExpectedGuests,NumberOfAdults,NumberOfChildren,Date")] BuffetReservation buffetReservation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(buffetReservation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(buffetReservation);
        }

        // GET: BuffetReservations/Edit/5
        public async Task<IActionResult> Edit(DateTime? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buffetReservation = await _context.BuffetReservations.FindAsync(id);
            if (buffetReservation == null)
            {
                return NotFound();
            }
            return View(buffetReservation);
        }

        // POST: BuffetReservations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DateTime id, [Bind("AllExpectedGuests,NumberOfAdults,NumberOfChildren,Date")] BuffetReservation buffetReservation)
        {
            if (id != buffetReservation.Date)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(buffetReservation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuffetReservationExists(buffetReservation.Date))
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
            return View(buffetReservation);
        }

        // GET: BuffetReservations/Delete/5
        public async Task<IActionResult> Delete(DateTime? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buffetReservation = await _context.BuffetReservations
                .FirstOrDefaultAsync(m => m.Date == id);
            if (buffetReservation == null)
            {
                return NotFound();
            }

            return View(buffetReservation);
        }

        // POST: BuffetReservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(DateTime id)
        {
            var buffetReservation = await _context.BuffetReservations.FindAsync(id);
            _context.BuffetReservations.Remove(buffetReservation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BuffetReservationExists(DateTime id)
        {
            return _context.BuffetReservations.Any(e => e.Date == id);
        }
    }
}
