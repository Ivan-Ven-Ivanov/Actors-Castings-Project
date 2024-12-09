using ActorsCastings.Services.Data.Interfaces;
using ActorsCastings.Web.ViewModels.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using static ActorsCastings.Common.ApplicationConstants;

namespace ActorsCastings.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = AdminRoleName)]
    [Area(AdminRoleName)]
    public class ApprovalController : Controller
    {
        private readonly IAdminService _adminService;

        public ApprovalController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        public async Task<IActionResult> Approve()
        {
            DataToApproveViewModel model = await _adminService.GetAllNotApprovedElements();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Approve(ApproveSubmitViewModel model)
        {
            try
            {
                await _adminService.ApproveElement(model);

                return RedirectToAction("Approve");
            }
            catch (ArgumentException aEx)
            {
                TempData["Error"] = aEx.Message;
                return RedirectToAction("Approve");
            }
        }
    }
}
