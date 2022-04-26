using BrokerPremium.Core.Contracts;
using BrokerPremium.Core.Models;
using BrokerPremium.Infrastructure.Data.Models;
using BrokerPremium.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BrokerPremium.Core.Services
{
    public class PolicyService : IPolicyService
    {
        private readonly IApplicationDbRepository repo;

        public PolicyService(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }
        public async Task<bool> AddNewPolicy(PolicyEditViewModel model)
        {
            var insurancePolicy = new InsurancePolicy()
            {
                PolicyNumber = model.PolicyNumber,
                TypeOfInsuranceId = model.TypeOfInsuranceId,
                DateValidFrom = model.DateValidFrom,
                DateValidTo = model.DateValidTo,
                InsSuma = model.InsSuma,
                InsCommission = model.InsCommission,
                InsurerId = model.InsurerId,
                CustomerId = model.CustomerId
            };

            try
            {
                await repo.AddAsync<InsurancePolicy>(insurancePolicy);
                await repo.SaveChangesAsync();
            }
            catch (Exception)
            {

                return false;
            }

            return true;
        }

        public async Task<IEnumerable<CustomerViewModel>> GetCustomers()
        {
            return await repo.All<Customer>()
                .Select(x => new CustomerViewModel()
                {
                    //CustomerIdentificator = x.Identificator,
                    CustomerId = x.Id,
                    CustomerName = x.Name
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<InsurerViewModel>> GetInsurers()
        {
            return await repo.All<Insurer>()
                .Select(x => new InsurerViewModel()
                {
                    InsurerId = x.Id,
                    InsurerName = x.Name,
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<PolicyListViewModel>> GetPolicies()
        {
            return await repo.All<InsurancePolicy>()
                .Select(x => new PolicyListViewModel()
                {
                    Id = x.Id,
                    PolicyNumber = x.PolicyNumber,
                    TypeOfInsuranceId = x.TypeOfInsuranceId,
                    TypeOfInsurance = x.TypeOfInsurance.Name,
                    DateValidFrom = x.DateValidFrom,
                    DateValidTo = x.DateValidTo,
                    InsSuma = x.InsSuma,
                    CustomerName = x.Customer.Name.ToString()
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<PolicyListViewModel>> GetPoliciesForCustomer(Guid id)
        {
            return await GetPolicies();
         }

        public Task<InsurancePolicy> GetPolicyForEdit(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TypeOfInsuranceViewModel>> GetTypeOfInsurances()
        {
            return await repo.All<TypeOfInsurance>()
                .Select(x => new TypeOfInsuranceViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                })
                .ToListAsync();
        }

        public Task<bool> UpdatePolicy(PolicyEditViewModel model)
        {
            throw new NotImplementedException();
        }

    }
}
