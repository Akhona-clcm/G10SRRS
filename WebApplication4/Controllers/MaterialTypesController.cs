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
    public class MaterialTypesController : Controller
    {
        private HDBContext db = new HDBContext();

        // GET: MaterialTypes
        public ActionResult Index()
        {
            return View(db.materials.ToList());
        }

        // GET: MaterialTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaterialType materialType = db.materials.Find(id);
            if (materialType == null)
            {
                return HttpNotFound();
            }
            return View(materialType);
        }

        // GET: MaterialTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MaterialTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Material_ID,Material_Name")] MaterialType materialType)
        {
            if (ModelState.IsValid)
            {
                db.materials.Add(materialType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(materialType);
        }

        // GET: MaterialTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaterialType materialType = db.materials.Find(id);
            if (materialType == null)
            {
                return HttpNotFound();
            }
            return View(materialType);
        }

        // POST: MaterialTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Material_ID,Material_Name")] MaterialType materialType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(materialType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(materialType);
        }

        // GET: MaterialTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaterialType materialType = db.materials.Find(id);
            if (materialType == null)
            {
                return HttpNotFound();
            }
            return View(materialType);
        }

        // POST: MaterialTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MaterialType materialType = db.materials.Find(id);
            db.materials.Remove(materialType);
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
