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
    public class HomeController : Controller
    {
        private IndoOriginal_ModelContainer db = new IndoOriginal_ModelContainer();

        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Message = new string[] { "Booking request have been submited", "success" };
            //var bookingRequests = db.BookingRequests.Include(b => b.Branch);
            //return View(bookingRequests.ToList());
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "Name");
            return View();
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
                return RedirectToAction("Index");
            }
            ViewBag.Message = new string[] { "Booking request have been submited", "success" };
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "Name", bookingRequest.BranchId);
            return View(bookingRequest);
        }
    }
}
