using BrokerPremium.Core.Contracts;
using BrokerPremium.Core.Models;
using BrokerPremium.Infrastructure.Data.Models;
using BrokerPremium.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerPremium.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IApplicationDbRepository repo;

        public CustomerService(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }

        public async Task<bool> AddNewCustomer(CustomerEditViewModel model)
        {
            var customer = new Customer()
            {
                Identificator = model.Identificator,
                IsCompany = model.IsCompany,
                Name = model.Name,
                Address = model.Address,
                Telefon = model.Telefon,
                Email = model.Email,
                DateValidFrom = model.DateValidFrom
            };
            try
            {
                await repo.AddAsync<Customer>(customer);
                await repo.SaveChangesAsync();
            }
            catch (Exception)
            {

                return false;
            }

            return true;
        }

        public async Task<Customer> GetCustomerForEdit(Guid id)
        {
            return await repo.GetByIdAsync<Customer>(id);
        }

        public async Task<IEnumerable<CustomerListViewModel>> GetCustomers()
        {
            return await repo.All<Customer>()
                .Select(x => new CustomerListViewModel()
                {
                    Id = x.Id,
                    Identificator = x.Identificator,
                    IsCompany = x.IsCompany,
                    Name = x.Name
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<PolicyListViewModel>> GetPoliciesForCustomer(Guid id)
    {
            IEnumerable<PolicyListViewModel> policies = await repo.All<InsurancePolicy>()
                .Where(p => p.CustomerId == id)
                .Select(x => new PolicyListViewModel()
                {
                    Id = x.Id,
                    PolicyNumber = x.PolicyNumber,
                    TypeOfInsuranceId = x.TypeOfInsuranceId,
                    TypeOfInsurance = x.TypeOfInsurance.Name,
                    DateValidFrom = x.DateValidFrom,
                    DateValidTo = x.DateValidTo,
                    InsSuma = x.InsSuma,
                    CustomerId = id,
                    CustomerName = x.Customer.Name
                })
                .ToListAsync();

            if (policies.Count() == 0)
            {
                throw new ArgumentException("Няма полици за този клиент!");
            };
            return policies;
        }

        public async Task<bool> UpdateCustomer(CustomerEditViewModel model)
        {
            var customer = new Customer()
            {
                Id = model.Id,
                Identificator = model.Identificator,
                IsCompany = model.IsCompany,
                Name = model.Name,
                Address = model.Address,
                Telefon = model.Telefon,
                Email = model.Email,
                DateValidFrom = model.DateValidFrom
            };
            try
            {
                repo.Update<Customer>(customer);
                await repo.SaveChangesAsync();
            }
            catch (Exception)
            {

                return false;
            }

            return true;
        }
    }
}
