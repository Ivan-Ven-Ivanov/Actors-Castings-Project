using ActorsCastings.Data.Models;
using ActorsCastings.Services.Data.Interfaces;
using ActorsCastings.Web.ViewModels;
using ActorsCastings.Web.ViewModels.Actor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using static ActorsCastings.Common.ApplicationConstants;

namespace ActorsCastings.Web.Controllers
{
    public class ActorController : Controller
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
        public async Task<IActionResult> Index(int page = FirstPageValue, int pageSize = ActorsPerPage)
        {
            try
            {
                var models = await _actorService.IndexGetPaginatedActorsAsync(page, pageSize);
                int actorsCount = await _actorService.GetActorsCountAsync();

                var pagedModel = new PaginationViewModel<ActorIndexViewModel>
                {
                    Items = models,
                    TotalItems = actorsCount,
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

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            try
            {
                var model = await _actorService.GetActorDetailsByIdAsync(id);

                return View(model);
            }
            catch (ArgumentException aEx)
            {
                TempData["Error"] = aEx.Message;
                return RedirectToAction("Index");
            }
            catch (KeyNotFoundException)
            {
                //TODO: Logging
                return RedirectToAction("Error", "Home", new { statusCode = 404 });
            }
        }
    }
}
