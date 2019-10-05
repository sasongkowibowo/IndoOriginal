using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IndoOriginal.Models;
using Microsoft.AspNet.Identity;

namespace IndoOriginal.Controllers
{
    [Authorize(Roles = "Manager,Staff" )]
    public class ManageBookingController : Controller
    {
        private IndoOriginal_ModelContainer db = new IndoOriginal_ModelContainer();

        // GET: ManageBooking
        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();
            int branchId = db.Employees.Where(i => i.LoginId.Equals(userId)).Select(i => i.BranchId).SingleOrDefault();
            var bookingRequests = db.Database.SqlQuery<BookingRequest>("SELECT * FROM dbo.BookingRequests WHERE" +
                " dbo.BookingRequests.BranchId =" +branchId+ " AND (dbo.BookingRequests.BookingStatus IS null OR" +
                " dbo.BookingRequests.BookingStatus = 2)");

            return View(bookingRequests.OrderBy(d => d.Date).ToList());
        }

        // GET: ManageBooking/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingRequest bookingRequest = db.BookingRequests.Find(id);
            if (bookingRequest == null)
            {
                return HttpNotFound();
            }

            string query = "SELECT * FROM dbo.BranchTables WHERE " +
                "dbo.BranchTables.Id NOT IN (SELECT dbo.BookingRequests.BranchTableId FROM dbo.BookingRequests " +
                "WHERE " +
                "dbo.BookingRequests.Date = '" + bookingRequest.Date.ToString("yyyy-MM-dd") +
                "' AND dbo.BookingRequests.RealTimeStart <=" + bookingRequest.Time +
                " AND dbo.BookingRequests.RealTimeEnd >" + bookingRequest.Time +
                " AND dbo.BookingRequests.BranchId =" + bookingRequest.BranchId + 
                " AND dbo.BookingRequests.BookingStatus = 1)" +
                " AND dbo.BranchTables.BranchId = " + bookingRequest.BranchId;

            var availTable = db.Database.SqlQuery<BranchTable>(query).ToList();

            ViewBag.AvailTable = availTable;
            return View(bookingRequest);
        }

        // POST: ManageBooking/Details/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Details(int Id, int Time, int table)
        {
            BookingRequest bookingRequest = db.BookingRequests.Find(Id);
            if (ModelState.IsValid)
            {
                bookingRequest.RealTimeStart = Time;
                bookingRequest.RealTimeEnd = Time + 200;
                bookingRequest.BookingStatus = 1;
                bookingRequest.BranchTableId = table;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookingRequest);
        }

        // GET: ScheduledBookings
        public ActionResult ScheduledBookings()
        {
            string userId = User.Identity.GetUserId();
            int branchId = db.Employees.Where(i => i.LoginId.Equals(userId)).Select(i => i.BranchId).SingleOrDefault();
            //var bookingRequests = db.Database.SqlQuery<BookingRequest>("SELECT * FROM dbo.BookingRequests WHERE" +
            //    " dbo.BookingRequests.BranchId =" + branchId + " AND dbo.BookingRequests.BookingStatus = 1");

            var scheduledBookings = db.Database.SqlQuery<ScheduledBooking>("SELECT a.Id, a.Date, a.Time, a.TransactionDate," +
                " a.Note, a.Persons, a.Email, a.FullName, a.Telephone, a.BranchId, a.RealTimeStart, a.RealTimeEnd, " +
                " a.BranchTableId, b.TableNo," +
                " b.Capacity FROM dbo.BookingRequests a JOIN dbo.BranchTables b ON a.BranchTableId = b.Id WHERE" +
                " a.BookingStatus = 1 AND a.BranchId =" +branchId);
            return View(scheduledBookings.OrderBy(d => d.Date).ToList());
        }

        // GET: CancelledBookings
        public ActionResult CancelledBookings()
        {
            string userId = User.Identity.GetUserId();
            int branchId = db.Employees.Where(i => i.LoginId.Equals(userId)).Select(i => i.BranchId).SingleOrDefault();
            var bookingRequests = db.Database.SqlQuery<BookingRequest>("SELECT * FROM dbo.BookingRequests WHERE" +
                " dbo.BookingRequests.BranchId =" + branchId + " AND dbo.BookingRequests.BookingStatus = 3");

            return View(bookingRequests.OrderBy(d => d.Date).ToList());
        }

        // GET: FinishedBookings
        public ActionResult FinishedBookings()
        {
            string userId = User.Identity.GetUserId();
            int branchId = db.Employees.Where(i => i.LoginId.Equals(userId)).Select(i => i.BranchId).SingleOrDefault();
            var bookingRequests = db.Database.SqlQuery<BookingRequest>("SELECT * FROM dbo.BookingRequests WHERE" +
                " dbo.BookingRequests.BranchId =" + branchId + " AND dbo.BookingRequests.BookingStatus = 4");

            return View(bookingRequests.OrderBy(d => d.Date).ToList());
        }

        // POST: ManageBooking/ScheduledBookings/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ScheduledBookings(int Id, int flag)
        {
            BookingRequest bookingRequest = db.BookingRequests.Find(Id);
            if (ModelState.IsValid)
            {
                bookingRequest.BookingStatus = flag;
                db.SaveChanges();
                return RedirectToAction("ScheduledBookings");
            }
            return View(bookingRequest);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
