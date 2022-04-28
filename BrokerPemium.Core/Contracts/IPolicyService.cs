using BrokerPremium.Core.Models;
using BrokerPremium.Infrastructure.Data.Models;

namespace BrokerPremium.Core.Contracts
{
    public interface IPolicyService
    {
        Task<IEnumerable<PolicyListViewModel>> GetPolicies();

        Task<InsurancePolicy> GetPolicyForEdit(Guid id);

        Task<bool> UpdatePolicy(PolicyEditViewModel model);

        Task<bool> AddNewPolicy(PolicyEditViewModel model);

        Task<IEnumerable<TypeOfInsuranceViewModel>> GetTypeOfInsurances();

        Task<IEnumerable<InsurerViewModel>> GetInsurers();

        Task<IEnumerable<CustomerViewModel>> GetCustomers();
    }
}
