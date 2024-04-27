using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcokul.Models.entity;

namespace mvcokul.Controllers
{
    public class personelController : Controller
    {
        projeEntities db = new projeEntities();
        public ActionResult Index()
        {
            var degerler = db.ogretmen.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult Yenikategori()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Yenikategori(ogretmen p1)
        {
            db.ogretmen.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult SIL(int id)
        {
            var Kategori = db.ogretmen.Find(id);
            db.ogretmen.Remove(Kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.ogretmen.Find(id);
            return View("KategoriGetir", ktgr);
        }
        public ActionResult Guncelle(ogretmen p1)
        {
            var ktg = db.ogretmen.Find(p1.ogretid);
            ktg.ogretmenadi = p1.ogretmenadi;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}