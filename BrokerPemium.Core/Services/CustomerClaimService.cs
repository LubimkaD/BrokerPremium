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
    public class CustomerClaimService : ICustomerClaimService
    {
        private IApplicationDbRepository repo;

        public CustomerClaimService(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }
        public async Task CreateClaim(CustomerClaim customerClaim)
        {
            string customerIdentificator = customerClaim.Identificator?.Trim() ?? string.Empty;
            var customer = await repo.All<Customer>()
                .FirstOrDefaultAsync(c => c.Identificator == customerIdentificator);

            if (customer == null)
            {
                throw new ArgumentException("Unknown customer");
            }

            //var policy = await repo.All<InsurancePolicy>()
            //  .FirstOrDefaultAsync(p => p.CustomerId == customer.Id);

            //if (policy == null)
            //{
            //    throw new ArgumentException("Missing policy info");
            //}
            //var claims = policy.InsClaims;

            //var insObject = claims[0].ClaimedObjects.FirstOrDefault();
            //if (insObject == null)
            //{
            //    throw new ArgumentException("Missing insured object");
            //}

            //var claim = new Claim()
            //{
            //    PolicyNumber = policy.PolicyNumber,
            //    DateOfAccident = claims[0].DateOfAccident,
            //    ImageOfClaim = claims[0].ImageOfClaim,
            //    ClaimedObject = insObject

            //};

        }
    }
}
