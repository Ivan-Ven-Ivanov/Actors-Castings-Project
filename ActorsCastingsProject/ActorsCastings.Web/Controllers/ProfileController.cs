using Microsoft.AspNetCore.Mvc;

namespace ActorsCastings.Web.Controllers
{
    public class ProfileController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
