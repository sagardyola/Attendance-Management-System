using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AttendanceManagementSystem.Models;

namespace AttendanceManagementSystem.Controllers
{
    [Authorize]
    public class TeacherTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TeacherTypes
        public ActionResult Index()
        {
            String sql = "SELECT * FROM TeacherTypes";
            db.List(sql);
            var dt = db.List(sql);
            var model = new TeacherType().List(dt);

            return View(model);
        }

        // GET: TeacherTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TeacherTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TeacherType teacherType)
        {
            if (ModelState.IsValid)
            {
                String sql = "Insert into TeacherTypes (TypeName) values ('" + teacherType.TypeName + "')";
                db.Create(sql);
                return RedirectToAction("Index");
            }

            return View(teacherType);
        }

        // GET: TeacherTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherType teacherType = db.TeacherTypes.Find(id);
            if (teacherType == null)
            {
                return HttpNotFound();
            }
            return View(teacherType);
        }

        // POST: TeacherTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TeacherType teacherType)
        {
            if (ModelState.IsValid)
            {
                String sql = "Update TeacherTypes set TypeName = '" + teacherType.TypeName + "' where TeacherTypeID = " + teacherType.TeacherTypeID;
                db.Edit(sql);
                return RedirectToAction("Index");
            }
            return View(teacherType);
        }

        // POST: TeacherTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            TeacherType teacherType = db.TeacherTypes.Find(id);
            String sql = "Delete From TeacherTypes where TeacherTypeID = " + teacherType.TeacherTypeID;
            db.Delete(sql);
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
