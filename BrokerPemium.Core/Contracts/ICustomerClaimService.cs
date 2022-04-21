using BrokerPremium.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerPremium.Core.Contracts
{
    public interface ICustomerClaimService
    {
        Task CreateClaim(CustomerClaim customerClaim);
    }
}
