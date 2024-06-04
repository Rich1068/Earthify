using Earthify.Model;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Xamarin.Essentials;

namespace Earthify.Services
{
    public class DatabaseContext : DbContext
    {
        public DbSet<ActionModel> Actionss { get; set; }

        public DatabaseContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "Actionss.db");
            optionsBuilder.UseSqlite($"Filename={dbPath}");
        }


    }
}
