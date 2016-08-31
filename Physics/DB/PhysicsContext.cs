using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Entity;

namespace Physics
{
    class PhysicsContext : DbContext
    {
        public DbSet<Ptable> Ptables { get; set; }
        public DbSet<Formul> Formuls { get; set; }

       public DbSet<TaskTest> Tests { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=PhysicsDB.db");
        }
    }
}
