using ActorsCastings.Data.Models;
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
            try
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
            catch (ArgumentOutOfRangeException ex)
            {
                TempData["Error"] = ex.ParamName;
                return RedirectToAction("Index");
            }
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

            try
            {
                string? userId = _userManager.GetUserId(User);
                await _castingService.AddCastingAsync(model, userId);

                return RedirectToAction("Index");
            }
            catch (ArgumentException aEx)
            {
                TempData["Error"] = aEx.Message;
                return RedirectToAction("Index");
            }
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            try
            {
                string? userId = _userManager.GetUserId(User);

                CastingDetailsViewModel model
                    = await _castingService.GetCastingDetailsByIdAsync(id, userId);

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

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Apply(string id)
        {
            try
            {
                string? userId = _userManager.GetUserId(User);
                await _castingService.ApplyForCastingAsync(id, userId);

                return RedirectToAction("Index");
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
    }
}
