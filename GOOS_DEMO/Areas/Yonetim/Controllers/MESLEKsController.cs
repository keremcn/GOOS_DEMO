using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GOOS_DEMO.Models;

namespace GOOS_DEMO.Areas.Yonetim.Controllers
{
    public class MESLEKsController : Controller
    {
        private AppDBContext db = new AppDBContext();

        // GET: Yonetim/MESLEKs
        public ActionResult Index()
        {
            return View(db.MESLEKs.ToList());
        }

        // GET: Yonetim/MESLEKs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MESLEK mESLEK = db.MESLEKs.Find(id);
            if (mESLEK == null)
            {
                return HttpNotFound();
            }
            return View(mESLEK);
        }

        // GET: Yonetim/MESLEKs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Yonetim/MESLEKs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "M_ID,M_ADI")] MESLEK mESLEK)
        {
            if (ModelState.IsValid)
            {
                db.MESLEKs.Add(mESLEK);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mESLEK);
        }

        // GET: Yonetim/MESLEKs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MESLEK mESLEK = db.MESLEKs.Find(id);
            if (mESLEK == null)
            {
                return HttpNotFound();
            }
            return View(mESLEK);
        }

        // POST: Yonetim/MESLEKs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "M_ID,M_ADI")] MESLEK mESLEK)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mESLEK).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mESLEK);
        }

        // GET: Yonetim/MESLEKs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MESLEK mESLEK = db.MESLEKs.Find(id);
            if (mESLEK == null)
            {
                return HttpNotFound();
            }
            return View(mESLEK);
        }

        // POST: Yonetim/MESLEKs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MESLEK mESLEK = db.MESLEKs.Find(id);
            db.MESLEKs.Remove(mESLEK);
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
