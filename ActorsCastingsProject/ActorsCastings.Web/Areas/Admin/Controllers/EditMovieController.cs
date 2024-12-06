using ActorsCastings.Services.Data.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using static ActorsCastings.Common.ApplicationConstants;

namespace ActorsCastings.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = AdminRoleName)]
    [Area(AdminRoleName)]
    public class EditMovieController : Controller
    {
        private readonly IAdminService _adminService;

        public EditMovieController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var models = await _adminService.IndexViewAllMoviesForEditAsync();

            return View(models);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            bool result = await _adminService.DeleteMovieByIdAsync(id);

            return RedirectToAction("Index");
        }
    }
}
