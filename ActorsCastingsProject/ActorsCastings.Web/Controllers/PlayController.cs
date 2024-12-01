using Microsoft.AspNetCore.Mvc;

namespace ActorsCastings.Web.Controllers
{
    public class PlayController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
