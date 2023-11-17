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
    public class KULLANICIsController : Controller
    {
        private AppDBContext db = new AppDBContext();

        // GET: Yonetim/KULLANICIs
        public ActionResult Index()
        {
            var kULLANICIs = db.KULLANICIs.Include(k => k.KULLANICI_TURU);
            return View(kULLANICIs.ToList());
        }

        // GET: Yonetim/KULLANICIs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KULLANICI kULLANICI = db.KULLANICIs.Find(id);
            if (kULLANICI == null)
            {
                return HttpNotFound();
            }
            return View(kULLANICI);
        }

        // GET: Yonetim/KULLANICIs/Create
        public ActionResult Create()
        {
            ViewBag.K_TURU_ID = new SelectList(db.KULLANICI_TURU, "KT_ID", "KT_ADI");
            return View();
        }

        // POST: Yonetim/KULLANICIs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "K_ID,K_ADI,K_PAROLA,K_DURUMU,K_TURU_ID")] KULLANICI kULLANICI)
        {
            if (ModelState.IsValid)
            {
                db.KULLANICIs.Add(kULLANICI);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.K_TURU_ID = new SelectList(db.KULLANICI_TURU, "KT_ID", "KT_ADI", kULLANICI.K_TURU_ID);
            return View(kULLANICI);
        }

        // GET: Yonetim/KULLANICIs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KULLANICI kULLANICI = db.KULLANICIs.Find(id);
            if (kULLANICI == null)
            {
                return HttpNotFound();
            }
            ViewBag.K_TURU_ID = new SelectList(db.KULLANICI_TURU, "KT_ID", "KT_ADI", kULLANICI.K_TURU_ID);
            return View(kULLANICI);
        }

        // POST: Yonetim/KULLANICIs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "K_ID,K_ADI,K_PAROLA,K_DURUMU,K_TURU_ID")] KULLANICI kULLANICI)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kULLANICI).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.K_TURU_ID = new SelectList(db.KULLANICI_TURU, "KT_ID", "KT_ADI", kULLANICI.K_TURU_ID);
            return View(kULLANICI);
        }

        // GET: Yonetim/KULLANICIs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KULLANICI kULLANICI = db.KULLANICIs.Find(id);
            if (kULLANICI == null)
            {
                return HttpNotFound();
            }
            return View(kULLANICI);
        }

        // POST: Yonetim/KULLANICIs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KULLANICI kULLANICI = db.KULLANICIs.Find(id);
            db.KULLANICIs.Remove(kULLANICI);
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
