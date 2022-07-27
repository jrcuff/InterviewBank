using InterviewBank.Database.Models;
using Microsoft.EntityFrameworkCore;
#pragma warning disable CS8618

namespace InterviewBank.Database
{
    public class BankDbContext : DbContext
    {
        public BankDbContext(DbContextOptions<BankDbContext> options) : base(options)
        {
        }

        public DbSet<Bank> Banks { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bank>().HasData(
                new Bank() { BIN = "815", Name = "Caisse Populaire DesJardins", Country = "Québec"},
                new Bank() { BIN = "004", Name = "Toronto Dominion", Country = "Canada" });

            modelBuilder.Entity<Client>().HasData(
                new Client() { Id = "1122943", Name = "Bob The Builder" });

            modelBuilder.Entity<Account>().HasData(
                new Account() { AccountNumber = "45jmsh2", BIN = "815", ClientId = "1122943" },
                new Account() { AccountNumber = "smn4592", BIN = "004", ClientId = "1122943" });
        }
    }
}