using ActorsCastings.Common;
using ActorsCastings.Data.Models;
using ActorsCastings.Web.Data;
using ActorsCastings.Web.ViewModels.Casting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using static ActorsCastings.Common.EntityValidationConstants.Casting;

namespace ActorsCastings.Web.Controllers
{
    public class CastingController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CastingController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<CastingViewModel> models = await _context.Castings
                .Select(c => new CastingViewModel
                {
                    Id = c.Id.ToString(),
                    Title = c.Title,
                    CastingEnd = c.CastingEnd.ToString(CastingCastingEndDateTimeFormatString)
                })
                .ToListAsync();

            return View(models);
        }

        [Authorize(Roles = "CastingAgent")]
        [HttpGet]
        public IActionResult Add()
        {
            return View(new AddCastingViewModel());
        }

        [Authorize(Roles = ApplicationRoles.CastingAgent)]
        [HttpPost]
        public async Task<IActionResult> Add(AddCastingViewModel model)
        {

            ApplicationUser? user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return View("Error");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            bool isDateCorrect = DateTime.TryParseExact(model.CastingEnd, CastingCastingEndDateTimeFormatString, CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime dateTime);

            if (!isDateCorrect)
            {
                return View(model);
            }
            //TODO: Fix
            Casting casting = new Casting()
            {
                Title = model.Title,
                Description = model.Description,
                CastingEnd = dateTime,
                CastingAgentId = (Guid)user.CastingAgentProfileId
            };

            await _context.Castings.AddAsync(casting);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(string id)
        {
            bool isGuidValid = Guid.TryParse(id, out Guid castingId);

            if (!isGuidValid)
            {
                return RedirectToAction("Index");
            }

            Casting? casting = await _context.Castings
                .Include(c => c.CastingAgent)
                .FirstOrDefaultAsync(c => c.Id == castingId);

            if (casting == null)
            {
                return NotFound();
            }

            CastingDetailsViewModel model = new CastingDetailsViewModel
            {
                Id = castingId.ToString(),
                Title = casting.Title,
                Description = casting.Description,
                CastingEnd = casting.CastingEnd.ToString(CastingCastingEndDateTimeFormatString),
                CastingAgent = casting.CastingAgent.Name
            };


            return View(model);
        }

        public async Task<IActionResult> Apply(string id)
        {
            bool isGuidValid = Guid.TryParse(id, out Guid castingId);

            if (!isGuidValid)
            {
                return RedirectToAction("Index");
            }

            Casting? casting = await _context.Castings
                .FindAsync(castingId);

            if (casting == null)
            {
                return NotFound();
            }

            ApplicationUser? user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound();
            }

            //TODO: Fix and add "You already applied for this casting"
            if (await _context.ActorsCastings.AnyAsync(ac => ac.ActorId == user.ActorProfileId && ac.CastingId == castingId))
            {
                return RedirectToAction("Index");
            }

            ActorCasting actorCasting = new ActorCasting
            {
                ActorId = (Guid)user.ActorProfileId,
                CastingId = castingId
            };

            await _context.ActorsCastings.AddAsync(actorCasting);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
