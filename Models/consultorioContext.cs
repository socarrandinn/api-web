using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace api_web.Models
{
    public partial class consultorioContext : DbContext
    {
        public consultorioContext()
        {
        }

        public consultorioContext(DbContextOptions<consultorioContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Calle> Calles { get; set; } = null!;
        public virtual DbSet<Consultoriomedico> Consultoriomedicos { get; set; } = null!;
        public virtual DbSet<Consulta> Consulta { get; set; } = null!;
        public virtual DbSet<Enfermedad> Enfermedads { get; set; } = null!;
        public virtual DbSet<Factorriesgo> Factorriesgos { get; set; } = null!;
        public virtual DbSet<Grupo> Grupos { get; set; } = null!;
        public virtual DbSet<Hojacargo> Hojacargos { get; set; } = null!;
        public virtual DbSet<Intervension> Intervensions { get; set; } = null!;
        public virtual DbSet<Poblacion> Poblacions { get; set; } = null!;
        public virtual DbSet<Poblacionenfermedad> Poblacionenfermedads { get; set; } = null!;
        public virtual DbSet<Poblacionfactorriesgo> Poblacionfactorriesgos { get; set; } = null!;
        public virtual DbSet<Poblacionhojacargo> Poblacionhojacargos { get; set; } = null!;
        public virtual DbSet<Poblacionintervension> Poblacionintervensions { get; set; } = null!;
        public virtual DbSet<Rol> Rols { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Userrol> Userrols { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Calle>(entity =>
            {
                entity.ToTable("calle");

                entity.HasIndex(e => e.Direccion, "calle_direccion_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(200)
                    .HasColumnName("direccion");
            });

            modelBuilder.Entity<Consultoriomedico>(entity =>
            {
                entity.ToTable("consultoriomedico");

                entity.HasIndex(e => e.Nombre, "consultoriomedico_nombre_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(150)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Consulta>(entity =>
            {
                entity.ToTable("consulta");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Tipoconsulta)
                    .HasMaxLength(40)
                    .HasColumnName("tipoconsulta");
            });

            modelBuilder.Entity<Enfermedad>(entity =>
            {
                entity.ToTable("enfermedad");

                entity.HasIndex(e => e.Tipoenfermedad, "enfermedad_tipoenfermedad_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Tipoenfermedad)
                    .HasMaxLength(100)
                    .HasColumnName("tipoenfermedad");
            });

            modelBuilder.Entity<Factorriesgo>(entity =>
            {
                entity.ToTable("factorriesgo");

                entity.HasIndex(e => e.Tipofactorriesgo, "factorriesgo_tipofactorriesgo_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Tipofactorriesgo)
                    .HasMaxLength(50)
                    .HasColumnName("tipofactorriesgo");
            });

            modelBuilder.Entity<Grupo>(entity =>
            {
                entity.ToTable("grupo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Tipogrupo)
                    .HasMaxLength(20)
                    .HasColumnName("tipogrupo");
            });

            modelBuilder.Entity<Hojacargo>(entity =>
            {
                entity.ToTable("hojacargo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Consultoriomedicoid).HasColumnName("consultoriomedicoid");

                entity.Property(e => e.Fechahojacargo).HasColumnName("fechahojacargo");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.Consultoriomedico)
                    .WithMany(p => p.Hojacargos)
                    .HasForeignKey(d => d.Consultoriomedicoid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkhojacargo540741");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Hojacargos)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkhojacargo781604");
            });

            modelBuilder.Entity<Intervension>(entity =>
            {
                entity.ToTable("intervension");

                entity.HasIndex(e => e.Tipointervension, "intervension_tipointervension_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Tipointervension).HasColumnName("tipointervension");
            });

            modelBuilder.Entity<Poblacion>(entity =>
            {
                entity.ToTable("poblacion");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(80)
                    .HasColumnName("apellidos");

                entity.Property(e => e.Calleid).HasColumnName("calleid");

                entity.Property(e => e.Consultoriomedicoid).HasColumnName("consultoriomedicoid");

                entity.Property(e => e.Edad).HasColumnName("edad");

                entity.Property(e => e.Fechaa).HasColumnName("fechaa");

                entity.Property(e => e.Fechahojacargo).HasColumnName("fechahojacargo");

                entity.Property(e => e.Fechanecimiento).HasColumnName("fechanecimiento");

                entity.Property(e => e.Grupoid).HasColumnName("grupoid");

                entity.Property(e => e.NoNucleo)
                    .HasMaxLength(10)
                    .HasColumnName("no_nucleo");

                entity.Property(e => e.NoVivienda)
                    .HasMaxLength(20)
                    .HasColumnName("no_vivienda");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("nombre");

                entity.Property(e => e.Sexo)
                    .HasMaxLength(10)
                    .HasColumnName("sexo");

                entity.HasOne(d => d.Calle)
                    .WithMany(p => p.Poblacions)
                    .HasForeignKey(d => d.Calleid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkpoblacion220247");

                entity.HasOne(d => d.Consultoriomedico)
                    .WithMany(p => p.Poblacions)
                    .HasForeignKey(d => d.Consultoriomedicoid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkpoblacion581792");

                entity.HasOne(d => d.Grupo)
                    .WithMany(p => p.Poblacions)
                    .HasForeignKey(d => d.Grupoid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkpoblacion827720");
            });

            modelBuilder.Entity<Poblacionenfermedad>(entity =>
            {
                entity.HasKey(e => new { e.Enfermedadid, e.Poblacionid })
                    .HasName("poblacionenfermedad_pkey");

                entity.ToTable("poblacionenfermedad");

                entity.Property(e => e.Enfermedadid).HasColumnName("enfermedadid");

                entity.Property(e => e.Poblacionid).HasColumnName("poblacionid");

                entity.Property(e => e.Fecha).HasColumnName("fecha");

                entity.HasOne(d => d.Enfermedad)
                    .WithMany(p => p.Poblacionenfermedads)
                    .HasForeignKey(d => d.Enfermedadid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkpoblacione12061");

                entity.HasOne(d => d.Poblacion)
                    .WithMany(p => p.Poblacionenfermedads)
                    .HasForeignKey(d => d.Poblacionid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkpoblacione802691");
            });

            modelBuilder.Entity<Poblacionfactorriesgo>(entity =>
            {
                entity.HasKey(e => new { e.Factorriesgoid, e.Poblacionid })
                    .HasName("poblacionfactorriesgo_pkey");

                entity.ToTable("poblacionfactorriesgo");

                entity.Property(e => e.Factorriesgoid).HasColumnName("factorriesgoid");

                entity.Property(e => e.Poblacionid).HasColumnName("poblacionid");

                entity.Property(e => e.Fecha).HasColumnName("fecha");

                entity.HasOne(d => d.Factorriesgo)
                    .WithMany(p => p.Poblacionfactorriesgos)
                    .HasForeignKey(d => d.Factorriesgoid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkpoblacionf506289");

                entity.HasOne(d => d.Poblacion)
                    .WithMany(p => p.Poblacionfactorriesgos)
                    .HasForeignKey(d => d.Poblacionid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkpoblacionf462279");
            });

            modelBuilder.Entity<Poblacionhojacargo>(entity =>
            {
                entity.HasKey(e => new { e.Hojacargoid, e.Poblacionid })
                    .HasName("poblacionhojacargo_pkey");

                entity.ToTable("poblacionhojacargo");

                entity.Property(e => e.Hojacargoid).HasColumnName("hojacargoid");

                entity.Property(e => e.Poblacionid).HasColumnName("poblacionid");

                entity.Property(e => e.Conducta)
                    .HasMaxLength(255)
                    .HasColumnName("conducta");

                entity.Property(e => e.Consultaid).HasColumnName("consultaid");

                entity.Property(e => e.Numhc)
                    .HasMaxLength(25)
                    .HasColumnName("numhc");

                entity.Property(e => e.Problemasalud)
                    .HasMaxLength(255)
                    .HasColumnName("problemasalud");

                entity.HasOne(d => d.Consulta)
                    .WithMany(p => p.Poblacionhojacargos)
                    .HasForeignKey(d => d.Consultaid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkpoblacionh60564");

                entity.HasOne(d => d.Hojacargo)
                    .WithMany(p => p.Poblacionhojacargos)
                    .HasForeignKey(d => d.Hojacargoid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkpoblacionh619752");

                entity.HasOne(d => d.Poblacion)
                    .WithMany(p => p.Poblacionhojacargos)
                    .HasForeignKey(d => d.Poblacionid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkpoblacionh179340");
            });

            modelBuilder.Entity<Poblacionintervension>(entity =>
            {
                entity.HasKey(e => new { e.Intervensionid, e.Poblacionid })
                    .HasName("poblacionintervension_pkey");

                entity.ToTable("poblacionintervension");

                entity.Property(e => e.Intervensionid).HasColumnName("intervensionid");

                entity.Property(e => e.Poblacionid).HasColumnName("poblacionid");

                entity.Property(e => e.Fecha).HasColumnName("fecha");

                entity.HasOne(d => d.Intervension)
                    .WithMany(p => p.Poblacionintervensions)
                    .HasForeignKey(d => d.Intervensionid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkpoblacioni964699");

                entity.HasOne(d => d.Poblacion)
                    .WithMany(p => p.Poblacionintervensions)
                    .HasForeignKey(d => d.Poblacionid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkpoblacioni2572");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.ToTable("rol");

                entity.HasIndex(e => e.Name, "rol_name_key")
                    .IsUnique();

                entity.HasIndex(e => e.Role, "rol_role_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Role)
                    .HasMaxLength(30)
                    .HasColumnName("role");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.HasIndex(e => e.Usuario, "User_usuario_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(100)
                    .HasColumnName("apellidos");

                entity.Property(e => e.Consultoriomedicoid).HasColumnName("consultoriomedicoid");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.Fecha).HasColumnName("fecha");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(60)
                    .HasColumnName("nombre");

                entity.Property(e => e.Password)
                    .HasMaxLength(150)
                    .HasColumnName("password");

                entity.Property(e => e.Usuario)
                    .HasMaxLength(30)
                    .HasColumnName("usuario");

                entity.HasOne(d => d.Consultoriomedico)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Consultoriomedicoid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkuser453198");
            });

            modelBuilder.Entity<Userrol>(entity =>
            {
                entity.HasKey(e => new { e.Userid, e.Rolid })
                    .HasName("userrol_pkey");

                entity.ToTable("userrol");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.Property(e => e.Rolid).HasColumnName("rolid");

                entity.Property(e => e.Fecha).HasColumnName("fecha");

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.Userrols)
                    .HasForeignKey(d => d.Rolid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkuserrol738036");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Userrols)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkuserrol5560");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
