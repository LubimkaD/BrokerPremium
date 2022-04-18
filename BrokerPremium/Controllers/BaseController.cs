using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BrokerPremium.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        
    }
}
