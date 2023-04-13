using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_Filters.Models
{
    public class DatabaseContext:DbContext
    {
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Log> Logs { get; set; }
    }
}