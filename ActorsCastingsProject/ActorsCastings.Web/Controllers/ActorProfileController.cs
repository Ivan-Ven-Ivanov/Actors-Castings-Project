using Microsoft.AspNetCore.Mvc;

namespace ActorsCastings.Web.Controllers
{
    public class ActorProfileController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
