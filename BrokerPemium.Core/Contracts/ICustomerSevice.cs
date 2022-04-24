using BrokerPremium.Core.Models;
using BrokerPremium.Infrastructure.Data.Models;

namespace BrokerPremium.Core.Contracts
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerListViewModel>> GetCustomers();

        Task<Customer> GetCustomerForEdit(Guid id);

        Task<bool> UpdateCustomer(CustomerEditViewModel model);

        Task<bool> AddNewCustomer(CustomerEditViewModel model);
    }
}
