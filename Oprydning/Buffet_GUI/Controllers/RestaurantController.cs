﻿using Buffet_GUI.Data;
using Buffet_GUI.Data.DBModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buffet_GUI.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RestaurantController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoomNumber,NumberOfAdultsCheckedIn,NumberOfChildrenCheckedIn,Date")] CheckedInGuest checkedInGuest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(checkedInGuest);
                await _context.SaveChangesAsync();
                return View();
                //return RedirectToAction(nameof(Index));
            }
            return View();
            //return View(checkedInGuest);
        }

    }
}
