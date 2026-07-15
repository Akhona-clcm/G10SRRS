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
    public class CollectionOfficersController : Controller
    {
        private HDBContext db = new HDBContext();

        // GET: CollectionOfficers
        public ActionResult Index()
        {
            return View(db.collectionOfficers.ToList());
        }

        // GET: CollectionOfficers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CollectionOfficer collectionOfficer = db.collectionOfficers.Find(id);
            if (collectionOfficer == null)
            {
                return HttpNotFound();
            }
            return View(collectionOfficer);
        }

        // GET: CollectionOfficers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CollectionOfficers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Officer_ID,Officer_Name,Officer_Surname,Officer_Email,Officer_PhoneNo,Officer_Area,Username,Password,Date_Registered,Collection_Status")] CollectionOfficer collectionOfficer)
        {
            if (ModelState.IsValid)
            {
                db.collectionOfficers.Add(collectionOfficer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(collectionOfficer);
        }

        // GET: CollectionOfficers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CollectionOfficer collectionOfficer = db.collectionOfficers.Find(id);
            if (collectionOfficer == null)
            {
                return HttpNotFound();
            }
            return View(collectionOfficer);
        }

        // POST: CollectionOfficers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Officer_ID,Officer_Name,Officer_Surname,Officer_Email,Officer_PhoneNo,Officer_Area,Username,Password,Date_Registered,Collection_Status")] CollectionOfficer collectionOfficer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(collectionOfficer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(collectionOfficer);
        }

        // GET: CollectionOfficers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CollectionOfficer collectionOfficer = db.collectionOfficers.Find(id);
            if (collectionOfficer == null)
            {
                return HttpNotFound();
            }
            return View(collectionOfficer);
        }

        // POST: CollectionOfficers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CollectionOfficer collectionOfficer = db.collectionOfficers.Find(id);
            db.collectionOfficers.Remove(collectionOfficer);
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
