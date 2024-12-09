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
            try
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
            catch (ArgumentOutOfRangeException ex)
            {
                TempData["Error"] = ex.ParamName;
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Details(string id)
        {
            try
            {
                MovieDetailsViewModel model = await _movieService.GetMovieDetailsAsync(id);

                return View(model);
            }
            catch (ArgumentException aEx)
            {
                TempData["Error"] = aEx.Message;
                return RedirectToAction("Index");
            }
            catch (KeyNotFoundException)
            {
                return RedirectToAction("Error", "Home", new { statusCode = 404 });
            }
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

            try
            {
                string? userId = _userManager.GetUserId(User);
                await _movieService.AddMovieAndRoleInItAsync(model, userId);

                return RedirectToAction("Index", "ActorProfile");
            }
            catch (ArgumentException aEx)
            {
                TempData["Error"] = aEx.Message;
                return RedirectToAction("Index");
            }
        }
    }
}
