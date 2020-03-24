using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TPDojo.Data
{
    public class DojoContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public DojoContext() : base("name=DojoContext")
        {
        }

        public System.Data.Entity.DbSet<Models.Samourai> Samourais { get; set; }

        public System.Data.Entity.DbSet<Models.Arme> Armes { get; set; }

        public System.Data.Entity.DbSet<Models.ArtMartial> ArtsMartiaux { get; set; }
    }
}
