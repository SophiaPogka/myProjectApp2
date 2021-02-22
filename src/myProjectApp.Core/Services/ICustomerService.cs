using myProjectApp.Core.Model;
using myProjectApp.Core.Services.Options;
using System.Collections.Generic;

namespace myProjectApp.Core.Services
{
    public interface ICustomerService
    {
        public Customer Register(RegisterCustomerOptions options);
        public Customer GetById(int customerId);

        public List<Customer> GetAllCustomers();

        public Customer RegisterCustomerAndAccount(RegisterCustomerOptions optionsCust, RegisterAccountOptions optionsAcc);
    }
}
