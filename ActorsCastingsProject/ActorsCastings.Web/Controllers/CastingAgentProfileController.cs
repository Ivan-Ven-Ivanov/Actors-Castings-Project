using ActorsCastings.Data.Models;
using ActorsCastings.Services.Data.Interfaces;
using ActorsCastings.Web.ViewModels.CastingAgentProfile;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ActorsCastings.Web.Controllers
{
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
    }
}
