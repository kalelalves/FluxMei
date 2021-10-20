﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LivroCaixa.Models;

namespace LivroCaixa.Controllers
{
    public class MovimentoController : Controller
    {
        private FluxBDContext db = new FluxBDContext();

        // GET: Movimento
        public ActionResult Index()
        {
            var movimentoes = db.Movimento.Include(m => m.Mei).Include(m => m.TipoMovimento);
            return View(movimentoes.ToList());
        }

        // GET: Movimento/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movimento movimento = db.Movimento.Find(id);
            if (movimento == null)
            {
                return HttpNotFound();
            }
            return View(movimento);
        }

        // GET: Movimento/Create
        public ActionResult Create()
        {
            ViewBag.IdMei = new SelectList(db.Mei, "IdMei", "Login");
            ViewBag.TipoMovimentoId = new SelectList(db.TipoMovimento, "tipoid", "descricao");
            return View();
        }

        // POST: Movimento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdMovimento,Descicao,Total,Data,Valor,TipoMovimentoId,IdMei,userName")] Movimento movimento)
        {
            if (ModelState.IsValid)
            {
                db.Movimento.Add(movimento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdMei = new SelectList(db.Mei, "IdMei", "Login", movimento.IdMei);
            ViewBag.TipoMovimentoId = new SelectList(db.TipoMovimento, "tipoid", "descricao", movimento.TipoMovimentoId);
            return View(movimento);
        }

        // GET: Movimento/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movimento movimento = db.Movimento.Find(id);
            if (movimento == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdMei = new SelectList(db.Mei, "IdMei", "Login", movimento.IdMei);
            ViewBag.TipoMovimentoId = new SelectList(db.TipoMovimento, "tipoid", "descricao", movimento.TipoMovimentoId);
            return View(movimento);
        }

        // POST: Movimento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdMovimento,Descicao,Total,Data,Valor,TipoMovimentoId,IdMei,userName")] Movimento movimento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movimento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdMei = new SelectList(db.Mei, "IdMei", "Login", movimento.IdMei);
            ViewBag.TipoMovimentoId = new SelectList(db.TipoMovimento, "tipoid", "descricao", movimento.TipoMovimentoId);
            return View(movimento);
        }

        // GET: Movimento/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movimento movimento = db.Movimento.Find(id);
            if (movimento == null)
            {
                return HttpNotFound();
            }
            return View(movimento);
        }

        // POST: Movimento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Movimento movimento = db.Movimento.Find(id);
            db.Movimento.Remove(movimento);
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
