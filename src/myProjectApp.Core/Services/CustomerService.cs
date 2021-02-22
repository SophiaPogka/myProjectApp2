using myProjectApp.Core.Data;
using myProjectApp.Core.Model;
using myProjectApp.Core.Services.Options;
using System.Collections.Generic;
using System.Linq;

namespace myProjectApp.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private ΜyBDContext _cust_DBContext;

        public CustomerService(ΜyBDContext dbContext)
        {
            _cust_DBContext = dbContext;
        }
        public Customer Register(RegisterCustomerOptions options)
        {
            if (string.IsNullOrWhiteSpace(options.Name))
            {
                return null;
            }

            if (string.IsNullOrWhiteSpace(options.Surname))
            {
                return null;
            }

            if (string.IsNullOrWhiteSpace(options?.VatNumber))
            {
                return null;
            }

            var customer = new Customer
            {
                Name = options.Name,
                Surname = options.Surname,
                VatNumber = options.VatNumber
            };

            _cust_DBContext.Add(customer);
            _cust_DBContext.SaveChanges();

            return customer;
        }

        public Customer RegisterCustomerAndAccount(RegisterCustomerOptions optionsCust, RegisterAccountOptions optionsAcc)
        {
            if (string.IsNullOrWhiteSpace(optionsCust.Name))
            {
                return null;
            }

            if (string.IsNullOrWhiteSpace(optionsCust.Surname))
            {
                return null;
            }

            if (string.IsNullOrWhiteSpace(optionsCust?.VatNumber))
            {
                return null;
            }

            var customer = new Customer
            {
                Name = optionsCust.Name,
                Surname = optionsCust.Surname,
                VatNumber = optionsCust.VatNumber
            };

            customer.Accounts.Add(
                new Account()
                { 
                    AccountDescription = optionsAcc.AccountDescription,
                    AccountStatus = optionsAcc.AccountStatus
                });
            
           

            _cust_DBContext.Add(customer);
            _cust_DBContext.SaveChanges();

            return customer;
        }


        public Customer GetById(int customerId)
        {
            var cust = _cust_DBContext.Set<Customer>()
                .Where(c => c.CustomerId == customerId)
                .SingleOrDefault();

        return cust;
        }

        public List<Customer> GetAllCustomers()
        {
            var custList = _cust_DBContext.Set<Customer>()
                .ToList();

            return custList;
        }
    }
}
