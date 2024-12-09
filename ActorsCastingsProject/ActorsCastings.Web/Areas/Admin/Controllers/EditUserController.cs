using ActorsCastings.Services.Data.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using static ActorsCastings.Common.ApplicationConstants;

namespace ActorsCastings.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = AdminRoleName)]
    [Area(AdminRoleName)]
    public class EditUserController : Controller
    {
        private readonly IAdminService _adminService;

        public EditUserController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var models = await _adminService.IndexViewAllUsersForEditAsync();

            return View(models);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await _adminService.DeleteUserAndItsConnectedEntitiesByIdAsync(id);

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
