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
    public class UsersController : Controller
    {
        private FinDbEntities db = new FinDbEntities();

        // GET: Users
        public ActionResult Index()
        {
            var users = db.Users.Include(u => u.UserDocumentDetail).Include(u => u.UserPersonalDetail).Include(u => u.UserTaxDetail);
            return View(users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            ViewBag.DocumentDetailsId = new SelectList(db.UserDocumentDetails, "Id", "PanCardPath");
            ViewBag.PersonalDetailsId = new SelectList(db.UserPersonalDetails, "Id", "FirstName");
            ViewBag.TaxDetailsId = new SelectList(db.UserTaxDetails, "Id", "PAN");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TaxDetailsId,PersonalDetailsId,DocumentDetailsId,EmailId,MobileNumber,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DocumentDetailsId = new SelectList(db.UserDocumentDetails, "Id", "PanCardPath", user.DocumentDetailsId);
            ViewBag.PersonalDetailsId = new SelectList(db.UserPersonalDetails, "Id", "FirstName", user.PersonalDetailsId);
            ViewBag.TaxDetailsId = new SelectList(db.UserTaxDetails, "Id", "PAN", user.TaxDetailsId);
            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.DocumentDetailsId = new SelectList(db.UserDocumentDetails, "Id", "PanCardPath", user.DocumentDetailsId);
            ViewBag.PersonalDetailsId = new SelectList(db.UserPersonalDetails, "Id", "FirstName", user.PersonalDetailsId);
            ViewBag.TaxDetailsId = new SelectList(db.UserTaxDetails, "Id", "PAN", user.TaxDetailsId);
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TaxDetailsId,PersonalDetailsId,DocumentDetailsId,EmailId,MobileNumber,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DocumentDetailsId = new SelectList(db.UserDocumentDetails, "Id", "PanCardPath", user.DocumentDetailsId);
            ViewBag.PersonalDetailsId = new SelectList(db.UserPersonalDetails, "Id", "FirstName", user.PersonalDetailsId);
            ViewBag.TaxDetailsId = new SelectList(db.UserTaxDetails, "Id", "PAN", user.TaxDetailsId);
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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
