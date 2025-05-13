using Bilisim.HelloMvc.Data;
using Bilisim.HelloMvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Bilisim.HelloMvc.Controllers
{
    public class OgrenciController : Controller
    {
        private readonly OgrenciDbContext _context;

        public OgrenciController(OgrenciDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var ogrenciler = _context.Ogrenciler.ToList();
            return View("AnaSayfa", ogrenciler);
        }

        public IActionResult OgrenciDetay(int id)
        {
            var ogr = _context.Ogrenciler.Find(id);
            return View(ogr);
        }

        public IActionResult Yeni()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Yeni(Ogrenci yeni)
        {
            _context.Ogrenciler.Add(yeni);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Guncelle(int id)
        {
            var ogr = _context.Ogrenciler.Find(id);
            return View(ogr);
        }

        [HttpPost]
        public IActionResult Guncelle(Ogrenci guncel)
        {
            var ogr = _context.Ogrenciler.Find(guncel.Ogrenciid);
            if (ogr != null)
            {
                ogr.Ad = guncel.Ad;
                ogr.Soyad = guncel.Soyad;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Sil(int id)
        {
            var ogr = _context.Ogrenciler.Find(id);
            if (ogr != null)
            {
                _context.Ogrenciler.Remove(ogr);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult GetirInput(int id)
        {
            var ogr = _context.Ogrenciler.Find(id);
            if (ogr != null)
                return View("OgrenciDetay", ogr);
            else
                return NotFound("Öğrenci bulunamadı");
        }
    }
}
