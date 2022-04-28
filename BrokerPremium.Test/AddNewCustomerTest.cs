using BrokerPremium.Core.Contracts;
using BrokerPremium.Core.Models;
using BrokerPremium.Core.Services;
using BrokerPremium.Infrastructure.Data.Models;
using BrokerPremium.Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System.Threading.Tasks;

namespace BrokerPremium.Test
{
    public class AddNewCustomerTest
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
                .AddSingleton<ICustomerService, CustomerService>()
                .BuildServiceProvider();

            var repo = serviceProvider.GetService<IApplicationDbRepository>();
            await SeedDbTestCustomerAsync(repo);

        }

        [Test]
        public async Task AssertNewTestCustomerCreated()
        {
            var service = serviceProvider.GetService<ICustomerService>();
            var newModelCustomer = new CustomerEditViewModel()
            {
                Identificator = "111",
                Name = "testName1",
                Address = "testAddress1",
                IsCompany = true,
                Email = "testEmail1",
                Telefon = "testTelefon1",
                DateValidFrom = System.DateTime.Today

            };
            Assert.IsTrue(await service.AddNewCustomer(newModelCustomer));
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Dispose();
        }

        private async Task SeedDbTestCustomerAsync(IApplicationDbRepository repo)
        {
            var myTestCustomer = new Customer()
            {
                Identificator = "123",
                Name = "testName",
                Address = "testAddress",
                IsCompany = true,
                Email = "testEmail",
                Telefon = "testTelefon",
                DateValidFrom = System.DateTime.Today

            };

            await repo.AddAsync<Customer>(myTestCustomer);
            await repo.SaveChangesAsync();
        }
    }
}