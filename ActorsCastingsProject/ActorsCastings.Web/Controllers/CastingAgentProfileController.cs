using Microsoft.AspNetCore.Mvc;

namespace ActorsCastings.Web.Controllers
{
    public class CastingAgentProfileController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
