using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarTrade.Models
{
    public class AutoView
    {
        public int id { get; set; }
        public string marka { get; set; }
        public string tipus { get; set; }
        public int evjarat { get; set; }
        public string gyartasiIdo { get; set; }
        public string allapot { get; set; }
        public int tulajdonosokSzama { get; set; }
        public string telephely { get; set; }

        public AutoView(Auto a, Telephely t)
        {
            this.id = a.id;
            this.marka = a.marka;
            this.tipus = a.tipus;
            this.evjarat = a.evjarat;
            this.gyartasiIdo = a.gyartasiIdo.ToString("yyyy-MM-dd");
            this.allapot = a.allapot;
            this.tulajdonosokSzama = a.tulajdonosokSzama;
            this.telephely =t.irSzam + ", "+ t.cim;
        }

    }
}