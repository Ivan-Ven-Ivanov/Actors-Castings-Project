using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using static ActorsCastings.Common.ApplicationConstants;

namespace ActorsCastings.Web.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        [Authorize(Roles = AdminRoleName)]
        [Area(AdminRoleName)]
        public IActionResult Index()
        {
            return View();
        }
    }
}
