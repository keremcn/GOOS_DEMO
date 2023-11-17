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
    public class OGRENCIsController : Controller
    {
        private AppDBContext db = new AppDBContext();

        // GET: Yonetim/OGRENCIs
        public ActionResult Index()
        {
            var oGRENCIs = db.OGRENCIs.Include(o => o.ILETISIM).Include(o => o.KULLANICI);
            return View(oGRENCIs.ToList());
        }

        // GET: Yonetim/OGRENCIs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OGRENCI oGRENCI = db.OGRENCIs.Find(id);
            if (oGRENCI == null)
            {
                return HttpNotFound();
            }
            return View(oGRENCI);
        }

        // GET: Yonetim/OGRENCIs/Create
        public ActionResult Create()
        {
            ViewBag.OGRENCI_ILETISIM_ID = new SelectList(db.ILETISIMs, "ILET_ID", "ILET_ADRES");
            ViewBag.OGRENCI_K_ID = new SelectList(db.KULLANICIs, "K_ID", "K_ADI");
            return View();
        }

        // POST: Yonetim/OGRENCIs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OGRENCI_ID,OGRENCI_NO,OGRENCI_ADI,OGRENCI_SOYADI,OGRENCI_K_ID,OGRENCI_ILETISIM_ID,OGRENCI_CINSIYET")] OGRENCI oGRENCI)
        {
            if (ModelState.IsValid)
            {
                db.OGRENCIs.Add(oGRENCI);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OGRENCI_ILETISIM_ID = new SelectList(db.ILETISIMs, "ILET_ID", "ILET_ADRES", oGRENCI.OGRENCI_ILETISIM_ID);
            ViewBag.OGRENCI_K_ID = new SelectList(db.KULLANICIs, "K_ID", "K_ADI", oGRENCI.OGRENCI_K_ID);
            return View(oGRENCI);
        }

        // GET: Yonetim/OGRENCIs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OGRENCI oGRENCI = db.OGRENCIs.Find(id);
            if (oGRENCI == null)
            {
                return HttpNotFound();
            }
            ViewBag.OGRENCI_ILETISIM_ID = new SelectList(db.ILETISIMs, "ILET_ID", "ILET_ADRES", oGRENCI.OGRENCI_ILETISIM_ID);
            ViewBag.OGRENCI_K_ID = new SelectList(db.KULLANICIs, "K_ID", "K_ADI", oGRENCI.OGRENCI_K_ID);
            return View(oGRENCI);
        }

        // POST: Yonetim/OGRENCIs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OGRENCI_ID,OGRENCI_NO,OGRENCI_ADI,OGRENCI_SOYADI,OGRENCI_K_ID,OGRENCI_ILETISIM_ID,OGRENCI_CINSIYET")] OGRENCI oGRENCI)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oGRENCI).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OGRENCI_ILETISIM_ID = new SelectList(db.ILETISIMs, "ILET_ID", "ILET_ADRES", oGRENCI.OGRENCI_ILETISIM_ID);
            ViewBag.OGRENCI_K_ID = new SelectList(db.KULLANICIs, "K_ID", "K_ADI", oGRENCI.OGRENCI_K_ID);
            return View(oGRENCI);
        }

        // GET: Yonetim/OGRENCIs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OGRENCI oGRENCI = db.OGRENCIs.Find(id);
            if (oGRENCI == null)
            {
                return HttpNotFound();
            }
            return View(oGRENCI);
        }

        // POST: Yonetim/OGRENCIs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OGRENCI oGRENCI = db.OGRENCIs.Find(id);
            db.OGRENCIs.Remove(oGRENCI);
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
