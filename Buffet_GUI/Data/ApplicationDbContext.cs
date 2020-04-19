﻿using System;
using System.Collections.Generic;
using System.Text;
using Buffet_GUI.Data.DBModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Buffet_GUI.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<BuffetReservation> BuffetReservations { get; set; }
        public DbSet<CheckedInGuest> CheckedInGuests { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<CheckedInGuest>().HasKey(p => new { p.RoomNumber, p.Date });
            mb.Entity<BuffetReservation>().HasKey(p => p.Date);           

            base.OnModelCreating(mb);
        }

        //private void SeedData(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<BuffetReservation>()
        //        .HasData(
        //            new BuffetReservation()
        //            {
        //                RoomNumber = 1,
        //                Date = DateTime.Today,
        //                NumberOfChildren = 6,
        //                NumberOfAdults = 10
        //            },
        //            new BuffetReservation()
        //            {
        //                RoomNumber = 2,
        //                Date = DateTime.Today,
        //                NumberOfChildren = 4,
        //                NumberOfAdults = 2
        //            },
        //            new BuffetReservation()
        //            {
        //                RoomNumber = 43,
        //                Date = DateTime.Today,
        //                NumberOfChildren = 5,
        //                NumberOfAdults = 3
        //            }  
        //            );
        //}
    }
}
