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
    public class GoodsReceivedsController : Controller
    {
        private SellingPhoneEntities db = new SellingPhoneEntities();

        // GET: GoodsReceiveds
        public ActionResult Index()
        {
            return View(db.GoodsReceiveds.ToList());
        }

        // GET: GoodsReceiveds/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GoodsReceived goodsReceived = db.GoodsReceiveds.Find(id);
            if (goodsReceived == null)
            {
                return HttpNotFound();
            }
            return View(goodsReceived);
        }

        // GET: GoodsReceiveds/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GoodsReceiveds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReceivedID,Date,Total_Price")] GoodsReceived goodsReceived)
        {
            if (ModelState.IsValid)
            {
                db.GoodsReceiveds.Add(goodsReceived);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(goodsReceived);
        }

        // GET: GoodsReceiveds/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GoodsReceived goodsReceived = db.GoodsReceiveds.Find(id);
            if (goodsReceived == null)
            {
                return HttpNotFound();
            }
            return View(goodsReceived);
        }

        // POST: GoodsReceiveds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReceivedID,Date,Total_Price")] GoodsReceived goodsReceived)
        {
            if (ModelState.IsValid)
            {
                db.Entry(goodsReceived).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(goodsReceived);
        }

        // GET: GoodsReceiveds/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GoodsReceived goodsReceived = db.GoodsReceiveds.Find(id);
            if (goodsReceived == null)
            {
                return HttpNotFound();
            }
            return View(goodsReceived);
        }

        // POST: GoodsReceiveds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            GoodsReceived goodsReceived = db.GoodsReceiveds.Find(id);
            db.GoodsReceiveds.Remove(goodsReceived);
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
