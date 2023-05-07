using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalWeb.Models;

namespace FinalWeb.Controllers
{
    public class DeliveryNotesController : Controller
    {
        private SellingPhoneEntities db = new SellingPhoneEntities();

        // GET: DeliveryNotes
        public ActionResult Index()
        {
            var deliveryNotes = db.DeliveryNotes.Include(d => d.Accountant).Include(d => d.Order);
            return View(deliveryNotes.ToList());
        }

        // GET: DeliveryNotes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryNote deliveryNote = db.DeliveryNotes.Find(id);
            if (deliveryNote == null)
            {
                return HttpNotFound();
            }
            return View(deliveryNote);
        }

        // GET: DeliveryNotes/Create
        public ActionResult Create()
        {
            ViewBag.AccountantID = new SelectList(db.Accountants, "AccountantID", "AccountantName");
            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "Status");
            return View();
        }

        // POST: DeliveryNotes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DeliveryNoteID,AccountantID,OrderID,Date")] DeliveryNote deliveryNote)
        {
            if (ModelState.IsValid)
            {
                db.DeliveryNotes.Add(deliveryNote);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountantID = new SelectList(db.Accountants, "AccountantID", "AccountantName", deliveryNote.AccountantID);
            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "Status", deliveryNote.OrderID);
            return View(deliveryNote);
        }

        // GET: DeliveryNotes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryNote deliveryNote = db.DeliveryNotes.Find(id);
            if (deliveryNote == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountantID = new SelectList(db.Accountants, "AccountantID", "AccountantName", deliveryNote.AccountantID);
            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "Status", deliveryNote.OrderID);
            return View(deliveryNote);
        }

        // POST: DeliveryNotes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DeliveryNoteID,AccountantID,OrderID,Date")] DeliveryNote deliveryNote)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deliveryNote).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountantID = new SelectList(db.Accountants, "AccountantID", "AccountantName", deliveryNote.AccountantID);
            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "Status", deliveryNote.OrderID);
            return View(deliveryNote);
        }

        // GET: DeliveryNotes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryNote deliveryNote = db.DeliveryNotes.Find(id);
            if (deliveryNote == null)
            {
                return HttpNotFound();
            }
            return View(deliveryNote);
        }

        // POST: DeliveryNotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DeliveryNote deliveryNote = db.DeliveryNotes.Find(id);
            db.DeliveryNotes.Remove(deliveryNote);
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
