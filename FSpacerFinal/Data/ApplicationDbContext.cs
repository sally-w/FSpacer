using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FSpacerFinal.Models;

namespace FSpacerFinal.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<DriveCard> DriveCards { get; set; }
        public DbSet<Operator> Operators { get; set; }
        public DbSet<SpacerCard> SpacerCards { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<DriveCard>().ToTable("DriveCard");
            builder.Entity<Operator>().ToTable("Operator");
            builder.Entity<SpacerCard>().ToTable("SpacerCard");
        }
    }
}
