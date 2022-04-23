using Microsoft.AspNetCore.Mvc;

namespace BrokerPremium.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
