using ActorsCastings.Services.Data.Interfaces;
using ActorsCastings.Web.ViewModels.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using static ActorsCastings.Common.ApplicationConstants;

namespace ActorsCastings.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = AdminRoleName)]
    [Area(AdminRoleName)]
    public class HomeController : Controller
    {
        private readonly IAdminService _adminService;

        public HomeController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
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
            bool result = await _adminService.ApproveElement(model);

            if (!result)
            {
                return View("Error");
            }

            return RedirectToAction("Index");
        }
    }
}
