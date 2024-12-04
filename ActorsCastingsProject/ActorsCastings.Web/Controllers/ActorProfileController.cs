using ActorsCastings.Data.Models;
using ActorsCastings.Services.Data.Interfaces;
using ActorsCastings.Web.ViewModels.ActorProfile;
using ActorsCastings.Web.ViewModels.Movie;
using ActorsCastings.Web.ViewModels.Play;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ActorsCastings.Web.Controllers
{
    public class ActorProfileController : BaseController
    {
        private readonly IActorProfileService _actorProfileService;
        private readonly UserManager<ApplicationUser> _userManager;

        public ActorProfileController(
            IActorProfileService actorProfileService,
            UserManager<ApplicationUser> userManager)
        {
            _actorProfileService = actorProfileService;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            ApplicationUser? user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return View("Error");
            }

            ActorProfileViewModel model = await _actorProfileService.IndexGetMyProfileAsync(user.Id.ToString());

            return View(model);
        }

        [HttpGet]
        public IActionResult CompleteProfile()
        {
            var model = new ActorProfileViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CompleteProfile(ActorProfileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string? userId = _userManager.GetUserId(User);

            bool result = await _actorProfileService.CompleteActorProfileAsync(userId, model);

            if (!result)
            {
                return View("Error");
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> AddMovieFromProfile()
        {
            IEnumerable<MovieViewModel> models = await _actorProfileService.GetAllMoviesAsync();

            return View(models);
        }

        [HttpPost]
        public async Task<IActionResult> AddMovieFromProfile(SelectedMovieViewModel model)
        {
            if (model.Id == Guid.Empty)
            {
                return View("Error");
            }

            ApplicationUser? user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return View("Error");
            }

            bool result = await _actorProfileService.AddSelectedMovieToProfileAsync(model.Id, model.Role, user.Id.ToString());

            if (!result)
            {
                return View("Error");
            }

            return RedirectToAction("Index", "ActorProfile");
        }

        [HttpGet]
        public async Task<IActionResult> AddPlayFromProfile()
        {
            IEnumerable<PlayViewModel> models = await _actorProfileService.GetAllPlaysAsync();

            return View(models);
        }

        [HttpPost]
        public async Task<IActionResult> AddPlayFromProfile(SelectedPlayViewModel model)
        {
            if (model.Id == Guid.Empty)
            {
                return View("Error");
            }

            ApplicationUser? user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return View("Error");
            }

            bool result = await _actorProfileService.AddSelectedPlayToProfileAsync(model.Id, model.Role, user.Id.ToString());

            if (!result)
            {
                return View("Error");
            }

            return RedirectToAction("Index", "ActorProfile");
        }

        [HttpGet]
        public async Task<IActionResult> Update()
        {
            string? userId = _userManager.GetUserId(User);

            if (userId == null)
            {
                return View("Error");
            }

            UpdateActorProfileViewModel model = await _actorProfileService.GetActorProfileDataAsync(userId);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateActorProfileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            bool hasUpdated = await _actorProfileService.UpdateActorProfileAsync(model);

            if (!hasUpdated)
            {
                return View("Error");
            }

            return RedirectToAction("Index");
        }
    }
}
