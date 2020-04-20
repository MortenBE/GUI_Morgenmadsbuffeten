using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Buffet_GUI.Data;
using Buffet_GUI.Data.DBModels;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Buffet_GUI.Controllers
{
    public class ReceptionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReceptionController(ApplicationDbContext context)
        {
            _context = context;
        }


        [Authorize("CanEnterReception")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.BuffetReservations.ToListAsync());
        }

        [Authorize("CanEnterReception")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize("CanEnterReception")]
        public IActionResult Reception()
        {
            return View();
        }
        
        public IActionResult ShowCheckedInBuffetList(DateTime dateTime)
        {
            DateTime date = dateTime.Date;     
            
            var restaurantCheckIns = _context.Set<CheckedInGuest>().Where(c => c.Date == date).ToList();

            return View(restaurantCheckIns);
        }

        [Authorize("CanEnterReception")]
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
    }
}
