using ActorsCastings.Data.Models;
using ActorsCastings.Web.Data;
using ActorsCastings.Web.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ActorsCastings.Web.Controllers
{
    public class CastingAgentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CastingAgentController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
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

            ApplicationUser? currentUser = await _userManager.GetUserAsync(User);

            if (currentUser == null)
            {
                return View("Error");
            }

            var castingAgentProfile = new CastingAgent()
            {
                Name = model.Name,
                CastingAgency = model.CastingAgency,
                UserId = currentUser.Id
            };


            currentUser.CastingAgentProfileId = castingAgentProfile.Id;

            await _context.CastingAgents.AddAsync(castingAgentProfile);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
