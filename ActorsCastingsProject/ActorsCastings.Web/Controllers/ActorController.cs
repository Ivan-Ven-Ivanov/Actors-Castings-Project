using ActorsCastings.Data.Models;
using ActorsCastings.Web.Data;
using ActorsCastings.Web.ViewModels;
using ActorsCastings.Web.ViewModels.Actor;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ActorsCastings.Web.Controllers
{
    public class ActorController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ActorController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<ActorIndexViewModel> models = await _context.Actors
                .Select(a => new ActorIndexViewModel
                {
                    Id = a.Id.ToString(),
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    ProfilePictureUrl = a.ProfilePictureUrl
                })
                .ToListAsync();

            return View(models);
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

            var actorProfile = new Actor()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Age = model.Age,
                ProfilePictureUrl = model.ProfilePictureUrl,
                Biography = model.Biography,
                UserId = currentUser.Id
            };


            currentUser.ActorProfileId = actorProfile.Id;

            await _context.Actors.AddAsync(actorProfile);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            bool isGuidValid = Guid.TryParse(id, out Guid castingId);

            if (!isGuidValid)
            {
                return RedirectToAction("Index");
            }

            Actor? actor = await _context.Actors.FindAsync(castingId);

            if (actor == null)
            {
                return RedirectToAction("Index");
            }

            ActorDetailsViewModel model = new ActorDetailsViewModel
            {
                FirstName = actor.FirstName,
                LastName = actor.LastName,
                Age = actor.Age.ToString(),
                Biography = actor.Biography,
                ProfilePictureUrl = actor.ProfilePictureUrl
            };

            return View(model);
        }
    }
}
