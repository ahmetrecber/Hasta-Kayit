using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using hastalar.Data;
using hastalar.Models;

namespace hastalar.Controllers
{
    public class HastalarsController : Controller
    {
        private hastalarDBContext db = new hastalarDBContext();

        // GET: Hastalars
        public ActionResult Index()
        {
            return View(db.Hastalars.ToList());
        }

        // GET: Hastalars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hastalar hastalar = db.Hastalars.Find(id);
            if (hastalar == null)
            {
                return HttpNotFound();
            }
            return View(hastalar);
        }

        // GET: Hastalars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hastalars/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,HastaAdi,HastaSoyadi,HastaKanGrubu,HastaTelNo")] Hastalar hastalar)
        {
            if (ModelState.IsValid)
            {
                db.Hastalars.Add(hastalar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hastalar);
        }

        // GET: Hastalars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hastalar hastalar = db.Hastalars.Find(id);
            if (hastalar == null)
            {
                return HttpNotFound();
            }
            return View(hastalar);
        }

        // POST: Hastalars/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,HastaAdi,HastaSoyadi,HastaKanGrubu,HastaTelNo")] Hastalar hastalar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hastalar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hastalar);
        }

        // GET: Hastalars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hastalar hastalar = db.Hastalars.Find(id);
            if (hastalar == null)
            {
                return HttpNotFound();
            }
            return View(hastalar);
        }

        // POST: Hastalars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hastalar hastalar = db.Hastalars.Find(id);
            db.Hastalars.Remove(hastalar);
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
