using ActorsCastings.Services.Data.Interfaces;
using ActorsCastings.Web.ViewModels.Movie;
using Microsoft.AspNetCore.Mvc;

namespace ActorsCastings.Web.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<MovieViewModel> models = await _movieService.IndexGetAllMoviesAsync();

            return View(models);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            MovieDetailsViewModel model = await _movieService.GetMovieDetailsAsync(id);

            return View(model);
        }
    }
}
