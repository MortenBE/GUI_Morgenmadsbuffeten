using Buffet_GUI.Data;
using Buffet_GUI.Data.DBModels;
using Buffet_GUI.Models;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize("CanEnterKitchen")]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize("CanEnterKitchen")]
        public IActionResult ShowBuffetReservationsExpected(DateTime dateTime)
        {
            DateTime date = dateTime.Date;

            var restaurantCheckIns = _context.Set<BuffetReservation>().Where(c => (c.Date.Day == date.Day) && (c.Date.Month == date.Month) && (c.Date.Year == date.Year)).ToList();

            return View(restaurantCheckIns);
        }

        [Authorize("CanEnterKitchen")]
        /* Given date, show guest-information (expected amount, checked-in amount, etc.) */
        public IActionResult ShowNotCheckInGuests(DateTime dateTime)
        {
            DateTime date = dateTime.Date;

            var expectedGuestsInfo = _context.Set<BuffetReservation>().Where(c => (c.Date.Day == date.Day) && (c.Date.Month == date.Month) && (c.Date.Year == date.Year)).ToList();
            var checkedInEntries = _context.Set<CheckedInGuest>().Where(c => c.Date == date).ToList();

            var vm = new KitchenViewModel(expectedGuestsInfo, checkedInEntries);

            return View(vm);

        }
    }
}
