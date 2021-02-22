using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myProjectApp.api.Options
{
    public class OptionsCustomerAccount
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string VatNumber { get; set; }

        public string AccountDescription { get; set; }
        public int AccountStatus { get; set; }
    }
}
