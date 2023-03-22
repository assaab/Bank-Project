using Microsoft.EntityFrameworkCore;
using Models;

namespace BankWebApi
{
    // Data/CurrentAccountContext.cs
    public class BankContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("CurrentAccountDb");
        }
    }
}

