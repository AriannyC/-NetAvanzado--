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



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region "Tabla"
            modelBuilder.Entity<ModGene>().ToTable("Modelgeneric");


            #endregion

            #region "PK"

            modelBuilder.Entity<ModGene>().HasKey(x => x.Id);

            #endregion





        }
    }
}
