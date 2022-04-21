using BrokerPremium.Core.Contracts;
using BrokerPremium.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BrokerPremium.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimController : ControllerBase
    {
        private readonly ICustomerClaimService service;

        public ClaimController(ICustomerClaimService _service)
        {
            service = _service;
        }

        [HttpPost]
        [Route("create")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateClaim(CustomerClaim customerClaim)
        {
            try
            {
                await service.CreateClaim(customerClaim);
            }
            catch (ArgumentException ae)
            {

                return BadRequest(ae.Message);
            }

            return Ok();
        }
    }
}
