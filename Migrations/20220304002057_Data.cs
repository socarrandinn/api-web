using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace api_web.Migrations
{
    public partial class Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "calle",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    direccion = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_calle", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "consultoriomedico",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_consultoriomedico", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "enfermedad",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tipoenfermedad = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_enfermedad", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "factorriesgo",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tipofactorriesgo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_factorriesgo", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "grupo",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tipogrupo = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grupo", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "intervension",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tipointervension = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_intervension", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "rol",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    role = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rol", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tipoconsultam",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tipo = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipoconsultam", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    usuario = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    password = table.Column<byte[]>(type: "bytea", nullable: false),
                    nombre = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    apellidos = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    fecha = table.Column<DateOnly>(type: "date", nullable: true),
                    email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    passwordsalt = table.Column<byte[]>(type: "bytea", nullable: false),
                    consultoriomedicoid = table.Column<int>(type: "integer", nullable: false),
                    isactivo = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                    table.ForeignKey(
                        name: "fkuser453198",
                        column: x => x.consultoriomedicoid,
                        principalTable: "consultoriomedico",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "poblacion",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    apellidos = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    no_nucleo = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    no_vivienda = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    edad = table.Column<int>(type: "integer", nullable: false),
                    sexo = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    fechanecimiento = table.Column<DateOnly>(type: "date", nullable: false),
                    fechahojacargo = table.Column<DateOnly>(type: "date", nullable: false),
                    fechaa = table.Column<DateOnly>(type: "date", nullable: false),
                    calleid = table.Column<int>(type: "integer", nullable: false),
                    consultoriomedicoid = table.Column<int>(type: "integer", nullable: false),
                    grupoid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_poblacion", x => x.id);
                    table.ForeignKey(
                        name: "fkpoblacion220247",
                        column: x => x.calleid,
                        principalTable: "calle",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fkpoblacion581792",
                        column: x => x.consultoriomedicoid,
                        principalTable: "consultoriomedico",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fkpoblacion827720",
                        column: x => x.grupoid,
                        principalTable: "grupo",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "hojacargo",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fechahojacargo = table.Column<DateOnly>(type: "date", nullable: false),
                    consultoriomedicoid = table.Column<int>(type: "integer", nullable: false),
                    userid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hojacargo", x => x.id);
                    table.ForeignKey(
                        name: "fkhojacargo540741",
                        column: x => x.consultoriomedicoid,
                        principalTable: "consultoriomedico",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fkhojacargo781604",
                        column: x => x.userid,
                        principalTable: "User",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "userrol",
                columns: table => new
                {
                    userid = table.Column<int>(type: "integer", nullable: false),
                    rolid = table.Column<int>(type: "integer", nullable: false),
                    fecha = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("userrol_pkey", x => new { x.userid, x.rolid });
                    table.ForeignKey(
                        name: "fkuserrol5560",
                        column: x => x.userid,
                        principalTable: "User",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fkuserrol738036",
                        column: x => x.rolid,
                        principalTable: "rol",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "poblacionenfermedad",
                columns: table => new
                {
                    enfermedadid = table.Column<int>(type: "integer", nullable: false),
                    poblacionid = table.Column<int>(type: "integer", nullable: false),
                    fecha = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("poblacionenfermedad_pkey", x => new { x.enfermedadid, x.poblacionid });
                    table.ForeignKey(
                        name: "fkpoblacione12061",
                        column: x => x.enfermedadid,
                        principalTable: "enfermedad",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fkpoblacione802691",
                        column: x => x.poblacionid,
                        principalTable: "poblacion",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "poblacionfactorriesgo",
                columns: table => new
                {
                    factorriesgoid = table.Column<int>(type: "integer", nullable: false),
                    poblacionid = table.Column<int>(type: "integer", nullable: false),
                    fecha = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("poblacionfactorriesgo_pkey", x => new { x.factorriesgoid, x.poblacionid });
                    table.ForeignKey(
                        name: "fkpoblacionf462279",
                        column: x => x.poblacionid,
                        principalTable: "poblacion",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fkpoblacionf506289",
                        column: x => x.factorriesgoid,
                        principalTable: "factorriesgo",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "poblacionintervension",
                columns: table => new
                {
                    intervensionid = table.Column<int>(type: "integer", nullable: false),
                    poblacionid = table.Column<int>(type: "integer", nullable: false),
                    fecha = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("poblacionintervension_pkey", x => new { x.intervensionid, x.poblacionid });
                    table.ForeignKey(
                        name: "fkpoblacioni2572",
                        column: x => x.poblacionid,
                        principalTable: "poblacion",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fkpoblacioni964699",
                        column: x => x.intervensionid,
                        principalTable: "intervension",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "poblacionhojacargo",
                columns: table => new
                {
                    hojacargoid = table.Column<int>(type: "integer", nullable: false),
                    poblacionid = table.Column<int>(type: "integer", nullable: false),
                    numhc = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    problemasalud = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    conducta = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    tipoconsultamid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("poblacionhojacargo_pkey", x => new { x.hojacargoid, x.poblacionid });
                    table.ForeignKey(
                        name: "fkpoblacionh100994",
                        column: x => x.tipoconsultamid,
                        principalTable: "tipoconsultam",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fkpoblacionh179340",
                        column: x => x.poblacionid,
                        principalTable: "poblacion",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fkpoblacionh619752",
                        column: x => x.hojacargoid,
                        principalTable: "hojacargo",
                        principalColumn: "id");
                });

            migrationBuilder.InsertData(
                table: "consultoriomedico",
                columns: new[] { "id", "nombre" },
                values: new object[] { 1, "consultorio" });

            migrationBuilder.InsertData(
                table: "rol",
                columns: new[] { "id", "name", "role" },
                values: new object[] { 1, "Administrador", "ROLE_ADMIN" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "id", "apellidos", "consultoriomedicoid", "email", "fecha", "isactivo", "nombre", "password", "passwordsalt", "usuario" },
                values: new object[] { 1, null, 1, "admin@gmail.com", null, null, null, new byte[] { 247, 115, 186, 192, 35, 179, 179, 194, 90, 126, 166, 251, 189, 159, 220, 139, 222, 183, 155, 79, 148, 153, 105, 246, 236, 44, 18, 11, 198, 155, 115, 85, 66, 120, 163, 63, 142, 82, 201, 194, 201, 215, 149, 96, 245, 93, 36, 101, 192, 158, 128, 38, 224, 250, 87, 177, 70, 7, 44, 50, 78, 229, 234, 217 }, new byte[] { 247, 27, 85, 219, 243, 1, 75, 113, 255, 25, 44, 39, 56, 207, 57, 146, 132, 223, 8, 211, 50, 179, 25, 44, 72, 167, 3, 246, 96, 227, 91, 9, 129, 74, 225, 31, 108, 199, 121, 77, 31, 217, 111, 49, 144, 91, 242, 246, 199, 251, 241, 106, 216, 64, 234, 6, 151, 12, 25, 62, 114, 158, 124, 13, 73, 69, 103, 93, 75, 115, 227, 125, 19, 32, 82, 64, 89, 69, 5, 27, 39, 167, 201, 144, 232, 49, 9, 4, 174, 82, 177, 91, 176, 164, 104, 7, 21, 51, 191, 153, 191, 198, 215, 222, 57, 183, 213, 55, 185, 133, 132, 214, 161, 127, 173, 32, 139, 124, 182, 207, 172, 246, 185, 150, 7, 92, 155, 16 }, "admin" });

            migrationBuilder.InsertData(
                table: "userrol",
                columns: new[] { "rolid", "userid", "fecha" },
                values: new object[] { 1, 1, new DateOnly(1, 1, 1) });

            migrationBuilder.CreateIndex(
                name: "calle_direccion_key",
                table: "calle",
                column: "direccion",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "consultoriomedico_nombre_key",
                table: "consultoriomedico",
                column: "nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "enfermedad_tipoenfermedad_key",
                table: "enfermedad",
                column: "tipoenfermedad",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "factorriesgo_tipofactorriesgo_key",
                table: "factorriesgo",
                column: "tipofactorriesgo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_hojacargo_consultoriomedicoid",
                table: "hojacargo",
                column: "consultoriomedicoid");

            migrationBuilder.CreateIndex(
                name: "IX_hojacargo_userid",
                table: "hojacargo",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "intervension_tipointervension_key",
                table: "intervension",
                column: "tipointervension",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_poblacion_calleid",
                table: "poblacion",
                column: "calleid");

            migrationBuilder.CreateIndex(
                name: "IX_poblacion_consultoriomedicoid",
                table: "poblacion",
                column: "consultoriomedicoid");

            migrationBuilder.CreateIndex(
                name: "IX_poblacion_grupoid",
                table: "poblacion",
                column: "grupoid");

            migrationBuilder.CreateIndex(
                name: "IX_poblacionenfermedad_poblacionid",
                table: "poblacionenfermedad",
                column: "poblacionid");

            migrationBuilder.CreateIndex(
                name: "IX_poblacionfactorriesgo_poblacionid",
                table: "poblacionfactorriesgo",
                column: "poblacionid");

            migrationBuilder.CreateIndex(
                name: "IX_poblacionhojacargo_poblacionid",
                table: "poblacionhojacargo",
                column: "poblacionid");

            migrationBuilder.CreateIndex(
                name: "IX_poblacionhojacargo_tipoconsultamid",
                table: "poblacionhojacargo",
                column: "tipoconsultamid");

            migrationBuilder.CreateIndex(
                name: "IX_poblacionintervension_poblacionid",
                table: "poblacionintervension",
                column: "poblacionid");

            migrationBuilder.CreateIndex(
                name: "rol_name_key",
                table: "rol",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "rol_role_key",
                table: "rol",
                column: "role",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_consultoriomedicoid",
                table: "User",
                column: "consultoriomedicoid");

            migrationBuilder.CreateIndex(
                name: "User_usuario_key",
                table: "User",
                column: "usuario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_userrol_rolid",
                table: "userrol",
                column: "rolid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "poblacionenfermedad");

            migrationBuilder.DropTable(
                name: "poblacionfactorriesgo");

            migrationBuilder.DropTable(
                name: "poblacionhojacargo");

            migrationBuilder.DropTable(
                name: "poblacionintervension");

            migrationBuilder.DropTable(
                name: "userrol");

            migrationBuilder.DropTable(
                name: "enfermedad");

            migrationBuilder.DropTable(
                name: "factorriesgo");

            migrationBuilder.DropTable(
                name: "tipoconsultam");

            migrationBuilder.DropTable(
                name: "hojacargo");

            migrationBuilder.DropTable(
                name: "poblacion");

            migrationBuilder.DropTable(
                name: "intervension");

            migrationBuilder.DropTable(
                name: "rol");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "calle");

            migrationBuilder.DropTable(
                name: "grupo");

            migrationBuilder.DropTable(
                name: "consultoriomedico");
        }
    }
}
