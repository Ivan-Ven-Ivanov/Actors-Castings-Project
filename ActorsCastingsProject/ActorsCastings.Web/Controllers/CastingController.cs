using ActorsCastings.Common;
using ActorsCastings.Data.Models;
using ActorsCastings.Services.Data.Interfaces;
using ActorsCastings.Web.Data;
using ActorsCastings.Web.ViewModels.Casting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ActorsCastings.Web.Controllers
{
    public class CastingController : BaseController
    {
        private readonly ApplicationDbContext _context; //TODO: Remove
        private readonly ICastingService _castingService;
        private readonly UserManager<ApplicationUser> _userManager;

        public CastingController(ApplicationDbContext context, ICastingService castingService, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _castingService = castingService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<CastingViewModel> models = await _castingService
                .IndexGetAllAsync();

            return View(models);
        }

        [Authorize(Roles = "CastingAgent")]
        [HttpGet]
        public IActionResult Add()
        {
            return View(new AddCastingViewModel());
        }

        [Authorize(Roles = ProfileTypes.CastingAgent)]
        [HttpPost]
        public async Task<IActionResult> Add(AddCastingViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            bool result = await _castingService.AddCastingAsync(model, User);
            if (!result)
            {
                return View("Error");
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(string id)
        {
            CastingDetailsViewModel model
                = await _castingService.GetCastingDetailsByIdAsync(id, User);

            return View(model);
        }

        public async Task<IActionResult> Apply(string id)
        {
            bool result = await _castingService.ApplyForCastingAsync(id, User);

            if (!result)
            {
                //TODO:
                return RedirectToAction("Error");
            }

            return RedirectToAction("Index");
        }
    }
}
