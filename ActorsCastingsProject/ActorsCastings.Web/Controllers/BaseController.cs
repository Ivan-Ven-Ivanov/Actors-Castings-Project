using Microsoft.AspNetCore.Mvc;

namespace ActorsCastings.Web.Controllers
{
    public class BaseController : Controller
    {
        protected bool IsGuidValid(string? id, ref Guid guid)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return false;
            }

            bool isGuidValid = Guid.TryParse(id, out guid);
            if (!isGuidValid)
            {
                return false;
            }

            return true;
        }
    }
}
