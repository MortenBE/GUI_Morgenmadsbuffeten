﻿using Buffet_GUI.Data;
using Buffet_GUI.Data.DBModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buffet_GUI.Controllers
{
    public class RestaurantController : Controller
    {
        [Authorize("CanEnterRestaurant")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.CheckedInGuests.ToListAsync());
        }

        private readonly ApplicationDbContext _context;

        public RestaurantController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize("CanEnterRestaurant")]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize("CanEnterRestaurant")]
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

    }
}
