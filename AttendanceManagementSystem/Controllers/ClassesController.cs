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
    public class ClassesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Classes
        public ActionResult Index()
        {
            String sql = "SELECT * FROM classes";
            db.List(sql);
            var dt = db.List(sql);
            var model = new Class().List(dt);

            return View(model);
        }

        // GET: Classes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Classes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClassID,ClassName")] Class @class)
        {
            if (ModelState.IsValid)
            {
                String sql = "Insert into Classes (ClassName) values ('" + @class.ClassName + "')";
                db.Create(sql);
                return RedirectToAction("Index");
            }

            return View(@class);
        }

        // GET: Classes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Class @class = db.Classes.Find(id);
            if (@class == null)
            {
                return HttpNotFound();
            }
            return View(@class);
        }

        // POST: Classes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClassID,ClassName")] Class @class)
        {
            if (ModelState.IsValid)
            {
                String sql = "Update Classes set ClassName = " + "'" + @class.ClassName + " ' "  + " where ClassID = " + @class.ClassID;
                db.Edit(sql);
                return RedirectToAction("Index");
            }
            return View(@class);
        }

        // POST: Classes/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Class @class = db.Classes.Find(id);
            String sql = "Delete From Classes where ClassID = " + @class.ClassID;
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
