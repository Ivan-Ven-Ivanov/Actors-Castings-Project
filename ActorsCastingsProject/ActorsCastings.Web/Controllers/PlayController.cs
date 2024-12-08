using ActorsCastings.Data.Models;
using ActorsCastings.Services.Data.Interfaces;
using ActorsCastings.Web.ViewModels.Play;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ActorsCastings.Web.Controllers
{
    public class PlayController : Controller
    {
        private readonly IPlayService _playService;
        private readonly UserManager<ApplicationUser> _userManager;

        public PlayController(IPlayService playService, UserManager<ApplicationUser> userManager)
        {
            _playService = playService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<PlayViewModel> models = await _playService.IndexGetAllPlaysAsync();

            return View(models);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Details(string id)
        {
            PlayDetailsViewModel model = await _playService.GetPlayDetailsAsync(id);

            return View(model);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Add()
        {
            AddPlayViewModel model = new AddPlayViewModel();

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(AddPlayViewModel model)
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

            await _playService.AddPlayAndRoleInItAsync(model, user.Id.ToString());

            return RedirectToAction("Index", "ActorProfile");
        }
    }
}
