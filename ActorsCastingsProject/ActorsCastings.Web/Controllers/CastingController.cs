﻿using ActorsCastings.Data.Models;
using ActorsCastings.Services.Data.Interfaces;
using ActorsCastings.Web.ViewModels;
using ActorsCastings.Web.ViewModels.Casting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static ActorsCastings.Common.ApplicationConstants;


namespace ActorsCastings.Web.Controllers
{
    public class CastingController : BaseController
    {
        private readonly ICastingService _castingService;
        private readonly UserManager<ApplicationUser> _userManager;

        public CastingController(ICastingService castingService, UserManager<ApplicationUser> userManager)
        {
            _castingService = castingService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int page = FirstPageValue, int pageSize = CastingsPerPage)
        {
            var models = await _castingService.IndexGetPaginatedCastingsAsync(page, pageSize);
            int castingsCount = await _castingService.GetCastingsCountAsync();


            var pagedModel = new PaginationViewModel<CastingViewModel>
            {
                Items = models,
                TotalItems = castingsCount,
                CurrentPage = page,
                PageSize = pageSize
            };

            return View(pagedModel);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Add()
        {
            return View(new AddCastingViewModel());
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(AddCastingViewModel model)
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

            bool result = await _castingService.AddCastingAsync(model, user.Id.ToString());
            if (!result)
            {
                return View("Error");
            }

            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            ApplicationUser? user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return View("Error");
            }

            CastingDetailsViewModel model
                = await _castingService.GetCastingDetailsByIdAsync(id, user.Id.ToString());

            return View(model);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Apply(string id)
        {
            ApplicationUser? user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return View("Error");
            }

            bool result = await _castingService.ApplyForCastingAsync(id, user.Id.ToString());

            if (!result)
            {
                //TODO:
                return View("Error");
            }

            return RedirectToAction("Index");
        }
    }
}
