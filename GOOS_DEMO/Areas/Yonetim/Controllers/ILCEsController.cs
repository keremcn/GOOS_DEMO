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
    public class ILCEsController : Controller
    {
        private AppDBContext db = new AppDBContext();

        // GET: Yonetim/ILCEs
        public ActionResult Index()
        {
            var iLCEs = db.ILCEs.Include(i => i.IL);
            return View(iLCEs.ToList());
        }

        // GET: Yonetim/ILCEs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ILCE iLCE = db.ILCEs.Find(id);
            if (iLCE == null)
            {
                return HttpNotFound();
            }
            return View(iLCE);
        }

        // GET: Yonetim/ILCEs/Create
        public ActionResult Create()
        {
            ViewBag.IC_IL_ID = new SelectList(db.ILs, "I_ID", "I_ADI");
            return View();
        }

        // POST: Yonetim/ILCEs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IC_ID,IC_ADI,IC_IL_ID")] ILCE iLCE)
        {
            if (ModelState.IsValid)
            {
                db.ILCEs.Add(iLCE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IC_IL_ID = new SelectList(db.ILs, "I_ID", "I_ADI", iLCE.IC_IL_ID);
            return View(iLCE);
        }

        // GET: Yonetim/ILCEs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ILCE iLCE = db.ILCEs.Find(id);
            if (iLCE == null)
            {
                return HttpNotFound();
            }
            ViewBag.IC_IL_ID = new SelectList(db.ILs, "I_ID", "I_ADI", iLCE.IC_IL_ID);
            return View(iLCE);
        }

        // POST: Yonetim/ILCEs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IC_ID,IC_ADI,IC_IL_ID")] ILCE iLCE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iLCE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IC_IL_ID = new SelectList(db.ILs, "I_ID", "I_ADI", iLCE.IC_IL_ID);
            return View(iLCE);
        }

        // GET: Yonetim/ILCEs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ILCE iLCE = db.ILCEs.Find(id);
            if (iLCE == null)
            {
                return HttpNotFound();
            }
            return View(iLCE);
        }

        // POST: Yonetim/ILCEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ILCE iLCE = db.ILCEs.Find(id);
            db.ILCEs.Remove(iLCE);
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
