using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrieuTruongGiang_2021603645.Models;

namespace TrieuTruongGiang_2021603645.Controllers
{
    public class HocSinhController : Controller
    {
        private HocSinhDBEntities db = new HocSinhDBEntities();

        // GET: HocSinhs
        //public ActionResult Index()
        //{
        //    var hocSinhs = db.HocSinhs.Include(h => h.LopHoc);
        //    return View(hocSinhs.ToList());
        //}
        public ActionResult Xemdanhsach()
        {
            var hocSinhs = db.HocSinhs.Include(h => h.LopHoc);
            return View(hocSinhs.ToList());
        }

        // GET: HocSinhs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HocSinh hocSinh = db.HocSinhs.Find(id);
            if (hocSinh == null)
            {
                return HttpNotFound();
            }
            return View(hocSinh);
        }

        // GET: HocSinhs/Create
        public ActionResult Create()
        {
            ViewBag.malop = new SelectList(db.LopHocs, "malop", "tenlop");
            return View();
        }

        // POST: HocSinhs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "sbd,hoten,anhduthi,malop,diemthi")] HocSinh hocSinh)
        {
            if (ModelState.IsValid)
            {
                db.HocSinhs.Add(hocSinh);
                db.SaveChanges();
                return RedirectToAction("Xemdanhsach");
            }

            ViewBag.malop = new SelectList(db.LopHocs, "malop", "tenlop", hocSinh.malop);
            return View(hocSinh);
        }

        // GET: HocSinhs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HocSinh hocSinh = db.HocSinhs.Find(id);
            if (hocSinh == null)
            {
                return HttpNotFound();
            }
            ViewBag.malop = new SelectList(db.LopHocs, "malop", "tenlop", hocSinh.malop);
            return View(hocSinh);
        }

        // POST: HocSinhs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "sbd,hoten,anhduthi,malop,diemthi")] HocSinh hocSinh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hocSinh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Xemdanhsach");
            }
            ViewBag.malop = new SelectList(db.LopHocs, "malop", "tenlop", hocSinh.malop);
            return View(hocSinh);
        }

        // GET: HocSinhs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HocSinh hocSinh = db.HocSinhs.Find(id);
            if (hocSinh == null)
            {
                return HttpNotFound();
            }
            return View(hocSinh);
        }

        // POST: HocSinhs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HocSinh hocSinh = db.HocSinhs.Find(id);
            db.HocSinhs.Remove(hocSinh);
            db.SaveChanges();
            return RedirectToAction("Xemdanhsach");
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
