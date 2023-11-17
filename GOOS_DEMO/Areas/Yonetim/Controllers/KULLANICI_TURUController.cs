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
    public class KULLANICI_TURUController : Controller
    {
        private AppDBContext db = new AppDBContext();

        // GET: Yonetim/KULLANICI_TURU
        public ActionResult Index()
        {
            return View(db.KULLANICI_TURU.ToList());
        }

        // GET: Yonetim/KULLANICI_TURU/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KULLANICI_TURU kULLANICI_TURU = db.KULLANICI_TURU.Find(id);
            if (kULLANICI_TURU == null)
            {
                return HttpNotFound();
            }
            return View(kULLANICI_TURU);
        }

        // GET: Yonetim/KULLANICI_TURU/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Yonetim/KULLANICI_TURU/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KT_ID,KT_ADI")] KULLANICI_TURU kULLANICI_TURU)
        {
            if (ModelState.IsValid)
            {
                db.KULLANICI_TURU.Add(kULLANICI_TURU);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kULLANICI_TURU);
        }

        // GET: Yonetim/KULLANICI_TURU/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KULLANICI_TURU kULLANICI_TURU = db.KULLANICI_TURU.Find(id);
            if (kULLANICI_TURU == null)
            {
                return HttpNotFound();
            }
            return View(kULLANICI_TURU);
        }

        // POST: Yonetim/KULLANICI_TURU/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KT_ID,KT_ADI")] KULLANICI_TURU kULLANICI_TURU)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kULLANICI_TURU).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kULLANICI_TURU);
        }

        // GET: Yonetim/KULLANICI_TURU/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KULLANICI_TURU kULLANICI_TURU = db.KULLANICI_TURU.Find(id);
            if (kULLANICI_TURU == null)
            {
                return HttpNotFound();
            }
            return View(kULLANICI_TURU);
        }

        // POST: Yonetim/KULLANICI_TURU/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KULLANICI_TURU kULLANICI_TURU = db.KULLANICI_TURU.Find(id);
            db.KULLANICI_TURU.Remove(kULLANICI_TURU);
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
