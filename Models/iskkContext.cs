using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace decaf.Models
{
    public partial class iskkContext : DbContext
    {
        public iskkContext()
        {
        }

        public iskkContext(DbContextOptions<iskkContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Avalynė> Avalynės { get; set; }
        public virtual DbSet<Dizaineri> Dizaineris { get; set; }
        public virtual DbSet<Gamintoja> Gamintojas { get; set; }
        public virtual DbSet<Medžiaga> Medžiagas { get; set; }
        public virtual DbSet<Modeli> Modelis { get; set; }
        public virtual DbSet<Naudoja> Naudojas { get; set; }
        public virtual DbSet<Samdo> Samdos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("server=localhost; port=3306; user=root; password=; database=iskk;SslMode=none");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Avalynė>(entity =>
            {
                entity.HasKey(e => e.IndividualusNumeris)
                    .HasName("PRIMARY");

                entity.ToTable("avalynė");

                entity.HasIndex(e => e.FkModelisidModelis, "turi");

                entity.Property(e => e.IndividualusNumeris)
                    .HasColumnType("int(11)")
                    .HasColumnName("individualus_numeris");

                entity.Property(e => e.Dydis)
                    .HasColumnType("int(11)")
                    .HasColumnName("dydis");

                entity.Property(e => e.FkModelisidModelis)
                    .HasColumnType("int(11)")
                    .HasColumnName("fk_Modelisid_Modelis");

                entity.Property(e => e.Kaina).HasColumnName("kaina");

                entity.Property(e => e.PagaminimoData)
                    .HasColumnType("date")
                    .HasColumnName("pagaminimo_data");

                entity.Property(e => e.PartijosNumeris)
                    .HasColumnType("int(11)")
                    .HasColumnName("partijos_numeris");

                entity.Property(e => e.Spalva)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("spalva");

                entity.HasOne(d => d.FkModelisidModelisNavigation)
                    .WithMany(p => p.Avalynės)
                    .HasForeignKey(d => d.FkModelisidModelis)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("turi");
            });

            modelBuilder.Entity<Dizaineri>(entity =>
            {
                entity.HasKey(e => e.AsmensKodas)
                    .HasName("PRIMARY");

                entity.ToTable("dizaineris");

                entity.Property(e => e.AsmensKodas)
                    .HasColumnType("int(11)")
                    .HasColumnName("asmens_kodas");

                entity.Property(e => e.GimimoData)
                    .HasColumnType("date")
                    .HasColumnName("gimimo_data");

                entity.Property(e => e.Pavardė)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("pavardė");

                entity.Property(e => e.Vardas)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("vardas");
            });

            modelBuilder.Entity<Gamintoja>(entity =>
            {
                entity.HasKey(e => e.IdGamintojas)
                    .HasName("PRIMARY");

                entity.ToTable("gamintojas");

                entity.Property(e => e.IdGamintojas)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_Gamintojas");

                entity.Property(e => e.MetinisPelnas)
                    .HasColumnType("int(11)")
                    .HasColumnName("metinis_pelnas");

                entity.Property(e => e.Pavadinimas)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("pavadinimas");

                entity.Property(e => e.ĮkūrimoData)
                    .HasColumnType("date")
                    .HasColumnName("įkūrimo_data");
            });

            modelBuilder.Entity<Medžiaga>(entity =>
            {
                entity.HasKey(e => e.IdMedžiaga)
                    .HasName("PRIMARY");

                entity.ToTable("medžiaga");

                entity.Property(e => e.IdMedžiaga)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_Medžiaga");

                entity.Property(e => e.Apdirbimas)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("apdirbimas");

                entity.Property(e => e.Pavadinimas)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("pavadinimas");

                entity.Property(e => e.Tipas)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("tipas");
            });

            modelBuilder.Entity<Modeli>(entity =>
            {
                entity.HasKey(e => e.IdModelis)
                    .HasName("PRIMARY");

                entity.ToTable("modelis");

                entity.HasIndex(e => e.FkDizainerisasmensKodas, "kuria");

                entity.HasIndex(e => e.FkGamintojasidGamintojas, "priklauso");

                entity.Property(e => e.IdModelis)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_Modelis");

                entity.Property(e => e.FkDizainerisasmensKodas)
                    .HasColumnType("int(11)")
                    .HasColumnName("fk_Dizainerisasmens_kodas");

                entity.Property(e => e.FkGamintojasidGamintojas)
                    .HasColumnType("int(11)")
                    .HasColumnName("fk_Gamintojasid_Gamintojas");

                entity.Property(e => e.PatentoNumeris)
                    .HasColumnType("int(11)")
                    .HasColumnName("patento_numeris");

                entity.Property(e => e.Pavadinimas)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("pavadinimas");

                entity.Property(e => e.SukūrimoData)
                    .HasColumnType("date")
                    .HasColumnName("sukūrimo_data");

                entity.HasOne(d => d.FkDizainerisasmensKodasNavigation)
                    .WithMany(p => p.Modelis)
                    .HasForeignKey(d => d.FkDizainerisasmensKodas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("kuria");

                entity.HasOne(d => d.FkGamintojasidGamintojasNavigation)
                    .WithMany(p => p.Modelis)
                    .HasForeignKey(d => d.FkGamintojasidGamintojas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("priklauso");
            });

            modelBuilder.Entity<Naudoja>(entity =>
            {
                entity.HasKey(e => new { e.FkAvalynėindividualusNumeris, e.FkMedžiagaidMedžiaga })
                    .HasName("PRIMARY");

                entity.ToTable("naudoja");

                entity.HasIndex(e => e.FkMedžiagaidMedžiaga, "fk_Medžiagaid_Medžiaga");

                entity.Property(e => e.FkAvalynėindividualusNumeris)
                    .HasColumnType("int(11)")
                    .HasColumnName("fk_Avalynėindividualus_numeris");

                entity.Property(e => e.FkMedžiagaidMedžiaga)
                    .HasColumnType("int(11)")
                    .HasColumnName("fk_Medžiagaid_Medžiaga");

                entity.Property(e => e.id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.HasOne(d => d.FkAvalynėindividualusNumerisNavigation)
                    .WithMany(p => p.Naudojas)
                    .HasForeignKey(d => d.FkAvalynėindividualusNumeris)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("naudoja");

                entity.HasOne(d => d.FkMedžiagaidMedžiagaNavigation)
                    .WithMany(p => p.Naudojas)
                    .HasForeignKey(d => d.FkMedžiagaidMedžiaga)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("naudoja_ibfk_1");
            });

            modelBuilder.Entity<Samdo>(entity =>
            {
                entity.HasKey(e => new { e.FkDizainerisasmensKodas, e.FkGamintojasidGamintojas })
                    .HasName("PRIMARY");

                entity.ToTable("samdo");

                entity.HasIndex(e => e.FkGamintojasidGamintojas, "test");

                entity.Property(e => e.FkDizainerisasmensKodas)
                    .HasColumnType("int(11)")
                    .HasColumnName("fk_Dizainerisasmens_kodas");

                entity.Property(e => e.FkGamintojasidGamintojas)
                    .HasColumnType("int(11)")
                    .HasColumnName("fk_Gamintojasid_Gamintojas");

                entity.Property(e => e.id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.HasOne(d => d.FkDizainerisasmensKodasNavigation)
                    .WithMany(p => p.Samdos)
                    .HasForeignKey(d => d.FkDizainerisasmensKodas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("samdo");

                entity.HasOne(d => d.FkGamintojasidGamintojasNavigation)
                    .WithMany(p => p.Samdos)
                    .HasForeignKey(d => d.FkGamintojasidGamintojas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("test");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
