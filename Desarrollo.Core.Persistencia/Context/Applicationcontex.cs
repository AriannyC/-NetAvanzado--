using Desarrollo.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desarrollo.Core.Persistencia.Context
{
    public class Applicationcontex:DbContext
    {

        public Applicationcontex(DbContextOptions<Applicationcontex>options) :base(options) {  
        }



        public DbSet<ModGene> mods { get; set; }
        public DbSet<Ustoken> ustokens { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region "Tabla"
            modelBuilder.Entity<ModGene>().ToTable("Modelgeneric");
            modelBuilder.Entity<Ustoken>().ToTable("LGT");



            #endregion

            #region "PK"

            modelBuilder.Entity<ModGene>().HasKey(x => x.Id);
            modelBuilder.Entity<Ustoken>().HasKey(x => x.IdR);

            #endregion





        }
    }
}
