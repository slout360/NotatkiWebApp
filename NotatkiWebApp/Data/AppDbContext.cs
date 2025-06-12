using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NotatkiWebApp.Data;
using NotatkiWebApp.Models;

namespace NotatkiWebApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Notatka> Notatkas { get; set; }
    }
}
