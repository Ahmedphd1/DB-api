using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace dblibrary.database
{
   public class ABcontext : DbContext // ABcontext is a class that get/set
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=localhost;Database=sqlapi; Trusted_Connection=True;", b => b.MigrationsAssembly("dbcontroller"));
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-LP01J1F\SQLEXPRESS;Database=sqlapi; Trusted_Connection=True;");
        }

        public DbSet<author> author { get; set; }
        public DbSet<book> book { get; set; }

    }
}
