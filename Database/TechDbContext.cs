using ASTechLogin.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ASTechLogin.Data
{
    public class TechDbContext : DbContext
    {
        public TechDbContext() : base("DefaultConection")
        {

        }

        public DbSet<User> user { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

    

}
