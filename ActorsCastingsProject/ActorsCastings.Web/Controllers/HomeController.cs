using ActorsCastings.Services.Data.Interfaces;
using ActorsCastings.Web.Models;
using ActorsCastings.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ActorsCastings.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISearchService _searchService;

        public HomeController(ILogger<HomeController> logger, ISearchService searchService)
        {
            _logger = logger;
            _searchService = searchService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
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

        [HttpGet]
        public async Task<IActionResult> Search(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                string referer = Request.Headers.Referer.ToString();

                return Redirect(referer);
            }

            SearchViewModel model = await _searchService.GetSearchResultsByQueryAsync(query);
            ViewData["query"] = query;

            return View(model);
        }
    }
}
