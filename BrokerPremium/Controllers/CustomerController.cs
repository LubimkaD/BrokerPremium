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

        [HttpGet]
        [Route("Home/Customer/EditCustomer/{id?}")]
        public async Task<IActionResult> EditCustomer(Guid id)
        {
            var customer = await service.GetCustomerForEdit(id);
            var model = new CustomerEditViewModel()
            {
                Id = customer.Id,
                Identificator = customer.Identificator,
                IsCompany = customer.IsCompany,
                Name = customer.Name,
                Address = customer.Address,
                Telefon = customer.Telefon,
                Email = customer.Email,
                DateValidFrom = customer.DateValidFrom
            };

            return View(model);
        }


        [HttpPost]
        [Route("Home/Customer/EditCustomer/{id?}")]
        public async Task<IActionResult> EditCustomer(CustomerEditViewModel model)
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

        [Route("Home/Customer/Policies/{id?}")]
        public async Task<IActionResult> Policies(Guid id)
        {
            try
            {
                var policies = await service.GetPoliciesForCustomer(id);
                return View(policies);
            }
            catch (ArgumentException ae)
            {

                ViewData[MessageConstant.ErrorMessage] = "Възникна грешка!";

                return Redirect("/");
            }
            

            
        }
    }
}
