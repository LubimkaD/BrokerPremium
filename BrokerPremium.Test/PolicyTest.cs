using BrokerPremium.Core.Contracts;
using BrokerPremium.Core.Models;
using BrokerPremium.Core.Services;
using BrokerPremium.Infrastructure.Data.Models;
using BrokerPremium.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerPremium.Test
{
    public class PolicyTest
    {
        private ServiceProvider serviceProvider;
        private InMemoryDbContext dbContext;

        [SetUp]
        public async Task Setup()
        {
            dbContext = new InMemoryDbContext();
            var serviceCollection = new ServiceCollection();

            serviceProvider = serviceCollection
                .AddSingleton(sp => dbContext.CreateContext())
                .AddSingleton<IApplicationDbRepository, ApplicationDbRepository>()
                .AddSingleton<IPolicyService, PolicyService>()
                .AddSingleton<ICustomerService, CustomerService>()
                .BuildServiceProvider();

            var repo = serviceProvider.GetService<IApplicationDbRepository>();
            //await SeedDbTestCustomerAsync(repo);

        }

        [Test]
        public async Task AssertNewTestPolicyCreated()
        {
            var repo = serviceProvider.GetService<IApplicationDbRepository>();
            var service = serviceProvider.GetService<IPolicyService>();
            var newModelPolicy = new PolicyEditViewModel()
            {
                PolicyNumber = "12345",
                TypeOfInsuranceId = 1,
                DateValidFrom = DateTime.Today,
                DateValidTo = DateTime.Today.AddYears(1),
                InsSuma = 100,
                InsCommission = 10,
                InsurerId = 1
            };
            var service1 = serviceProvider.GetService<ICustomerService>();
            var newModelCustomer = new CustomerEditViewModel()
            {
                Identificator = "222",
                Name = "testName222",
                Address = "testAddress222",
                IsCompany = true,
                Email = "testEmail222",
                Telefon = "testTelefon222",
                DateValidFrom = System.DateTime.Today

            };
            Assert.IsTrue(await service1.AddNewCustomer(newModelCustomer));

            var customer = await repo.All<Customer>()
                .FirstOrDefaultAsync(c => c.Identificator == "111");
            if (customer != null)
            {
                newModelPolicy.CustomerId = customer.Id;
                Assert.IsTrue(await service.AddNewPolicy(newModelPolicy));
            }
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Dispose();
        }

    }
}
