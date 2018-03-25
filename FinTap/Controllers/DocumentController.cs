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
    public class DocumentController : Controller
    {
        private FinDbEntities db = new FinDbEntities();

        // GET: Document
        public ActionResult Index()
        {
            return View(db.UserDocumentDetails.ToList());
        }

        // GET: Document/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDocumentDetail userDocumentDetail = db.UserDocumentDetails.Find(id);
            if (userDocumentDetail == null)
            {
                return HttpNotFound();
            }
            return View(userDocumentDetail);
        }

        // GET: Document/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Document/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PanCardPath,AddressProofPath,PhotoPath,SignaturePath")] UserDocumentDetail userDocumentDetail)
        {
            if (ModelState.IsValid)
            {
                db.UserDocumentDetails.Add(userDocumentDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userDocumentDetail);
        }

        // GET: Document/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDocumentDetail userDocumentDetail = db.UserDocumentDetails.Find(id);
            if (userDocumentDetail == null)
            {
                return HttpNotFound();
            }
            return View(userDocumentDetail);
        }

        // POST: Document/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PanCardPath,AddressProofPath,PhotoPath,SignaturePath")] UserDocumentDetail userDocumentDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userDocumentDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userDocumentDetail);
        }

        // GET: Document/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDocumentDetail userDocumentDetail = db.UserDocumentDetails.Find(id);
            if (userDocumentDetail == null)
            {
                return HttpNotFound();
            }
            return View(userDocumentDetail);
        }

        // POST: Document/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserDocumentDetail userDocumentDetail = db.UserDocumentDetails.Find(id);
            db.UserDocumentDetails.Remove(userDocumentDetail);
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
