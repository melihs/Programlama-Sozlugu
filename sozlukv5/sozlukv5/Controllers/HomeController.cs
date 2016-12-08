using sozlukv5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sozlukv5.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        //veritabanı bağlandı
        FsozlukEntities db = new FsozlukEntities();      
        
        public ActionResult Listele()
        {
            //Model yöntemiyle veriler basılır
            //veritabanındaki tabloyu listeye çevirip  nesne oluşturduk
            List<Fkullanici> kullanicilar = db.Fkullanici.ToList();
            //Index metodu kullanicilar nesnesine ait listeyi ekrana döndürür
            
            return View(kullanicilar);

        }
        //aşağıdaki aynı isimli metodu oluşturmazsan  post işlemi gerçekleşmiyor
        public ActionResult Ekle()
        {
            return View();
        }
        //post işlemi 
        [HttpPost]
        public ActionResult Ekle(string dil, string kelime, string aciklama)
        {
            //veritabanındaki Kullanici tablosunu liste haline getirip,oluşturduğumuz kullanicilar Listesi attık.
            List<Fkullanici> kullanicilar = db.Fkullanici.ToList();
            //input girişleri veritabanı tablosuna bağlanır 
            Fkullanici k = new Fkullanici();
            k.girilenDil =dil;
            k.eklenenKelime =kelime;
            k.aciklama = aciklama;
            // veritabanına eklenir
            db.Fkullanici.Add(k);
            //veritabanına kaydedilir
            db.SaveChanges();
            // kaydedildikten sonra Index metoduna yönlendirilir
            return View();
                //RedirectToAction("Listele");

        }
        
              
        
    } 
    
}