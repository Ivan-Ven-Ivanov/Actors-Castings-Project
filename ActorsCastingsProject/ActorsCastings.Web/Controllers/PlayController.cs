using ActorsCastings.Services.Data.Interfaces;
using ActorsCastings.Web.ViewModels.Play;
using Microsoft.AspNetCore.Mvc;

namespace ActorsCastings.Web.Controllers
{
    public class PlayController : Controller
    {
        private readonly IPlayService _playService;

        public PlayController(IPlayService playService)
        {
            _playService = playService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<PlayViewModel> models = await _playService.IndexGetAllPlaysAsync();

            return View(models);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            PlayDetailsViewModel model = await _playService.GetPlayDetailsAsync(id);

            return View(model);
        }
    }
}
