using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IndoOriginal.Models;
using Microsoft.AspNet.Identity;

namespace IndoOriginal.Controllers
{
    [Authorize]
    public class StaffController : Controller
    {
        private IndoOriginal_ModelContainer db = new IndoOriginal_ModelContainer();
        // GET: Staff
        public ActionResult Index()
        {
            string currentUserId = User.Identity.GetUserId();
            return View();
        }
    }
}