using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Soccer.Contracts.Models;

namespace Data
{
    public class SoccerContext : DbContext
    {
        private readonly string _conn;

        public DbSet<Stat> Stats { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<WinningStat> WinningStats { get; set; }

        public SoccerContext(IConfiguration configuration)
        {
            _conn = configuration["SoccerConnectionString"];
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
           => optionsBuilder.UseNpgsql(_conn);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Stat>(e => e.HasNoKey());
            modelBuilder.Entity<Team>(e => e.HasNoKey());
            modelBuilder.Entity<WinningStat>(e => e.HasNoKey());
        }
    }
}
