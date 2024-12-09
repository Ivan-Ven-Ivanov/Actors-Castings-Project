using ActorsCastings.Data.Models;
using ActorsCastings.Services.Data.Interfaces;
using ActorsCastings.Web.ViewModels.CastingAgentProfile;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ActorsCastings.Web.Controllers
{
    [Authorize]
    public class CastingAgentProfileController : BaseController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ICastingAgentProfileService _castingAgentProfileService;

        public CastingAgentProfileController(
            UserManager<ApplicationUser> userManager,
            ICastingAgentProfileService castingAgentProfileService)
        {
            _userManager = userManager;
            _castingAgentProfileService = castingAgentProfileService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                string? userId = _userManager.GetUserId(User);
                CastingAgentProfileViewModel model = await _castingAgentProfileService.IndexGetMyProfileAsync(userId);

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
            var model = new CastingAgentProfileViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CompleteProfile(CastingAgentProfileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                string? userId = _userManager.GetUserId(User);
                await _castingAgentProfileService.CompleteCastingAgentProfileAsync(userId, model);

                return RedirectToAction("Index", "Home");
            }
            catch (ArgumentException aEx)
            {
                TempData["Error"] = aEx.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Update()
        {
            try
            {
                string? userId = _userManager.GetUserId(User);
                var model = await _castingAgentProfileService.GetCastingAgentProfileDataAsync(userId);

                return View(model);
            }
            catch (ArgumentException aEx)
            {
                TempData["Error"] = aEx.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCastingAgentProfileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _castingAgentProfileService.UpdateCastingAgentProfileAsync(model);

            return RedirectToAction("Index");
        }
    }
}
