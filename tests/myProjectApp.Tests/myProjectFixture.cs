using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using myProjectApp.Core.Services.Extensions;
using System;

namespace myProjectApp.Tests
{
    public class myProjectFixture : IDisposable
    {
        public IServiceScope Scope { get; private set; }

        public myProjectFixture()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath($"{AppDomain.CurrentDomain.BaseDirectory}")
                .AddJsonFile("appsettings.json", false)
                .Build();

            // Initialize Dependency container
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddAppServices(config);

            Scope = serviceCollection
                .BuildServiceProvider()
                .CreateScope();
        }

        public void Dispose()
        {
            Scope.Dispose();
        }
    }
}
