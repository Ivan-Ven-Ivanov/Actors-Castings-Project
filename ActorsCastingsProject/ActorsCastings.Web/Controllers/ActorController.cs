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
        public async Task<IActionResult> Index(int page = FirstPageValue, int pageSize = EntitiesPerPage)
        {
            var models = await _actorService.IndexGetPaginatedActorsAsync(page, pageSize);
            int actorsCount = await _actorService.GetActorCountAsync();

            var pagedModel = new PaginationViewModel<ActorIndexViewModel>
            {
                Items = models,
                TotalItems = actorsCount,
                CurrentPage = page,
                PageSize = pageSize
            };


            return View(pagedModel);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var model = await _actorService.GetActorDetailsByIdAsync(id);

            return View(model);
        }
    }
}
