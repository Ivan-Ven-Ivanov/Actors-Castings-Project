using ActorsCastings.Data.Models;
using ActorsCastings.Web.Data;
using ActorsCastings.Web.ViewModels.Actor;
using ActorsCastings.Web.ViewModels.ActorProfile;
using ActorsCastings.Web.ViewModels.Movie;
using ActorsCastings.Web.ViewModels.Play;
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

            await _context.Actors.AddAsync(actorProfile);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            bool isGuidValid = Guid.TryParse(id, out Guid actorId);

            if (!isGuidValid)
            {
                return RedirectToAction("Index");
            }

            Actor? actor = await _context.Actors
                .Include(a => a.ActorsMovies)
                    .ThenInclude(am => am.Movie)
                .Include(a => a.ActorsPlays)
                    .ThenInclude(ap => ap.Play)
                .FirstOrDefaultAsync(a => a.Id == actorId);

            if (actor == null)
            {
                return RedirectToAction("Index");
            }

            actor.ActorsMovies = actor.ActorsMovies.Where(am => am.IsApproved == true).ToList();
            actor.ActorsPlays = actor.ActorsPlays.Where(ap => ap.IsApproved == true).ToList();

            ActorDetailsViewModel model = new ActorDetailsViewModel
            {
                FirstName = actor.FirstName,
                LastName = actor.LastName,
                Age = actor.Age.ToString(),
                Biography = actor.Biography,
                ProfilePictureUrl = actor.ProfilePictureUrl,
                Movies = actor.ActorsMovies.Select(am => new MovieViewModel
                {
                    Id = am.Movie.Id.ToString(),
                    Title = am.Movie.Title,
                    Director = am.Movie.Director,
                    ImageUrl = am.Movie.ImageUrl,
                    ReleaseYear = am.Movie.ReleaseYear.ToString()
                })
                .ToList(),
                Plays = actor.ActorsPlays.Select(ap => new PlayViewModel
                {
                    Id = ap.Play.Id.ToString(),
                    Title = ap.Play.Title,
                    Director = ap.Play.Director,
                    ImageUrl = ap.Play.ImageUrl,
                    ReleaseYear = ap.Play.ReleaseYear.ToString()
                })
                .ToList()
            };

            return View(model);
        }
    }
}
