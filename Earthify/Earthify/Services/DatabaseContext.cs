using Earthify.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using System.IO;

namespace Earthify.Services
{
    public class DatabaseContext : DbContext
    {
        public DbSet<ActionModel> Action { get; set; }
        public DatabaseContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Action.db");
            optionsBuilder.UseSqlite($"Filename={dbpath}");
        }
    }
}
