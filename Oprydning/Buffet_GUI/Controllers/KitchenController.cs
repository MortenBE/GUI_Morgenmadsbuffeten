using Buffet_GUI.Data;
using Buffet_GUI.Data.DBModels;
using Buffet_GUI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buffet_GUI.Controllers
{
    public class KitchenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KitchenController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowBuffetReservationsExpected()
        {
            
            DateTime date = DateTime.Now.Date;          

            var restaurantCheckIns = _context.Set<BuffetReservation>().Where(c => (c.Date.Day == date.Day) && (c.Date.Month == date.Month) && (c.Date.Year == date.Year)).ToList();

            //var restaurantCheckIns = _context.Set<BuffetReservation>().Where(c => c.Date == date).ToList();

            return View(restaurantCheckIns);
        }

        /* Given date, show guest-information (expected amount, checked-in amount, etc.) */
        public IActionResult ShowNotCheckInGuests()
        {
          
            DateTime date = DateTime.Now.Date;

            var expectedGuestsInfo = _context.Set<BuffetReservation>().Where(c => (c.Date.Day == date.Day) && (c.Date.Month == date.Month) && (c.Date.Year == date.Year)).ToList();
            var checkedInEntries = _context.Set<CheckedInGuest>().Where(c => c.Date == date).ToList();

            //var expectedGuestsInfo = _context.Set<BuffetReservation>().Find(date.Day);

            //var checkedInEntries = _context.Set<CheckedInGuest>().Where(c => c.Date.Day == date.Day).ToList();

            //var buffetReservations = _context.Set<BuffetReservation>().Where(c => (c.Date.Day == date.Day) && (c.Date.Month == date.Month) && (c.Date.Year == date.Year)).ToList();
            //var restaurantCheckIns = _context.Set<CheckedInGuest>().Where(c => c.Date == date).ToList();

            var vm = new KitchenViewModel(expectedGuestsInfo, checkedInEntries);

            return View(vm);


            //    if (buffetReservations != null && restaurantCheckIns.Count > 0)
            //    {
            //        var vm = new KitchenViewModel(buffetReservations, restaurantCheckIns);

            //        return View(vm);
            //    }

            //    return RedirectToAction(nameof(Index));
        }
    }
}
