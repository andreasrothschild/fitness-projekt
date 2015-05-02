using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Fit.Models;
using Fit.Models.Helpers;
using Microsoft.Owin.Security.Provider;

namespace Fit.Controllers
{
    public class ExercisesController : Controller
    {
        private FitContext db = new FitContext();

        // GET: Exercises
        [HttpGet]
        public ActionResult Index()
        {

            return View(db.Exercises.ToList());
        }
        [HttpPost]
        public ActionResult Index(string searchString, string tag)
        {
            var tagList = new List<string>();
            var GenreQry = from d in db.Exercises
                           orderby d.Tag
                           select d.Tag;

            tagList.AddRange(GenreQry.Distinct());
            ViewBag.tag = new SelectList(tagList);

            var exercises = from m in db.Exercises
                            select m;
            if (exercises != null)
            {
                exercises = exercises.Where(t => t.Title.Contains(searchString));
            }
            if (!string.IsNullOrEmpty(tag))
            {
                exercises = exercises.Where(x => x.Tag == tag);
            }



            return View(exercises);
        }


        // GET: Exercises/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exercise exercise = db.Exercises.Find(id);
            if (exercise == null)
            {
                return HttpNotFound();
            }
            return View(exercise);
        }

        // GET: Exercises/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Exercises/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Description,Tag")] Exercise exercise, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                exercise.ImagePath = DataHelper.SaveImage(image, Server.MapPath("~"), "/Images/");
                db.Exercises.Add(exercise);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(exercise);
        }

        // GET: Exercises/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exercise exercise = db.Exercises.Find(id);
            if (exercise == null)
            {
                return HttpNotFound();
            }
            return View(exercise);
        }

        // POST: Exercises/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Description,Tag")] Exercise exercise, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    if (!String.IsNullOrEmpty(exercise.ImagePath))
                    {
                        DataHelper.DeleteImage(Server.MapPath("~"), exercise.ImagePath);
                    }
                    exercise.ImagePath = DataHelper.SaveImage(image, Server.MapPath("~"), "Images/");
                }
                db.Entry(exercise).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(exercise);
        }

        // GET: Exercises/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exercise exercise = db.Exercises.Find(id);
            if (exercise == null)
            {
                return HttpNotFound();
            }
            return View(exercise);
        }

        // POST: Exercises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Exercise exercise = db.Exercises.Find(id);
            db.Exercises.Remove(exercise);
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
