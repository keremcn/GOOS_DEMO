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
    public class ILETISIMsController : Controller
    {
        private AppDBContext db = new AppDBContext();

        // GET: Yonetim/ILETISIMs
        public ActionResult Index()
        {
            var iLETISIMs = db.ILETISIMs.Include(i => i.IL).Include(i => i.ILCE);
            return View(iLETISIMs.ToList());
        }

        // GET: Yonetim/ILETISIMs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ILETISIM iLETISIM = db.ILETISIMs.Find(id);
            if (iLETISIM == null)
            {
                return HttpNotFound();
            }
            return View(iLETISIM);
        }

        // GET: Yonetim/ILETISIMs/Create
        public ActionResult Create()
        {
            ViewBag.ILET_IL_ID = new SelectList(db.ILs, "I_ID", "I_ADI");
            ViewBag.ILET_ILCE_ID = new SelectList(db.ILCEs, "IC_ID", "IC_ADI");
            return View();
        }

        // POST: Yonetim/ILETISIMs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ILET_ID,ILET_ADRES,ILET_EV_TEL,ILET_CEP_TEL,ILET_EPOSTA,ILET_IL_ID,ILET_ILCE_ID")] ILETISIM iLETISIM)
        {
            if (ModelState.IsValid)
            {
                db.ILETISIMs.Add(iLETISIM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ILET_IL_ID = new SelectList(db.ILs, "I_ID", "I_ADI", iLETISIM.ILET_IL_ID);
            ViewBag.ILET_ILCE_ID = new SelectList(db.ILCEs, "IC_ID", "IC_ADI", iLETISIM.ILET_ILCE_ID);
            return View(iLETISIM);
        }

        // GET: Yonetim/ILETISIMs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ILETISIM iLETISIM = db.ILETISIMs.Find(id);
            if (iLETISIM == null)
            {
                return HttpNotFound();
            }
            ViewBag.ILET_IL_ID = new SelectList(db.ILs, "I_ID", "I_ADI", iLETISIM.ILET_IL_ID);
            ViewBag.ILET_ILCE_ID = new SelectList(db.ILCEs, "IC_ID", "IC_ADI", iLETISIM.ILET_ILCE_ID);
            return View(iLETISIM);
        }

        // POST: Yonetim/ILETISIMs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ILET_ID,ILET_ADRES,ILET_EV_TEL,ILET_CEP_TEL,ILET_EPOSTA,ILET_IL_ID,ILET_ILCE_ID")] ILETISIM iLETISIM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iLETISIM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ILET_IL_ID = new SelectList(db.ILs, "I_ID", "I_ADI", iLETISIM.ILET_IL_ID);
            ViewBag.ILET_ILCE_ID = new SelectList(db.ILCEs, "IC_ID", "IC_ADI", iLETISIM.ILET_ILCE_ID);
            return View(iLETISIM);
        }

        // GET: Yonetim/ILETISIMs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ILETISIM iLETISIM = db.ILETISIMs.Find(id);
            if (iLETISIM == null)
            {
                return HttpNotFound();
            }
            return View(iLETISIM);
        }

        // POST: Yonetim/ILETISIMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ILETISIM iLETISIM = db.ILETISIMs.Find(id);
            db.ILETISIMs.Remove(iLETISIM);
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
