using Microsoft.EntityFrameworkCore;
using myProjectApp.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myProjectApp.Core.Data
{
    public class ΜyBDContext : DbContext
    {
        string connectionstring = "Server=localhost;Database=TinyBank;User Id=sa;Password=admin!@#123;";

        public ΜyBDContext(
             DbContextOptions options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(connectionstring);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>()
                .ToTable("Customer");

            modelBuilder.Entity<Account>()
                .ToTable("Account");
        }
    }
}
