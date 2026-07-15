using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class ResidentsController : Controller
    {
        private HDBContext db = new HDBContext();

        // GET: Residents
        public ActionResult Index()
        {
            var residents = db.Residents.Include(r => r.material);
            return View(residents.ToList());
        }

        // GET: Residents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Residents residents = db.Residents.Find(id);
            if (residents == null)
            {
                return HttpNotFound();
            }
            return View(residents);
        }

        // GET: Residents/Create
        public ActionResult Create()
        {
            ViewBag.Material_ID = new SelectList(db.materials, "Material_ID", "Material_Name");
            return View();
        }

        // POST: Residents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Resident_ID,Resident_Name,Resident_Surname,Resident_Email,Resident_Address,Resident_No,Material_ID,Material_Weight,RewardPoints,ReferralCode,ReferredBy,Community_Name,Region")] Residents residents)
        {
            if (ModelState.IsValid)
            {
                db.Residents.Add(residents);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Material_ID = new SelectList(db.materials, "Material_ID", "Material_Name", residents.Material_ID);
            return View(residents);
        }

        // GET: Residents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Residents residents = db.Residents.Find(id);
            if (residents == null)
            {
                return HttpNotFound();
            }
            ViewBag.Material_ID = new SelectList(db.materials, "Material_ID", "Material_Name", residents.Material_ID);
            return View(residents);
        }

        // POST: Residents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Resident_ID,Resident_Name,Resident_Surname,Resident_Email,Resident_Address,Resident_No,Material_ID,Material_Weight,RewardPoints,ReferralCode,ReferredBy,Community_Name,Region")] Residents residents)
        {
            if (ModelState.IsValid)
            {
                db.Entry(residents).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Material_ID = new SelectList(db.materials, "Material_ID", "Material_Name", residents.Material_ID);
            return View(residents);
        }

        // GET: Residents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Residents residents = db.Residents.Find(id);
            if (residents == null)
            {
                return HttpNotFound();
            }
            return View(residents);
        }

        // POST: Residents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Residents residents = db.Residents.Find(id);
            db.Residents.Remove(residents);
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
