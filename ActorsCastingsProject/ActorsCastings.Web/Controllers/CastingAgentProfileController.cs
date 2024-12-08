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
            ApplicationUser? user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return View("Error");
            }

            CastingAgentProfileViewModel model = await _castingAgentProfileService.IndexGetMyProfileAsync(user.Id.ToString());

            return View(model);
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

            string? userId = _userManager.GetUserId(User);

            bool result = await _castingAgentProfileService.CompleteCastingAgentProfileAsync(userId, model);

            if (!result)
            {
                return View("Error");
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Update()
        {
            string? userId = _userManager.GetUserId(User);

            if (userId == null)
            {
                return View("Error");
            }

            UpdateCastingAgentProfileViewModel model = await _castingAgentProfileService.GetCastingAgentProfileDataAsync(userId);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCastingAgentProfileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            bool hasUpdated = await _castingAgentProfileService.UpdateCastingAgentProfileAsync(model);

            if (!hasUpdated)
            {
                return View("Error");
            }

            return RedirectToAction("Index");
        }
    }
}
