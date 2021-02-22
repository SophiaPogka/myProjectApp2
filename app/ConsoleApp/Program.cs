using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using myProjectApp.Core.Config.Extensions;
using myProjectApp.Core.Data;
using myProjectApp.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var configuration = new ConfigurationBuilder()
            .SetBasePath($"{AppDomain.CurrentDomain.BaseDirectory}")
            .AddJsonFile("appsettings.json", false)
            .Build();

            var config = configuration.ReadAppConfiguration();

            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseSqlServer(
                config.ConnectionString,
                options =>
                {
                    options.MigrationsAssembly("myProjectApp");
                });

            using (var db = new ΜyBDContext(optionsBuilder.Options))
            {
                //var newCustomer = new Customer()
                //{
                //    Name = "Sophia",
                //    Surname = "Pogka",
                //    Address = "Pelopida 1",
                //    VatNumber = "123456789",
                //    CustomerCategory = CustomerCategory.Retail
                //};

                //newCustomer.Accounts.Add(
                //    new Account()
                //    {
                //        AccountDescription = "Account 1",
                //        AccountStatus = 1
                //    });

                //newCustomer.Accounts.Add(
                //    new Account()
                //    {
                //        AccountDescription = "Account 2",
                //        AccountStatus = 2
                //    });

                //db.Add(newCustomer);
                //db.SaveChanges();

                List<Account> myAccount = new List<Account>();

                myAccount = db.Set<Account>()
                //.Where(c => c.CustomerId == 1)
                //.Where(c => c.AccountId == 1)
                .ToList();
                //.SingleOrDefault()
                //.ToString;

                Console.WriteLine($"I found Account! VatNumber");


            }
        }
    }
}
