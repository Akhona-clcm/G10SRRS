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
    public class CommunityRewardsController : Controller
    {
        private HDBContext db = new HDBContext();

        // GET: CommunityRewards
        public ActionResult Index()
        {
            return View(db.CommunityRewards.ToList());
        }

        // GET: CommunityRewards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommunityReward communityReward = db.CommunityRewards.Find(id);
            if (communityReward == null)
            {
                return HttpNotFound();
            }
            return View(communityReward);
        }

        // GET: CommunityRewards/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CommunityRewards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CommunityReward_ID,Community_Name,TargetWeight,Reward_Name,Approved")] CommunityReward communityReward)
        {
            if (ModelState.IsValid)
            {
                db.CommunityRewards.Add(communityReward);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(communityReward);
        }

        // GET: CommunityRewards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommunityReward communityReward = db.CommunityRewards.Find(id);
            if (communityReward == null)
            {
                return HttpNotFound();
            }
            return View(communityReward);
        }

        // POST: CommunityRewards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CommunityReward_ID,Community_Name,TargetWeight,Reward_Name,Approved")] CommunityReward communityReward)
        {
            if (ModelState.IsValid)
            {
                db.Entry(communityReward).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(communityReward);
        }

        // GET: CommunityRewards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommunityReward communityReward = db.CommunityRewards.Find(id);
            if (communityReward == null)
            {
                return HttpNotFound();
            }
            return View(communityReward);
        }

        // POST: CommunityRewards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CommunityReward communityReward = db.CommunityRewards.Find(id);
            db.CommunityRewards.Remove(communityReward);
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
