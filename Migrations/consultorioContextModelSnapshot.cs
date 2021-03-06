// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using api_web.Context;

#nullable disable

namespace api_web.Migrations
{
    [DbContext(typeof(ConsultorioContext))]
    partial class ConsultorioContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("api_web.Models.Calle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("direccion");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Direccion" }, "calle_direccion_key")
                        .IsUnique();

                    b.ToTable("calle", (string)null);
                });

            modelBuilder.Entity("api_web.Models.Consultoriomedico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)")
                        .HasColumnName("nombre");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Nombre" }, "consultoriomedico_nombre_key")
                        .IsUnique();

                    b.ToTable("consultoriomedico", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nombre = "consultorio"
                        });
                });

            modelBuilder.Entity("api_web.Models.Enfermedad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Tipoenfermedad")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("tipoenfermedad");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Tipoenfermedad" }, "enfermedad_tipoenfermedad_key")
                        .IsUnique();

                    b.ToTable("enfermedad", (string)null);
                });

            modelBuilder.Entity("api_web.Models.Factorriesgo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Tipofactorriesgo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("tipofactorriesgo");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Tipofactorriesgo" }, "factorriesgo_tipofactorriesgo_key")
                        .IsUnique();

                    b.ToTable("factorriesgo", (string)null);
                });

            modelBuilder.Entity("api_web.Models.Grupo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Tipogrupo")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("tipogrupo");

                    b.HasKey("Id");

                    b.ToTable("grupo", (string)null);
                });

            modelBuilder.Entity("api_web.Models.Hojacargo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Consultoriomedicoid")
                        .HasColumnType("integer")
                        .HasColumnName("consultoriomedicoid");

                    b.Property<DateOnly>("Fechahojacargo")
                        .HasColumnType("date")
                        .HasColumnName("fechahojacargo");

                    b.Property<int>("Userid")
                        .HasColumnType("integer")
                        .HasColumnName("userid");

                    b.HasKey("Id");

                    b.HasIndex("Consultoriomedicoid");

                    b.HasIndex("Userid");

                    b.ToTable("hojacargo", (string)null);
                });

            modelBuilder.Entity("api_web.Models.Intervension", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Tipointervension")
                        .HasColumnType("integer")
                        .HasColumnName("tipointervension");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Tipointervension" }, "intervension_tipointervension_key")
                        .IsUnique();

                    b.ToTable("intervension", (string)null);
                });

            modelBuilder.Entity("api_web.Models.Poblacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("character varying(80)")
                        .HasColumnName("apellidos");

                    b.Property<int>("Calleid")
                        .HasColumnType("integer")
                        .HasColumnName("calleid");

                    b.Property<int>("Consultoriomedicoid")
                        .HasColumnType("integer")
                        .HasColumnName("consultoriomedicoid");

                    b.Property<int>("Edad")
                        .HasColumnType("integer")
                        .HasColumnName("edad");

                    b.Property<DateOnly>("Fechaa")
                        .HasColumnType("date")
                        .HasColumnName("fechaa");

                    b.Property<DateOnly>("Fechahojacargo")
                        .HasColumnType("date")
                        .HasColumnName("fechahojacargo");

                    b.Property<DateOnly>("Fechanecimiento")
                        .HasColumnType("date")
                        .HasColumnName("fechanecimiento");

                    b.Property<int>("Grupoid")
                        .HasColumnType("integer")
                        .HasColumnName("grupoid");

                    b.Property<string>("NoNucleo")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("no_nucleo");

                    b.Property<string>("NoVivienda")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("no_vivienda");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("nombre");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("sexo");

                    b.HasKey("Id");

                    b.HasIndex("Calleid");

                    b.HasIndex("Consultoriomedicoid");

                    b.HasIndex("Grupoid");

                    b.ToTable("poblacion", (string)null);
                });

            modelBuilder.Entity("api_web.Models.Poblacionenfermedad", b =>
                {
                    b.Property<int>("Enfermedadid")
                        .HasColumnType("integer")
                        .HasColumnName("enfermedadid");

                    b.Property<int>("Poblacionid")
                        .HasColumnType("integer")
                        .HasColumnName("poblacionid");

                    b.Property<DateOnly>("Fecha")
                        .HasColumnType("date")
                        .HasColumnName("fecha");

                    b.HasKey("Enfermedadid", "Poblacionid")
                        .HasName("poblacionenfermedad_pkey");

                    b.HasIndex("Poblacionid");

                    b.ToTable("poblacionenfermedad", (string)null);
                });

            modelBuilder.Entity("api_web.Models.Poblacionfactorriesgo", b =>
                {
                    b.Property<int>("Factorriesgoid")
                        .HasColumnType("integer")
                        .HasColumnName("factorriesgoid");

                    b.Property<int>("Poblacionid")
                        .HasColumnType("integer")
                        .HasColumnName("poblacionid");

                    b.Property<int>("Fecha")
                        .HasColumnType("integer")
                        .HasColumnName("fecha");

                    b.HasKey("Factorriesgoid", "Poblacionid")
                        .HasName("poblacionfactorriesgo_pkey");

                    b.HasIndex("Poblacionid");

                    b.ToTable("poblacionfactorriesgo", (string)null);
                });

            modelBuilder.Entity("api_web.Models.Poblacionhojacargo", b =>
                {
                    b.Property<int>("Hojacargoid")
                        .HasColumnType("integer")
                        .HasColumnName("hojacargoid");

                    b.Property<int>("Poblacionid")
                        .HasColumnType("integer")
                        .HasColumnName("poblacionid");

                    b.Property<string>("Conducta")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("conducta");

                    b.Property<string>("Numhc")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)")
                        .HasColumnName("numhc");

                    b.Property<string>("Problemasalud")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("problemasalud");

                    b.Property<int>("Tipoconsultamid")
                        .HasColumnType("integer")
                        .HasColumnName("tipoconsultamid");

                    b.HasKey("Hojacargoid", "Poblacionid")
                        .HasName("poblacionhojacargo_pkey");

                    b.HasIndex("Poblacionid");

                    b.HasIndex("Tipoconsultamid");

                    b.ToTable("poblacionhojacargo", (string)null);
                });

            modelBuilder.Entity("api_web.Models.Poblacionintervension", b =>
                {
                    b.Property<int>("Intervensionid")
                        .HasColumnType("integer")
                        .HasColumnName("intervensionid");

                    b.Property<int>("Poblacionid")
                        .HasColumnType("integer")
                        .HasColumnName("poblacionid");

                    b.Property<DateOnly>("Fecha")
                        .HasColumnType("date")
                        .HasColumnName("fecha");

                    b.HasKey("Intervensionid", "Poblacionid")
                        .HasName("poblacionintervension_pkey");

                    b.HasIndex("Poblacionid");

                    b.ToTable("poblacionintervension", (string)null);
                });

            modelBuilder.Entity("api_web.Models.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("role");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Name" }, "rol_name_key")
                        .IsUnique();

                    b.HasIndex(new[] { "Role" }, "rol_role_key")
                        .IsUnique();

                    b.ToTable("rol", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Administrador",
                            Role = "ROLE_ADMIN"
                        });
                });

            modelBuilder.Entity("api_web.Models.Tipoconsultam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)")
                        .HasColumnName("tipo");

                    b.HasKey("Id");

                    b.ToTable("tipoconsultam", (string)null);
                });

            modelBuilder.Entity("api_web.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellidos")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("apellidos");

                    b.Property<int>("Consultoriomedicoid")
                        .HasColumnType("integer")
                        .HasColumnName("consultoriomedicoid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("email");

                    b.Property<DateOnly?>("Fecha")
                        .HasColumnType("date")
                        .HasColumnName("fecha");

                    b.Property<bool?>("Isactivo")
                        .HasColumnType("boolean")
                        .HasColumnName("isactivo");

                    b.Property<string>("Nombre")
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)")
                        .HasColumnName("nombre");

                    b.Property<byte[]>("Password")
                        .IsRequired()
                        .HasColumnType("bytea")
                        .HasColumnName("password");

                    b.Property<byte[]>("Passwordsalt")
                        .IsRequired()
                        .HasColumnType("bytea")
                        .HasColumnName("passwordsalt");

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("usuario");

                    b.HasKey("Id");

                    b.HasIndex("Consultoriomedicoid");

                    b.HasIndex(new[] { "Usuario" }, "User_usuario_key")
                        .IsUnique();

                    b.ToTable("User", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Consultoriomedicoid = 1,
                            Email = "admin@gmail.com",
                            Password = new byte[] { 247, 115, 186, 192, 35, 179, 179, 194, 90, 126, 166, 251, 189, 159, 220, 139, 222, 183, 155, 79, 148, 153, 105, 246, 236, 44, 18, 11, 198, 155, 115, 85, 66, 120, 163, 63, 142, 82, 201, 194, 201, 215, 149, 96, 245, 93, 36, 101, 192, 158, 128, 38, 224, 250, 87, 177, 70, 7, 44, 50, 78, 229, 234, 217 },
                            Passwordsalt = new byte[] { 247, 27, 85, 219, 243, 1, 75, 113, 255, 25, 44, 39, 56, 207, 57, 146, 132, 223, 8, 211, 50, 179, 25, 44, 72, 167, 3, 246, 96, 227, 91, 9, 129, 74, 225, 31, 108, 199, 121, 77, 31, 217, 111, 49, 144, 91, 242, 246, 199, 251, 241, 106, 216, 64, 234, 6, 151, 12, 25, 62, 114, 158, 124, 13, 73, 69, 103, 93, 75, 115, 227, 125, 19, 32, 82, 64, 89, 69, 5, 27, 39, 167, 201, 144, 232, 49, 9, 4, 174, 82, 177, 91, 176, 164, 104, 7, 21, 51, 191, 153, 191, 198, 215, 222, 57, 183, 213, 55, 185, 133, 132, 214, 161, 127, 173, 32, 139, 124, 182, 207, 172, 246, 185, 150, 7, 92, 155, 16 },
                            Usuario = "admin"
                        });
                });

            modelBuilder.Entity("api_web.Models.Userrol", b =>
                {
                    b.Property<int>("Userid")
                        .HasColumnType("integer")
                        .HasColumnName("userid");

                    b.Property<int>("Rolid")
                        .HasColumnType("integer")
                        .HasColumnName("rolid");

                    b.Property<DateOnly>("Fecha")
                        .HasColumnType("date")
                        .HasColumnName("fecha");

                    b.HasKey("Userid", "Rolid")
                        .HasName("userrol_pkey");

                    b.HasIndex("Rolid");

                    b.ToTable("userrol", (string)null);

                    b.HasData(
                        new
                        {
                            Userid = 1,
                            Rolid = 1,
                            Fecha = new DateOnly(1, 1, 1)
                        });
                });

            modelBuilder.Entity("api_web.Models.Hojacargo", b =>
                {
                    b.HasOne("api_web.Models.Consultoriomedico", "Consultoriomedico")
                        .WithMany("Hojacargos")
                        .HasForeignKey("Consultoriomedicoid")
                        .IsRequired()
                        .HasConstraintName("fkhojacargo540741");

                    b.HasOne("api_web.Models.User", "User")
                        .WithMany("Hojacargos")
                        .HasForeignKey("Userid")
                        .IsRequired()
                        .HasConstraintName("fkhojacargo781604");

                    b.Navigation("Consultoriomedico");

                    b.Navigation("User");
                });

            modelBuilder.Entity("api_web.Models.Poblacion", b =>
                {
                    b.HasOne("api_web.Models.Calle", "Calle")
                        .WithMany("Poblacions")
                        .HasForeignKey("Calleid")
                        .IsRequired()
                        .HasConstraintName("fkpoblacion220247");

                    b.HasOne("api_web.Models.Consultoriomedico", "Consultoriomedico")
                        .WithMany("Poblacions")
                        .HasForeignKey("Consultoriomedicoid")
                        .IsRequired()
                        .HasConstraintName("fkpoblacion581792");

                    b.HasOne("api_web.Models.Grupo", "Grupo")
                        .WithMany("Poblacions")
                        .HasForeignKey("Grupoid")
                        .IsRequired()
                        .HasConstraintName("fkpoblacion827720");

                    b.Navigation("Calle");

                    b.Navigation("Consultoriomedico");

                    b.Navigation("Grupo");
                });

            modelBuilder.Entity("api_web.Models.Poblacionenfermedad", b =>
                {
                    b.HasOne("api_web.Models.Enfermedad", "Enfermedad")
                        .WithMany("Poblacionenfermedads")
                        .HasForeignKey("Enfermedadid")
                        .IsRequired()
                        .HasConstraintName("fkpoblacione12061");

                    b.HasOne("api_web.Models.Poblacion", "Poblacion")
                        .WithMany("Poblacionenfermedads")
                        .HasForeignKey("Poblacionid")
                        .IsRequired()
                        .HasConstraintName("fkpoblacione802691");

                    b.Navigation("Enfermedad");

                    b.Navigation("Poblacion");
                });

            modelBuilder.Entity("api_web.Models.Poblacionfactorriesgo", b =>
                {
                    b.HasOne("api_web.Models.Factorriesgo", "Factorriesgo")
                        .WithMany("Poblacionfactorriesgos")
                        .HasForeignKey("Factorriesgoid")
                        .IsRequired()
                        .HasConstraintName("fkpoblacionf506289");

                    b.HasOne("api_web.Models.Poblacion", "Poblacion")
                        .WithMany("Poblacionfactorriesgos")
                        .HasForeignKey("Poblacionid")
                        .IsRequired()
                        .HasConstraintName("fkpoblacionf462279");

                    b.Navigation("Factorriesgo");

                    b.Navigation("Poblacion");
                });

            modelBuilder.Entity("api_web.Models.Poblacionhojacargo", b =>
                {
                    b.HasOne("api_web.Models.Hojacargo", "Hojacargo")
                        .WithMany("Poblacionhojacargos")
                        .HasForeignKey("Hojacargoid")
                        .IsRequired()
                        .HasConstraintName("fkpoblacionh619752");

                    b.HasOne("api_web.Models.Poblacion", "Poblacion")
                        .WithMany("Poblacionhojacargos")
                        .HasForeignKey("Poblacionid")
                        .IsRequired()
                        .HasConstraintName("fkpoblacionh179340");

                    b.HasOne("api_web.Models.Tipoconsultam", "Tipoconsultam")
                        .WithMany("Poblacionhojacargos")
                        .HasForeignKey("Tipoconsultamid")
                        .IsRequired()
                        .HasConstraintName("fkpoblacionh100994");

                    b.Navigation("Hojacargo");

                    b.Navigation("Poblacion");

                    b.Navigation("Tipoconsultam");
                });

            modelBuilder.Entity("api_web.Models.Poblacionintervension", b =>
                {
                    b.HasOne("api_web.Models.Intervension", "Intervension")
                        .WithMany("Poblacionintervensions")
                        .HasForeignKey("Intervensionid")
                        .IsRequired()
                        .HasConstraintName("fkpoblacioni964699");

                    b.HasOne("api_web.Models.Poblacion", "Poblacion")
                        .WithMany("Poblacionintervensions")
                        .HasForeignKey("Poblacionid")
                        .IsRequired()
                        .HasConstraintName("fkpoblacioni2572");

                    b.Navigation("Intervension");

                    b.Navigation("Poblacion");
                });

            modelBuilder.Entity("api_web.Models.User", b =>
                {
                    b.HasOne("api_web.Models.Consultoriomedico", "Consultoriomedico")
                        .WithMany("Users")
                        .HasForeignKey("Consultoriomedicoid")
                        .IsRequired()
                        .HasConstraintName("fkuser453198");

                    b.Navigation("Consultoriomedico");
                });

            modelBuilder.Entity("api_web.Models.Userrol", b =>
                {
                    b.HasOne("api_web.Models.Rol", "Rol")
                        .WithMany("Userrols")
                        .HasForeignKey("Rolid")
                        .IsRequired()
                        .HasConstraintName("fkuserrol738036");

                    b.HasOne("api_web.Models.User", "User")
                        .WithMany("Userrols")
                        .HasForeignKey("Userid")
                        .IsRequired()
                        .HasConstraintName("fkuserrol5560");

                    b.Navigation("Rol");

                    b.Navigation("User");
                });

            modelBuilder.Entity("api_web.Models.Calle", b =>
                {
                    b.Navigation("Poblacions");
                });

            modelBuilder.Entity("api_web.Models.Consultoriomedico", b =>
                {
                    b.Navigation("Hojacargos");

                    b.Navigation("Poblacions");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("api_web.Models.Enfermedad", b =>
                {
                    b.Navigation("Poblacionenfermedads");
                });

            modelBuilder.Entity("api_web.Models.Factorriesgo", b =>
                {
                    b.Navigation("Poblacionfactorriesgos");
                });

            modelBuilder.Entity("api_web.Models.Grupo", b =>
                {
                    b.Navigation("Poblacions");
                });

            modelBuilder.Entity("api_web.Models.Hojacargo", b =>
                {
                    b.Navigation("Poblacionhojacargos");
                });

            modelBuilder.Entity("api_web.Models.Intervension", b =>
                {
                    b.Navigation("Poblacionintervensions");
                });

            modelBuilder.Entity("api_web.Models.Poblacion", b =>
                {
                    b.Navigation("Poblacionenfermedads");

                    b.Navigation("Poblacionfactorriesgos");

                    b.Navigation("Poblacionhojacargos");

                    b.Navigation("Poblacionintervensions");
                });

            modelBuilder.Entity("api_web.Models.Rol", b =>
                {
                    b.Navigation("Userrols");
                });

            modelBuilder.Entity("api_web.Models.Tipoconsultam", b =>
                {
                    b.Navigation("Poblacionhojacargos");
                });

            modelBuilder.Entity("api_web.Models.User", b =>
                {
                    b.Navigation("Hojacargos");

                    b.Navigation("Userrols");
                });
#pragma warning restore 612, 618
        }
    }
}
