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
    public class BranchTablesController : Controller
    {
        private IndoOriginal_ModelContainer db = new IndoOriginal_ModelContainer();

        // GET: BranchTables
        public ActionResult Index()
        {
            var branchTables = db.BranchTables.Include(b => b.Branch);
            return View(branchTables.ToList());
        }

        // GET: BranchTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BranchTable branchTable = db.BranchTables.Find(id);
            if (branchTable == null)
            {
                return HttpNotFound();
            }
            return View(branchTable);
        }

        // GET: BranchTables/Create
        public ActionResult Create()
        {
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "Name");
            return View();
        }

        // POST: BranchTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TableNo,Capacity,BranchId")] BranchTable branchTable)
        {
            if (ModelState.IsValid)
            {
                db.BranchTables.Add(branchTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BranchId = new SelectList(db.Branches, "Id", "Name", branchTable.BranchId);
            return View(branchTable);
        }

        // GET: BranchTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BranchTable branchTable = db.BranchTables.Find(id);
            if (branchTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "Name", branchTable.BranchId);
            return View(branchTable);
        }

        // POST: BranchTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TableNo,Capacity,BranchId")] BranchTable branchTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(branchTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "Name", branchTable.BranchId);
            return View(branchTable);
        }

        // GET: BranchTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BranchTable branchTable = db.BranchTables.Find(id);
            if (branchTable == null)
            {
                return HttpNotFound();
            }
            return View(branchTable);
        }

        // POST: BranchTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BranchTable branchTable = db.BranchTables.Find(id);
            db.BranchTables.Remove(branchTable);
            db.SaveChanges();
            return RedirectToAction("Index");
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
