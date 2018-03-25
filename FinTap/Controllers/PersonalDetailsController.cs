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
    public class PersonalDetailsController : Controller
    {
        private FinDbEntities db = new FinDbEntities();

        // GET: PersonalDetails
        public ActionResult Index()
        {
            return View(db.UserPersonalDetails.ToList());
        }

        // GET: PersonalDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserPersonalDetail userPersonalDetail = db.UserPersonalDetails.Find(id);
            if (userPersonalDetail == null)
            {
                return HttpNotFound();
            }
            return View(userPersonalDetail);
        }

        // GET: PersonalDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonalDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,MiddleName,LastName,Gender,DateOfBirth,FatherOrSpouseName,MotherName,Address,City,State,PinCode,MaritalStatus,CitizenShip,ResidentialStatus,Occupation,IsActive")] UserPersonalDetail userPersonalDetail)
        {
            if (ModelState.IsValid)
            {
                db.UserPersonalDetails.Add(userPersonalDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userPersonalDetail);
        }

        // GET: PersonalDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserPersonalDetail userPersonalDetail = db.UserPersonalDetails.Find(id);
            if (userPersonalDetail == null)
            {
                return HttpNotFound();
            }
            return View(userPersonalDetail);
        }

        // POST: PersonalDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,MiddleName,LastName,Gender,DateOfBirth,FatherOrSpouseName,MotherName,Address,City,State,PinCode,MaritalStatus,CitizenShip,ResidentialStatus,Occupation,IsActive")] UserPersonalDetail userPersonalDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userPersonalDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userPersonalDetail);
        }

        // GET: PersonalDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserPersonalDetail userPersonalDetail = db.UserPersonalDetails.Find(id);
            if (userPersonalDetail == null)
            {
                return HttpNotFound();
            }
            return View(userPersonalDetail);
        }

        // POST: PersonalDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserPersonalDetail userPersonalDetail = db.UserPersonalDetails.Find(id);
            db.UserPersonalDetails.Remove(userPersonalDetail);
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
