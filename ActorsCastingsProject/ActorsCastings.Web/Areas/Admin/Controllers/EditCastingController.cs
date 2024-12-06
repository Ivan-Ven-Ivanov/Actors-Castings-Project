﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using static ActorsCastings.Common.ApplicationConstants;

namespace ActorsCastings.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = AdminRoleName)]
    [Area(AdminRoleName)]
    public class EditCastingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
