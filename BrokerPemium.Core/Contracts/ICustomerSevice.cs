using BrokerPremium.Core.Models;
using BrokerPremium.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerPremium.Core.Contracts
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerListViewModel>> GetCustomers();

        Task<Customer> GetCustomerForEdit(string id);

        Task<bool> UpdateCustomer(CustomerEditViewModel model);

        Task<bool> AddNewCustomer(CustomerEditViewModel model);
    }
}
