using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DemoClassLibrary.Models;
using DemoClassLibrary.Interface;
using DemoClassLibrary.Repository;

namespace DemoMvc.Controllers
{
    public class productsController : Controller
    {
        private testEntities db = new testEntities();
        public IRepository<product> repo_product = new Repository<product>();

        // GET: products
        public ActionResult Index()
        {
            //return View(db.product.ToList());
            return View(repo_product.GetAll());
        }

        // GET: products/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //product product = db.product.Find(id);
            product product = repo_product.Get(p => p.p_prodid == id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: products/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "p_prodid,p_prodname,p_classid,p_status,p_display,p_onshaffdateb,p_onshaffdaten,p_playseq,p_packagetext,p_functiontext,p_price")] product product)
        {
            if (ModelState.IsValid)
            {
                //db.product.Add(product);
                //db.SaveChanges();
                repo_product.Add(product);
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: products/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //product product = db.product.Find(id);
            product product = repo_product.Get(p => p.p_prodid == id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: products/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "p_prodid,p_prodname,p_classid,p_status,p_display,p_onshaffdateb,p_onshaffdaten,p_playseq,p_packagetext,p_functiontext,p_price")] product product)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(product).State = EntityState.Modified;
                //db.SaveChanges();
                repo_product.Update(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: products/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //product product = db.product.Find(id);
            product product = repo_product.Get(p => p.p_prodid == id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            //product product = db.product.Find(id);
            //db.product.Remove(product);
            //db.SaveChanges();
            product product = repo_product.Get(p => p.p_prodid == id);
            repo_product.Delete(product);
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
