using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using dblibrary.models;

namespace dblibrary.database
{
   public class ABcontext : DbContext // ABcontext is a class that get/set
    {

        public ABcontext() { }
        public ABcontext(DbContextOptions<ABcontext> options) : base(options) {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<currencyuser>()
                .HasOne(u => u.user)
                .WithMany(cu => cu.currencyuser)
                .HasForeignKey(ui => ui.userid);

            modelBuilder.Entity<currencyuser>()
            .HasOne(c => c.currency)
            .WithMany(cu => cu.currencyuser)
            .HasForeignKey(ci => ci.currencyid);
        }

        public DbSet<address> address { get; set; }
        public DbSet<currency> currency { get; set; }
        public DbSet<currencyuser> currencyuser { get; set; }
        public DbSet<delivery> delivery { get; set; }
        public DbSet<orders> orders { get; set; }
        public DbSet<payment> payment { get; set; }
        public DbSet<product> product { get; set; }
        public DbSet<seller> seller { get; set; }
        public DbSet<user> user { get; set; }

    }
}
