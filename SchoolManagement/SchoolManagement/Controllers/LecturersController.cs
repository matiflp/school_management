using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SchoolManagement.Models;

namespace SchoolManagement.Controllers
{
    public class LecturersController : Controller
    {
        private SchoolManagementDataBaseEntities db = new SchoolManagementDataBaseEntities();

        // GET: Lecturers
        public async Task<ActionResult> Index()
        {
            return View(await db.Lecturers.ToListAsync());
        }

        // GET: Lecturers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lecturers lecturers = await db.Lecturers.FindAsync(id);
            if (lecturers == null)
            {
                return HttpNotFound();
            }
            return View(lecturers);
        }

        // GET: Lecturers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lecturers/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,First_Name,Last_Name")] Lecturers lecturers)
        {
            if (ModelState.IsValid)
            {
                db.Lecturers.Add(lecturers);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(lecturers);
        }

        // GET: Lecturers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lecturers lecturers = await db.Lecturers.FindAsync(id);
            if (lecturers == null)
            {
                return HttpNotFound();
            }
            return View(lecturers);
        }

        // POST: Lecturers/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,First_Name,Last_Name")] Lecturers lecturers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lecturers).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(lecturers);
        }

        // GET: Lecturers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lecturers lecturers = await db.Lecturers.FindAsync(id);
            if (lecturers == null)
            {
                return HttpNotFound();
            }
            return View(lecturers);
        }

        // POST: Lecturers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Lecturers lecturers = await db.Lecturers.FindAsync(id);
            db.Lecturers.Remove(lecturers);
            await db.SaveChangesAsync();
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
