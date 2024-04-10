using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _275___Final
{
    public class AppDBContext : DbContext
    {
        public DbSet<Models.User> Users { get; set; }
        public DbSet<Models.Transaction> Transactions { get; set; }
        public DbSet<Models.ExchangeRate> ExchangeRates { get; set; }
        public DbSet<Models.CryptoAddress> CryptoAddresses { get; set; }
        public DbSet<Models.CryptoCurrency> CryptoCurrencies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=B231-24\B23124;Database=275Final;User Id=sa;Password=P@ssword!;encrypt = false;");
        }
    }
}
