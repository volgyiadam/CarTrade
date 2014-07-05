using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarTrade.Models
{
    public class Auto
    {
        public int id { get; set; }
        public string marka { get; set; }
        public string tipus { get; set; }
        public int evjarat { get; set; }
        public DateTime gyartasiIdo { get; set; }
        public string allapot { get; set; }
        public int tulajdonosokSzama { get; set; }
        public int telephelyId { get; set; }
    }
}