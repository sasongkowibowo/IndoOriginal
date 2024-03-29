﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
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
            string userId = User.Identity.GetUserId();

            var employee = db.Employees.FirstOrDefault(e => e.LoginId.Equals(userId));

            if (employee == null)
            {
                return RedirectToAction("Create", "Employees");
            }
            else
            {
                string branch = db.Branches.Where(i => i.Id == employee.BranchId).Select(i => i.Name).SingleOrDefault();
                ViewBag.Branch = branch;
                return View(employee);
            }
        }
    }
}