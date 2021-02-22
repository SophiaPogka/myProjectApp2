using System;
using System.Collections.Generic;

namespace myProjectApp.Core.Model
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string VatNumber { get; set; }
        public CustomerCategory CustomerCategory { get; set; }

        public List<Account> Accounts { get; set; }

        public Customer()
        {

            Accounts = new List<Account>();

        }
    }
}
