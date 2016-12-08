using sozlukv5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;//eklendi
using PagedList.Mvc; //eklendi
using sozlukv5.ViewModel;

namespace sozlukv5.Controllers
{
    public class AramaController : Controller
    {
        // GET: Arama
        public ActionResult KelimeArama(Arama model)
        {
            int pageIndex = model.Page ?? 1;

            FsozlukEntities db = new FsozlukEntities();
            model.Liste = (from lt in db.Fkullanici.Where(f =>
                             (string.IsNullOrEmpty(model.progDili) || f.girilenDil.Contains(model.progDili)) && (string.IsNullOrEmpty(model.Ankelime) || f.eklenenKelime.Contains(model.Ankelime))
                                           ).OrderBy(f => f.id)
                           select new ListModel
                           {
                               ProgramlamaDili = lt.girilenDil,
                               Kelime = lt.eklenenKelime,
                               Aciklama=lt.aciklama

                           }).ToPagedList(pageIndex, 10);//aranan sayfayı onar onar listelemeye yarar

            //sayfa ilk defa açılmışsa koşul yapısıyla kontrol edilir
            if (Request.IsAjaxRequest())
            {
                return PartialView("_Control", model);
            }
            else
            {
                return View(model);
            }

            
        }
    }
}