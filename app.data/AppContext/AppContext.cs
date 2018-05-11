using app.data.Domains;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace app.data.AppContext
{
    public class AppContext : DbContext
    {
        public AppContext()
            : base("AppContext")
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Hero> Heroes { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}