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
        public Task<bool> AddNewPolicy(PolicyEditViewModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PolicyListViewModel>> GetPolicies()
        {
            return await repo.All<InsurancePolicy>()
                .Select(x => new PolicyListViewModel()
                {
                    Id = x.Id,
                    PolicyNumber = x.PolicyNumber,
                    TypeOfInsuranceId = x.TypeOfInsuranceId,
                    TypeOfInsurance = x.TypeOfInsurance.Name.ToString(),
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

        public Task<bool> UpdatePolicy(PolicyEditViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
