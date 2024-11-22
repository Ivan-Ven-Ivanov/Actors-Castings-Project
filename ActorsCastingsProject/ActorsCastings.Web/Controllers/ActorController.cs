using ActorsCastings.Data.Models;
using ActorsCastings.Web.Data;
using ActorsCastings.Web.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ActorsCastings.Web.Controllers
{
    public class ActorController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ActorController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult CompleteProfile()
        {
            var model = new ActorProfileViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CompleteProfile(ActorProfileViewModel model)
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

            var actorProfile = new ActorProfile()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Age = model.Age,
                ProfilePictureUrl = model.ProfilePictureUrl,
                Portfolio = model.Portfolio,
                UserId = currentUser.Id
            };


            currentUser.ActorProfileId = actorProfile.Id;

            await _context.ActorProfiles.AddAsync(actorProfile);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
