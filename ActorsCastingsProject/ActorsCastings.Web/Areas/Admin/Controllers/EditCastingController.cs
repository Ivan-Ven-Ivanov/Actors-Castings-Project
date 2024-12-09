using ActorsCastings.Services.Data.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using static ActorsCastings.Common.ApplicationConstants;

namespace ActorsCastings.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = AdminRoleName)]
    [Area(AdminRoleName)]
    public class EditCastingController : Controller
    {
        private readonly IAdminService _adminService;

        public EditCastingController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var models = await _adminService.IndexViewAllCastingsForEditAsync();

            return View(models);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await _adminService.DeleteCastingAndItsCastedActorsByIdAsync(id);

                return RedirectToAction("Index");
            }
            catch (ArgumentException aEx)
            {
                TempData["Error"] = aEx.Message;
                return RedirectToAction("Index");
            }
        }
    }
}
