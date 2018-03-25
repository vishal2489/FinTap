using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinTap.Models;

namespace FinTap.Controllers
{
    public class UserTaxDetailsController : Controller
    {
        private FinDbEntities db = new FinDbEntities();

        // GET: UserTaxDetails
        public ActionResult Index()
        {
            return View(db.UserTaxDetails.ToList());
        }

        // GET: UserTaxDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserTaxDetail userTaxDetail = db.UserTaxDetails.Find(id);
            if (userTaxDetail == null)
            {
                return HttpNotFound();
            }
            return View(userTaxDetail);
        }

        // GET: UserTaxDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserTaxDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PAN,IsKYCDone")] UserTaxDetail userTaxDetail)
        {
            if (ModelState.IsValid)
            {
                db.UserTaxDetails.Add(userTaxDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userTaxDetail);
        }

        // GET: UserTaxDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserTaxDetail userTaxDetail = db.UserTaxDetails.Find(id);
            if (userTaxDetail == null)
            {
                return HttpNotFound();
            }
            return View(userTaxDetail);
        }

        // POST: UserTaxDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PAN,IsKYCDone")] UserTaxDetail userTaxDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userTaxDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userTaxDetail);
        }

        // GET: UserTaxDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserTaxDetail userTaxDetail = db.UserTaxDetails.Find(id);
            if (userTaxDetail == null)
            {
                return HttpNotFound();
            }
            return View(userTaxDetail);
        }

        // POST: UserTaxDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserTaxDetail userTaxDetail = db.UserTaxDetails.Find(id);
            db.UserTaxDetails.Remove(userTaxDetail);
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
