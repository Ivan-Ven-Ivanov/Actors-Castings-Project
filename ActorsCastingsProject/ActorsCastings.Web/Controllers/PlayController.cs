using ActorsCastings.Services.Data.Interfaces;
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
            var models = await _playService.IndexGetAllPlaysAsync();

            return View(models);
        }
    }
}
