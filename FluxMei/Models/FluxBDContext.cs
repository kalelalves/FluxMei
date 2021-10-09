using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FluxMei.Models
{
    public partial class FluxBDContext : DbContext
    {
        public FluxBDContext()
        {
        }

        public FluxBDContext(DbContextOptions<FluxBDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Mei> Mei { get; set; }
        public virtual DbSet<Movimento> Movimento { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-P1M7U70\\SQLEXPRESS;Initial Catalog=FluxBD;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mei>(entity =>
            {
                entity.HasKey(e => e.IdMei)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("MEI");

                entity.Property(e => e.IdMei)
                    .HasColumnName("Id_Mei")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Cnpj)
                    .HasColumnName("CNPJ")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Login)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Logradouto)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NomeEmpresa)
                    .HasColumnName("Nome_Empresa")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NomeProprietario)
                    .HasColumnName("Nome_Proprietario")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Movimento>(entity =>
            {
                entity.HasKey(e => e.IdMovimento)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.IdMovimento)
                    .HasColumnName("Id_Movimento")
                    .HasColumnType("numeric(10, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Data).HasColumnType("date");

                entity.Property(e => e.Descicao)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.IdMei)
                    .IsRequired()
                    .HasColumnName("Id_Mei")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Total).HasColumnType("numeric(10, 0)");

                entity.Property(e => e.Valor).HasColumnType("decimal(10, 0)");

                entity.HasOne(d => d.IdMeiNavigation)
                    .WithMany(p => p.Movimento)
                    .HasForeignKey(d => d.IdMei)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RefMEI17");
            });
        }
    }
}
