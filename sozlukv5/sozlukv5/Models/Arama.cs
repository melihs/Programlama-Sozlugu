using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using sozlukv5.ViewModel;

namespace sozlukv5.Models
{
    public class Arama
    {
        public string progDili { get; set; }
        public string  Ankelime { get; set; }
        //filtreleme sonucu bir sayfa döndürecek 
        public int? Page { get; set; }

        public IPagedList<ListModel> Liste { get; set; }
    }
}