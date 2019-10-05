using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IndoOriginal.Models;

namespace IndoOriginal.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        private IndoOriginal_ModelContainer db = new IndoOriginal_ModelContainer();

        // GET: Home
        public ActionResult Index(string message = null)
        {
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Staff");
            }
            else
            {
                if (message != null)
                {
                    ViewBag.Message = new string[] { "Booking request has been submited", "success" };
                }
                ViewBag.BranchId = new SelectList(db.Branches, "Id", "Name");
                var menus = db.Menus.ToList();
                ViewBag.Menus = menus;
               
                return View();
            }
        }

        // POST: Home/Index
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "Id,Date,Time,Note,Persons,Email,FullName,Telephone,WaitingList,BranchId")] BookingRequest bookingRequest)
        {
            if (ModelState.IsValid)
            {
                bookingRequest.TransactionDate = DateTime.Now;
                db.BookingRequests.Add(bookingRequest);
                db.SaveChanges();
                return RedirectToAction("Index", new { message = 1});
            }
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "Name", bookingRequest.BranchId);
            return View(bookingRequest);
        }
    }
}
