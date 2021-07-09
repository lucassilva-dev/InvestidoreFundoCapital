using Microsoft.EntityFrameworkCore;
using Uniciv.Api.Models;

namespace Uniciv.Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
            {

            }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<FundoCapital>().HasKey(p => p.Id);
            modelBuilder.Entity<Investidor>().HasKey(p => p.Id);
        }
        public DbSet<FundoCapital> FundosCapital { get; set; }
        public DbSet<Investidor> Investidores { get; set; }
    }
}