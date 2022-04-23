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

        public async Task<Customer> GetCustomerForEdit(string id)
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

        public Task<bool> UpdateCustomer(CustomerEditViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
