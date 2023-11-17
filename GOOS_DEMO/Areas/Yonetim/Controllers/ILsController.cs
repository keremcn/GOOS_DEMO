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
    public class ILsController : Controller
    {
        private AppDBContext db = new AppDBContext();

        // GET: Yonetim/ILs
        public ActionResult Index()
        {
            return View(db.ILs.ToList());
        }

        // GET: Yonetim/ILs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IL iL = db.ILs.Find(id);
            if (iL == null)
            {
                return HttpNotFound();
            }
            return View(iL);
        }

        // GET: Yonetim/ILs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Yonetim/ILs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "I_ID,I_ADI")] IL iL)
        {
            if (ModelState.IsValid)
            {
                db.ILs.Add(iL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(iL);
        }

        // GET: Yonetim/ILs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IL iL = db.ILs.Find(id);
            if (iL == null)
            {
                return HttpNotFound();
            }
            return View(iL);
        }

        // POST: Yonetim/ILs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "I_ID,I_ADI")] IL iL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(iL);
        }

        // GET: Yonetim/ILs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IL iL = db.ILs.Find(id);
            if (iL == null)
            {
                return HttpNotFound();
            }
            return View(iL);
        }

        // POST: Yonetim/ILs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IL iL = db.ILs.Find(id);
            db.ILs.Remove(iL);
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
