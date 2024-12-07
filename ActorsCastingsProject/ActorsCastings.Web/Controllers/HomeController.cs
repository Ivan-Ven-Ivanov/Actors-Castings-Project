using ActorsCastings.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ActorsCastings.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error(int? statusCode = null)
        {
            if (statusCode == 404)
            {
                return View("Error404");
            }
            else if (statusCode == 500 || !statusCode.HasValue)
            {
                return View("Error500");
            }

            ErrorViewModel model = new ErrorViewModel();

            return View("Error", model);
        }
    }
}
