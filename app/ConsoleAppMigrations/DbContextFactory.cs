using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using myProjectApp.Core.Data;
using myProjectApp.Core.Config.Extensions;

namespace myProjectApp
{
    public class DbContextFactory : IDesignTimeDbContextFactory<ΜyBDContext>
    {
        public ΜyBDContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath($"{AppDomain.CurrentDomain.BaseDirectory}")
                .AddJsonFile("appsettings.json", false)
                .Build();

            var config = configuration.ReadAppConfiguration();

            var optionsBuilder = new DbContextOptionsBuilder<ΜyBDContext>();

            optionsBuilder.UseSqlServer(
                config.ConnectionString,
                options => {
                    options.MigrationsAssembly("ConsoleAppMigrations");
                });

            return new ΜyBDContext(optionsBuilder.Options);
        }
    }
}
