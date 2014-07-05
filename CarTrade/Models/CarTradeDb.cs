using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CarTrade.Models
{
    public class CarTradeDb : DbContext
    {
        public DbSet<Telephely> Telephelyek { get; set; }
        public DbSet<Auto> Autok { get; set; }
    }
}