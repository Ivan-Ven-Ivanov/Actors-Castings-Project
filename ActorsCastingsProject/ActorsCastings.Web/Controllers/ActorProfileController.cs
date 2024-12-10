using ActorsCastings.Data.Models;
using ActorsCastings.Services.Data.Interfaces;
using ActorsCastings.Web.ViewModels.ActorProfile;
using ActorsCastings.Web.ViewModels.Movie;
using ActorsCastings.Web.ViewModels.Play;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ActorsCastings.Web.Controllers
{
    [Authorize]
    public class ActorProfileController : Controller
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
            try
            {
                string? userId = _userManager.GetUserId(User);
                ActorProfileViewModel model = await _actorProfileService.IndexGetMyProfileAsync(userId);

                return View(model);
            }
            catch (ArgumentException aEx)
            {
                TempData["Error"] = aEx.Message;
                return RedirectToAction("Index");
            }
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

            try
            {
                string? userId = _userManager.GetUserId(User);
                await _actorProfileService.CompleteActorProfileAsync(userId, model);

                return RedirectToAction("Index", "Home");
            }
            catch (ArgumentException aEx)
            {
                TempData["Error"] = aEx.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public async Task<IActionResult> AddMovieFromProfile()
        {
            SelectedMovieViewModel model = new SelectedMovieViewModel();
            model = await _actorProfileService.GetAllMoviesForSelectAsync(model);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddMovieFromProfile(SelectedMovieViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model = await _actorProfileService.GetAllMoviesForSelectAsync(model);
                model = _actorProfileService.SelectAMovieForValidation(model);

                return View(model);
            }

            try
            {
                string? userId = _userManager.GetUserId(User);
                await _actorProfileService.AddSelectedMovieToProfileAsync(model.Id, model.Role, userId);

                return RedirectToAction("Index", "ActorProfile");
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
        public async Task<IActionResult> AddPlayFromProfile()
        {
            SelectedPlayViewModel model = new SelectedPlayViewModel();
            model = await _actorProfileService.GetAllPlaysForSelectAsync(model);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddPlayFromProfile(SelectedPlayViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model = await _actorProfileService.GetAllPlaysForSelectAsync(model);
                model = _actorProfileService.SelectAPlayForValidation(model);

                return View(model);
            }

            try
            {
                string? userId = _userManager.GetUserId(User);
                await _actorProfileService.AddSelectedPlayToProfileAsync(model.Id, model.Role, userId);

                return RedirectToAction("Index", "ActorProfile");
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
        public async Task<IActionResult> Update()
        {
            try
            {
                string? userId = _userManager.GetUserId(User);
                UpdateActorProfileViewModel model = await _actorProfileService.GetActorProfileDataForUpdateAsync(userId);

                return View(model);
            }
            catch (ArgumentException aEx)
            {
                TempData["Error"] = aEx.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateActorProfileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _actorProfileService.UpdateActorProfileAsync(model);

            return RedirectToAction("Index");
        }
    }
}
