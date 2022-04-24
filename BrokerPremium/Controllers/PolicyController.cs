using BrokerPremium.Core.Constants;
using BrokerPremium.Core.Contracts;
using BrokerPremium.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace BrokerPremium.Controllers
{
    public class PolicyController : BaseController
    {
        private IPolicyService service;

        public PolicyController(IPolicyService _service)
        {
            service = _service;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddPolicy(PolicyEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (await service.AddNewPolicy(model))
            {
                ViewData[MessageConstant.SuccessMessage] = "Успешен запис!";
            }
            else
            {
                ViewData[MessageConstant.ErrorMessage] = "Възникна грешка!";
            }

            return Redirect("/");
        }


        public async Task<IActionResult> PolicyList()
        {
            var policies = await service.GetPolicies();

            return View(policies);
        }

        [HttpGet]
        [Route("Home/Policy/EditPolicy/{id?}")]
        public async Task<IActionResult> EditPolicy(Guid id)
        {
            var policy = await service.GetPolicyForEdit(id);
            var model = new PolicyEditViewModel()
            {
                Id = policy.Id,
                PolicyNumber= policy.PolicyNumber,
                TypeOfInsuranceId = policy.TypeOfInsuranceId,
                TypeOfInsurance = policy.TypeOfInsurance.Name,
                DateValidFrom = policy.DateValidFrom,
                DateValidTo = policy.DateValidTo,
                InsSuma = policy.InsSuma,
                InsCommission = policy.InsCommission,
                InsuredObjects = policy.InsuredObjects,
                InsClaims = policy.InsClaims,
                InsurerId = policy.InsurerId,
                InsurerName = policy.Insurer.Name,
                CustomerId = policy.CustomerId,
                CustomerIdentificator = policy.Customer.Identificator,
                CustomerName = policy.Customer.Name
            };

            return View(model);
        }


    }
}
