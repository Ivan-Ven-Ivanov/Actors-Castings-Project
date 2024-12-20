﻿using ActorsCastings.Data.Models;
using ActorsCastings.Services.Data.Interfaces;
using ActorsCastings.Web.ViewModels;
using ActorsCastings.Web.ViewModels.Play;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using static ActorsCastings.Common.ApplicationConstants;


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
        public async Task<IActionResult> Index(int page = FirstPageValue, int pageSize = PlaysPerPage)
        {
            try
            {
                var models = await _playService.IndexGetPaginatedPlaysAsync(page, pageSize);
                int playsCount = await _playService.GetPlaysCountAsync();

                var pagedModel = new PaginationViewModel<PlayViewModel>
                {
                    Items = models,
                    TotalItems = playsCount,
                    CurrentPage = page,
                    PageSize = pageSize
                };

                return View(pagedModel);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                TempData["Error"] = ex.ParamName;
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Details(string id)
        {
            try
            {
                PlayDetailsViewModel model = await _playService.GetPlayDetailsAsync(id);

                return View(model);
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

            try
            {
                string? userId = _userManager.GetUserId(User);
                await _playService.AddPlayAndRoleInItAsync(model, userId);

                return RedirectToAction("Index", "ActorProfile");
            }
            catch (ArgumentException aEx)
            {
                TempData["Error"] = aEx.Message;
                return RedirectToAction("Index");
            }
        }
    }
}
