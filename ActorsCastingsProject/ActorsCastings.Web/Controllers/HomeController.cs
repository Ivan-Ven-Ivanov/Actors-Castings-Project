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

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Error(int? statusCode = null)
        {


            ErrorViewModel model = new ErrorViewModel();

            if (!statusCode.HasValue)
            {
                return View("Error", model);
            }

            if (statusCode == 404)
            {
                return View("Error404");
            }
            else if (statusCode == 500)
            {
                return View("Error500");
            }

            return View("Error", model);
        }
    }
}
