using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SuperZapatos.Database
{
    public class DBContext : DbContext
    {

        public DBContext() : base("DefaultConnection")
        {

        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Store> Stores { get; set; }
    }
}