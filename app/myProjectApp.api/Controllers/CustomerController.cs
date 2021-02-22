using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using myProjectApp.api.Options;
using myProjectApp.Core.Services;
using myProjectApp.Core.Services.Options;
using System;

namespace myProjectApp.api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CustomerController : Controller
    {

        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerService _customers;

        public CustomerController(ILogger<CustomerController> logger, ICustomerService customers)
        {
            _logger = logger;
            _customers = customers;
        }

        //[HttpGet]
        //public string Get()
        //{
        //    return "Hello World!";

        //}

        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            var custList = _customers.GetAllCustomers();

            return Json(custList);

        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var customer = _customers.GetById(id);

            return Json(customer);
        }


        //[HttpPost]
        //public IActionResult RegisterCustomer(
        //    [FromBody] RegisterCustomerOptions options)
        //{
        //    var cust = _customers.Register(options);

        //    return Json(cust);
        //}

        [HttpPost]
        public IActionResult RegisterCustomerAccount( [FromBody] OptionsCustomerAccount options)
        {
            var optionsCust = new RegisterCustomerOptions();
            optionsCust.Name = options.Name;
            optionsCust.Surname = options.Surname;
            optionsCust.VatNumber = options.VatNumber;

            var optionsAcc = new RegisterAccountOptions();
            optionsAcc.AccountDescription = options.AccountDescription;
            optionsAcc.AccountStatus = options.AccountStatus;

            var cust = _customers.RegisterCustomerAndAccount(optionsCust, optionsAcc);

            return Json(cust);
        }
    }
}
