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
    public class ReceiptsController : Controller
    {
        private SellingPhoneEntities db = new SellingPhoneEntities();

        // GET: Receipts
        public ActionResult Index()
        {
            var receipts = db.Receipts.Include(r => r.Accountant).Include(r => r.Good);
            return View(receipts.ToList());
        }

        // GET: Receipts/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receipt receipt = db.Receipts.Find(id);
            if (receipt == null)
            {
                return HttpNotFound();
            }
            return View(receipt);
        }

        // GET: Receipts/Create
        public ActionResult Create()
        {
            ViewBag.AccountantID = new SelectList(db.Accountants, "AccountantID", "AccountantName");
            ViewBag.GoodsID = new SelectList(db.Goods, "GoodsID", "GoodsName");
            return View();
        }

        // POST: Receipts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GoodsID,ReceivedID,Quantity,AccountantID,Price")] Receipt receipt)
        {
            if (ModelState.IsValid)
            {
                db.Receipts.Add(receipt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountantID = new SelectList(db.Accountants, "AccountantID", "AccountantName", receipt.AccountantID);
            ViewBag.GoodsID = new SelectList(db.Goods, "GoodsID", "GoodsName", receipt.GoodsID);
            return View(receipt);
        }

        // GET: Receipts/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receipt receipt = db.Receipts.Find(id);
            if (receipt == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountantID = new SelectList(db.Accountants, "AccountantID", "AccountantName", receipt.AccountantID);
            ViewBag.GoodsID = new SelectList(db.Goods, "GoodsID", "GoodsName", receipt.GoodsID);
            return View(receipt);
        }

        // POST: Receipts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GoodsID,ReceivedID,Quantity,AccountantID,Price")] Receipt receipt)
        {
            if (ModelState.IsValid)
            {
                db.Entry(receipt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountantID = new SelectList(db.Accountants, "AccountantID", "AccountantName", receipt.AccountantID);
            ViewBag.GoodsID = new SelectList(db.Goods, "GoodsID", "GoodsName", receipt.GoodsID);
            return View(receipt);
        }

        // GET: Receipts/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receipt receipt = db.Receipts.Find(id);
            if (receipt == null)
            {
                return HttpNotFound();
            }
            return View(receipt);
        }

        // POST: Receipts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Receipt receipt = db.Receipts.Find(id);
            db.Receipts.Remove(receipt);
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
