using Microsoft.Extensions.DependencyInjection;
using myProjectApp.Core.Data;
using myProjectApp.Core.Model;
using myProjectApp.Core.Services;
using System.Linq;
using Xunit;


namespace myProjectApp.Tests

{
    public class myCustomerTests : IClassFixture<myProjectFixture>
    {
        private ICustomerService _customers;
        private ΜyBDContext _dbContext;

        public myCustomerTests(myProjectFixture fixture)
        {
            _customers = fixture.Scope.ServiceProvider
                .GetRequiredService<ICustomerService>();
            _dbContext = fixture.Scope.ServiceProvider
                .GetRequiredService<ΜyBDContext>();
        }


        [Fact]
        public Customer Add_Customer_Success()
        {
            var options = new Core.Services.Options.RegisterCustomerOptions()
            {
                Name = "Jim",
                Surname = "Antivachis",
                VatNumber = ""
            };

            var cust = _customers.Register(options);

            Assert.NotNull(cust);


            var savedCustomer = _dbContext.Set<Customer>()
                .Where(c => c.CustomerId == cust.CustomerId)
                .SingleOrDefault();
            Assert.NotNull(savedCustomer);
            Assert.Equal(options.Name, savedCustomer.Name);
            Assert.Equal(options.Surname, savedCustomer.Surname);
            Assert.Equal(options.VatNumber, savedCustomer.VatNumber);


            return cust;
        }

    }
}
