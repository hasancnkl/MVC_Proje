using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcokul.Models.entity;

namespace mvcokul.Controllers
{
    public class ogrencilerController : Controller
    {
        projeEntities db = new projeEntities();
        public ActionResult Index()
        {
            var degerler = db.ogrenci.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult Yenikategori()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Yenikategori(ogrenci p1)
        {
            db.ogrenci.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult SIL(int id)
        {
            var Kategori = db.ogrenci.Find(id);
            db.ogrenci.Remove(Kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.ogrenci.Find(id);
            return View("KategoriGetir", ktgr);
        }
        public ActionResult Guncelle(ogrenci p1)
        {
            var ktg = db.ogrenci.Find(p1.ogrid);
            ktg.ogradi = p1.ogradi;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}