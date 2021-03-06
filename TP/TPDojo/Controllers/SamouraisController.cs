﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Models;
using TPDojo.Data;

namespace TPDojo.Controllers
{
    public class SamouraisController : Controller
    {
        private DojoContext db = new DojoContext();

        // GET: Samourais
        public ActionResult Index()
        {
            return View(db.Samourais.ToList());
        }

        // GET: Samourais/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samourai samourai = db.Samourais.Find(id);
            if (samourai == null)
            {
                return HttpNotFound();
            }
            return View(samourai);
        }

        // GET: Samourais/Create
        public ActionResult Create()
        {
            var svm = new SamouraiViewModel();
            svm.Armes = db.Armes.Except(db.Samourais.Select(s => s.Arme)).ToList();
            svm.ArtsMartiaux = db.ArtsMartiaux.ToList();
            return View(svm);
        }

        // POST: Samourais/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SamouraiViewModel svm)
        {
            if (ModelState.IsValid)
            {
                if (svm.IdSelectedArme.HasValue)
                {
                    svm.Samourai.Arme = db.Armes.FirstOrDefault(a => a.Id == svm.IdSelectedArme);
                }
                if (svm.IdSelectedArtMartiaux.Count() > 0)
                {
                    svm.IdSelectedArtMartiaux.ForEach(idam => {
                        svm.Samourai.ArtsMartiaux.Add(db.ArtsMartiaux.FirstOrDefault(am => am.Id == idam));
                    });
                }

                db.Samourais.Add(svm.Samourai);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            svm.Armes = db.Armes.Except(db.Samourais.Select(s => s.Arme)).ToList();
            svm.ArtsMartiaux = db.ArtsMartiaux.ToList();
            return View(svm);
        }

        // GET: Samourais/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samourai samourai = db.Samourais.Find(id);
            if (samourai == null)
            {
                return HttpNotFound();
            }
            var svm = new SamouraiViewModel();
            svm.Samourai = samourai;
            svm.Armes = db.Armes.Except(db.Samourais.Select(s => s.Arme)).ToList();
            svm.ArtsMartiaux = db.ArtsMartiaux.ToList();
            if (samourai.Arme != null)
            {
                svm.Armes.Add(samourai.Arme);
                svm.IdSelectedArme = samourai.Arme.Id;
            }
            if (samourai.ArtsMartiaux != null)
            {
                svm.IdSelectedArtMartiaux = samourai.ArtsMartiaux.Select(am => am.Id).ToList();
            }
            return View(svm);
        }

        // POST: Samourais/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SamouraiViewModel svm)
        {
            if (ModelState.IsValid)
            {
                var oldSamourai = db.Samourais.Find(svm.Samourai.Id);
                oldSamourai.Force = svm.Samourai.Force;
                oldSamourai.Nom = svm.Samourai.Nom;
                oldSamourai.Arme = null;
                if (svm.IdSelectedArme.HasValue)
                {
                    oldSamourai.Arme = db.Armes.FirstOrDefault(a => a.Id == svm.IdSelectedArme);
                }
                oldSamourai.ArtsMartiaux.Clear();
                if (svm.IdSelectedArtMartiaux.Count() > 0)
                {
                    svm.IdSelectedArtMartiaux.ForEach(idam => {
                        oldSamourai.ArtsMartiaux.Add(db.ArtsMartiaux.FirstOrDefault(am => am.Id == idam));
                    });
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            svm.Armes = db.Armes.Except(db.Samourais.Select(s => s.Arme)).ToList();
            svm.ArtsMartiaux = db.ArtsMartiaux.ToList();
            if (svm.Samourai.Arme != null)
            {
                svm.Armes.Add(svm.Samourai.Arme);
            }
            return View(svm);
        }

        // GET: Samourais/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samourai samourai = db.Samourais.Find(id);
            if (samourai == null)
            {
                return HttpNotFound();
            }
            return View(samourai);
        }

        // POST: Samourais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Samourai samourai = db.Samourais.Find(id);
            db.Samourais.Remove(samourai);
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
