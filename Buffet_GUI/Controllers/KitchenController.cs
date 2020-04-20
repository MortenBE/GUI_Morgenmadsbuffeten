using Buffet_GUI.Data;
using Buffet_GUI.Data.DBModels;
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
    }
}
