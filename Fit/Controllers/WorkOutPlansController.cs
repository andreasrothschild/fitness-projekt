using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Fit.Models;

namespace Fit.Controllers
{
    public class WorkOutPlansController : Controller
    {
        private FitContext db = new FitContext();

        // GET: WorkOutPlans
        public ActionResult Index()
        {
            return View(db.WorkOutPlans.ToList());
        }

        // GET: WorkOutPlans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkOutPlan workOutPlan = db.WorkOutPlans.Find(id);
            if (workOutPlan == null)
            {
                return HttpNotFound();
            }
            return View(workOutPlan);
        }

        // GET: WorkOutPlans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WorkOutPlans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Description,CreationTime")] WorkOutPlan workOutPlan, Exercise exercises)
        {
            if (ModelState.IsValid)
            {
                var now = DateTime.Now;
                workOutPlan.CreationTime = new DateTime(now.Year, now.Month, now.Day); 
               db.WorkOutPlans.Add(workOutPlan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(workOutPlan);
        }

        // GET: WorkOutPlans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkOutPlan workOutPlan = db.WorkOutPlans.Find(id);
            if (workOutPlan == null)
            {
                return HttpNotFound();
            }
            return View(workOutPlan);
        }

        // POST: WorkOutPlans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Description,CreationTime")] WorkOutPlan workOutPlan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workOutPlan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(workOutPlan);
        }

        // GET: WorkOutPlans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkOutPlan workOutPlan = db.WorkOutPlans.Find(id);
            if (workOutPlan == null)
            {
                return HttpNotFound();
            }
            return View(workOutPlan);
        }

        // POST: WorkOutPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkOutPlan workOutPlan = db.WorkOutPlans.Find(id);
            db.WorkOutPlans.Remove(workOutPlan);
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
