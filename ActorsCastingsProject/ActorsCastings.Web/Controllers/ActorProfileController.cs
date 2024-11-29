﻿using ActorsCastings.Data.Models;
using ActorsCastings.Services.Data.Interfaces;
using ActorsCastings.Web.ViewModels.ActorProfile;
using ActorsCastings.Web.ViewModels.Movie;
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

        public async Task<IActionResult> AddMovieFromProfile()
        {
            IEnumerable<MovieViewModel> models = await _actorProfileService.GetAllMoviesAsync();

            return View(models);
        }
    }
}
