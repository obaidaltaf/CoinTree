using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CTWebAPI.Models
{
    public partial class CoinTreeDBContext : DbContext
    {
        public CoinTreeDBContext()
        {
        }

        public CoinTreeDBContext(DbContextOptions<CoinTreeDBContext> options)
            : base(options)
        {
        }

        public DbSet<CryptoRates> CryptoRates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite("Data Source=Database.db");
        
    }
}
