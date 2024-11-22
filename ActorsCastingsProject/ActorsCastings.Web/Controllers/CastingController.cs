using ActorsCastings.Web.Data;
using ActorsCastings.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static ActorsCastings.Common.EntityValidationConstants.Casting;

namespace ActorsCastings.Web.Controllers
{
    public class CastingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CastingController(ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
