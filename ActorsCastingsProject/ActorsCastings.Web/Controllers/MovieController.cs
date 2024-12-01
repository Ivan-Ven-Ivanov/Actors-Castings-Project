using ActorsCastings.Services.Data.Interfaces;
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
            var models = await _movieService.IndexGetAllMoviesAsync();

            return View(models);
        }
    }
}
