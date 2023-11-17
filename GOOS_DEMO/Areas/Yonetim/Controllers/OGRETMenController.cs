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
    public class OGRETMenController : Controller
    {
        private AppDBContext db = new AppDBContext();

        // GET: Yonetim/OGRETMen
        public ActionResult Index()
        {
            var oGRETMEN = db.OGRETMEN.Include(o => o.BRAN).Include(o => o.ILETISIM).Include(o => o.KULLANICI);
            return View(oGRETMEN.ToList());
        }

        // GET: Yonetim/OGRETMen/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OGRETMan oGRETMan = db.OGRETMEN.Find(id);
            if (oGRETMan == null)
            {
                return HttpNotFound();
            }
            return View(oGRETMan);
        }

        // GET: Yonetim/OGRETMen/Create
        public ActionResult Create()
        {
            ViewBag.OGRETMEN_BRANS_ID = new SelectList(db.BRANS, "B_ID", "B_ADI");
            ViewBag.OGRETMEN_ILETISIM_ID = new SelectList(db.ILETISIMs, "ILET_ID", "ILET_ADRES");
            ViewBag.OGRETMEN_K_ID = new SelectList(db.KULLANICIs, "K_ID", "K_ADI");
            return View();
        }

        // POST: Yonetim/OGRETMen/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OGRETMEN_ID,OGRETMEN_CINSIYET,OGRETMEN_ADI,OGRETMEN_SOYADI,OGRETMEN_K_ID,OGRETMEN_ILETISIM_ID,OGRETMEN_BRANS_ID")] OGRETMan oGRETMan)
        {
            if (ModelState.IsValid)
            {
                db.OGRETMEN.Add(oGRETMan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OGRETMEN_BRANS_ID = new SelectList(db.BRANS, "B_ID", "B_ADI", oGRETMan.OGRETMEN_BRANS_ID);
            ViewBag.OGRETMEN_ILETISIM_ID = new SelectList(db.ILETISIMs, "ILET_ID", "ILET_ADRES", oGRETMan.OGRETMEN_ILETISIM_ID);
            ViewBag.OGRETMEN_K_ID = new SelectList(db.KULLANICIs, "K_ID", "K_ADI", oGRETMan.OGRETMEN_K_ID);
            return View(oGRETMan);
        }

        // GET: Yonetim/OGRETMen/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OGRETMan oGRETMan = db.OGRETMEN.Find(id);
            if (oGRETMan == null)
            {
                return HttpNotFound();
            }
            ViewBag.OGRETMEN_BRANS_ID = new SelectList(db.BRANS, "B_ID", "B_ADI", oGRETMan.OGRETMEN_BRANS_ID);
            ViewBag.OGRETMEN_ILETISIM_ID = new SelectList(db.ILETISIMs, "ILET_ID", "ILET_ADRES", oGRETMan.OGRETMEN_ILETISIM_ID);
            ViewBag.OGRETMEN_K_ID = new SelectList(db.KULLANICIs, "K_ID", "K_ADI", oGRETMan.OGRETMEN_K_ID);
            return View(oGRETMan);
        }

        // POST: Yonetim/OGRETMen/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OGRETMEN_ID,OGRETMEN_CINSIYET,OGRETMEN_ADI,OGRETMEN_SOYADI,OGRETMEN_K_ID,OGRETMEN_ILETISIM_ID,OGRETMEN_BRANS_ID")] OGRETMan oGRETMan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oGRETMan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OGRETMEN_BRANS_ID = new SelectList(db.BRANS, "B_ID", "B_ADI", oGRETMan.OGRETMEN_BRANS_ID);
            ViewBag.OGRETMEN_ILETISIM_ID = new SelectList(db.ILETISIMs, "ILET_ID", "ILET_ADRES", oGRETMan.OGRETMEN_ILETISIM_ID);
            ViewBag.OGRETMEN_K_ID = new SelectList(db.KULLANICIs, "K_ID", "K_ADI", oGRETMan.OGRETMEN_K_ID);
            return View(oGRETMan);
        }

        // GET: Yonetim/OGRETMen/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OGRETMan oGRETMan = db.OGRETMEN.Find(id);
            if (oGRETMan == null)
            {
                return HttpNotFound();
            }
            return View(oGRETMan);
        }

        // POST: Yonetim/OGRETMen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OGRETMan oGRETMan = db.OGRETMEN.Find(id);
            db.OGRETMEN.Remove(oGRETMan);
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
