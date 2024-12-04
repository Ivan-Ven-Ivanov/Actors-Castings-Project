using ActorsCastings.Data.Models;
using ActorsCastings.Services.Data.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ActorsCastings.Web.Controllers
{
    public class ActorController : BaseController
    {
        private readonly IActorService _actorService;
        private readonly UserManager<ApplicationUser> _userManager;

        public ActorController(
            IActorService actorService,
            UserManager<ApplicationUser> userManager)
        {
            _actorService = actorService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var models = await _actorService.IndexGetAllActorsAsync();

            return View(models);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var model = await _actorService.GetActorDetailsByIdAsync(id);

            return View(model);
        }
    }
}
