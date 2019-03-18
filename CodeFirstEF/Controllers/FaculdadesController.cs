using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CodeFirstEF.DAL;
using CodeFirstEF.Models;

namespace CodeFirstEF.Controllers
{
    public class FaculdadesController : Controller
    {
        private EFContext db = new EFContext();

        // GET: Faculdades
        public ActionResult Index()
        {
            return View(db.Faculdades.ToList());
        }

        // GET: Faculdades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faculdade faculdade = db.Faculdades.Find(id);
            if (faculdade == null)
            {
                return HttpNotFound();
            }
            return View(faculdade);
        }

        // GET: Faculdades/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Faculdades/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FaculdadeID,Nome,Cidade,Uf")] Faculdade faculdade)
        {
            if (ModelState.IsValid)
            {
                db.Faculdades.Add(faculdade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(faculdade);
        }

        // GET: Faculdades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faculdade faculdade = db.Faculdades.Find(id);
            if (faculdade == null)
            {
                return HttpNotFound();
            }
            return View(faculdade);
        }

        // POST: Faculdades/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FaculdadeID,Nome,Cidade,Uf")] Faculdade faculdade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(faculdade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(faculdade);
        }

        // GET: Faculdades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faculdade faculdade = db.Faculdades.Find(id);
            if (faculdade == null)
            {
                return HttpNotFound();
            }
            return View(faculdade);
        }

        // POST: Faculdades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Faculdade faculdade = db.Faculdades.Find(id);
            db.Faculdades.Remove(faculdade);
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
