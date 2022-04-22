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

            var policy = await repo.All<InsurancePolicy>()
              .FirstOrDefaultAsync(p => p.CustomerId == customer.Id);

            if (policy == null)
            {
                throw new ArgumentException("Missing policy info");
            }
            //var claims = policy.InsClaims;

            //var insObject = customerClaim.Claim.ClaimedObject.TypeOfObjectId;
            
            if (customerClaim.Claim.DateOfAccident < policy.DateValidFrom || customerClaim.Claim.DateOfAccident > policy.DateValidTo)
            {
                throw new ArgumentException("Invalid date of accident");
            }

            var insClaimRecord = new InsuranceClaim()
            {
                ClaimNumber = policy.PolicyNumber + (policy.InsClaims.Count + 1).ToString(),
                PolicyNumber = policy.PolicyNumber,
                StatusId = 1,
                ClaimSum = 0,
                ClaimCommission = 0,
                DateOfAccident = customerClaim.Claim.DateOfAccident,
                ImageOfClaim = customerClaim.Claim.ImageOfClaim
            };
            insClaimRecord.ClaimedObjects.Add(customerClaim.Claim.ClaimedObject);

            await repo.AddAsync<InsuranceClaim>(insClaimRecord);

            int typeOfObjectId = 1;
            if (customerClaim.Claim.ClaimedObject.TypeOfObjectId == '1')
            {
                typeOfObjectId = 1;
            }
            var insObjectRecord = new InsuredObject()
            {
                TypeOfObjectId = customerClaim.Claim.ClaimedObject.TypeOfObjectId,
                Description = customerClaim.Claim.ClaimedObject.Description,
                Image = customerClaim.Claim.ImageOfClaim
            };

            await repo.AddAsync<InsuredObject>(insObjectRecord);
            policy.InsClaims.Add(insClaimRecord);
            repo.Update<InsurancePolicy>(policy);
            await repo.SaveChangesAsync();
        }
    }
}
