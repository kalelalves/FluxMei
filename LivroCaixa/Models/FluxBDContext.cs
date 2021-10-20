using LivroCaixa.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace LivroCaixa.Models
{
    public partial class FluxBDContext : IdentityDbContext<ApplicationUser>
    {
        public FluxBDContext(): base("DefaultConnection")
        {
        }

        public static FluxBDContext Create()
        {
            return new FluxBDContext();
        }

        public virtual DbSet<Mei> Mei { get; set; }
        public virtual DbSet<Movimento> Movimento { get; set; }
        public virtual DbSet<TipoMovimento> TipoMovimento { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Data Source=DESKTOP-P1M7U70\\SQLEXPRESS;Initial Catalog=FluxBD;Integrated Security=True;");
        //    }
        //}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
                                    
        }
    }
}
