using BrokerPremium.Core.Constants;
using BrokerPremium.Core.Contracts;
using BrokerPremium.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace BrokerPremium.Controllers
{
    public class CustomerController : BaseController
    {
        private ICustomerService service;

        public CustomerController(ICustomerService _service)
        {
            service = _service;
        }

        public IActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer(CustomerEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (await service.AddNewCustomer(model))
            {
                ViewData[MessageConstant.SuccessMessage] = "Успешен запис!";
            }
            else
            {
                ViewData[MessageConstant.ErrorMessage] = "Възникна грешка!";
            }

            return Redirect("/");
        }
    

        public async Task<IActionResult> CustomerList()
        {
            var customers = await service.GetCustomers();

            return View(customers);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CustomerEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (await service.UpdateCustomer(model))
            {
                ViewData[MessageConstant.SuccessMessage] = "Успешен запис!";
            }
            else
            {
                ViewData[MessageConstant.ErrorMessage] = "Възникна грешка!";
            }

            return View(model);
        }
    }
}
