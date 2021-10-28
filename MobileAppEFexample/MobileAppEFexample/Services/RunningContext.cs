using System.IO;
using Xamarin.Essentials;
using Microsoft.EntityFrameworkCore;

namespace MobileAppEFexample
{
    public class RunningContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Run> Runs { get; set; }

        public RunningContext()
        {
            SQLitePCL.Batteries_V2.Init();

            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "running.db3");

            optionsBuilder.UseSqlite($"Filename={dbPath}");
        }
    }
}