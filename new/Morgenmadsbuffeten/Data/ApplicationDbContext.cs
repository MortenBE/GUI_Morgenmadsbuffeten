using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Morgenmadsbuffeten.Data.Models;

namespace Morgenmadsbuffeten.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<BuffetReservation> BuffetReservations { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<BuffetReservation>()
                .HasKey(e => e.RoomNumber);
            mb.Entity<BuffetReservation>().Property(a => a.CheckedIn).HasDefaultValue(false);

            base.OnModelCreating(mb);
        }

    }
}
