using ActorsCastings.Data.Models;
using ActorsCastings.Web.Data;
using ActorsCastings.Web.ViewModels;
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
                    Description = c.Description,
                    CastingEnd = c.CastingEnd.ToString(CastingCastingEndDateTimeFormatString),
                    CastingAgentId = c.CastingAgentId.ToString()
                })
                .ToListAsync();

            return View(models);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new CastingViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Add(CastingViewModel model)
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

            Casting casting = new Casting()
            {
                Title = model.Title,
                Description = model.Description,
                CastingEnd = dateTime,
                CastingAgent = user.CastingAgentProfile
            };

            await _context.Castings.AddAsync(casting);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
