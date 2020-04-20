using System;
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
            mb.Entity<BuffetReservation>().HasKey(p => p.Date
            );
            mb.Entity<BuffetReservation>().HasIndex(p => p.Date).IsUnique();


            SeedGuests(mb);

            base.OnModelCreating(mb);
        }

        private void SeedGuests(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CheckedInGuest>()
                .HasData(
                    new CheckedInGuest()
                    {
                        RoomNumber = 22,
                        NumberOfChildrenCheckedIn = 6,
                        NumberOfAdultsCheckedIn = 10,
                        Date = DateTime.Today
                    },
                    new CheckedInGuest()
                    {
                        RoomNumber = 14,
                        NumberOfChildrenCheckedIn = 1,
                        NumberOfAdultsCheckedIn = 2,
                        Date = DateTime.Today
                    },
                    new CheckedInGuest()
                    {
                        RoomNumber = 123,
                        NumberOfChildrenCheckedIn = 4,
                        NumberOfAdultsCheckedIn = 7,
                        Date = DateTime.Today
                    }

                );
        }




    }
}
