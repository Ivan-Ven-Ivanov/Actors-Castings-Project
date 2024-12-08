using ActorsCastings.Data.Models;
using ActorsCastings.Services.Data.Interfaces;
using ActorsCastings.Web.ViewModels;
using ActorsCastings.Web.ViewModels.Movie;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using static ActorsCastings.Common.ApplicationConstants;

namespace ActorsCastings.Web.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly UserManager<ApplicationUser> _userManager;

        public MovieController(IMovieService movieService, UserManager<ApplicationUser> userManager)
        {
            _movieService = movieService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int page = FirstPageValue, int pageSize = MoviesPerPage)
        {
            var models = await _movieService.IndexGetPaginatedMoviesAsync(page, pageSize);
            int moviesCount = await _movieService.GetMoviesCountAsync();

            var pagedModel = new PaginationViewModel<MovieViewModel>
            {
                Items = models,
                TotalItems = moviesCount,
                CurrentPage = page,
                PageSize = pageSize
            };


            return View(pagedModel);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Details(string id)
        {
            MovieDetailsViewModel model = await _movieService.GetMovieDetailsAsync(id);

            return View(model);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Add()
        {
            AddMovieViewModel model = new AddMovieViewModel();

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(AddMovieViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            ApplicationUser? user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return View("Error");
            }

            await _movieService.AddMovieAndRoleInItAsync(model, user.Id.ToString());

            return RedirectToAction("Index", "ActorProfile");
        }

    }
}
