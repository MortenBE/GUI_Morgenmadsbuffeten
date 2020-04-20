using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Buffet_GUI.Data;
using Buffet_GUI.Data.DBModels;

namespace Buffet_GUI.Controllers
{
    public class ReceptionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReceptionController(ApplicationDbContext context)
        {
            _context = context;
        }

        //public IActionResult Reception()
        //{
        //    return View();
        //}

        public IActionResult ShowCheckedInBuffetList()
        {
            return View();
        }

        public IActionResult Reception()
        {
            DateTime date = DateTime.Now.Date;

            var restaurantCheckIns = _context.Set<CheckedInGuest>().Where(c => c.Date == date).ToList();

            return View(restaurantCheckIns);
        }



    }
}
