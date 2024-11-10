using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SITEC.GLOBAL.Migrations
{
    /// <inheritdoc />
    public partial class CreateCatalog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Maestro",
                schema: "dbo",
                columns: table => new
                {
                    MaestroId = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maestro", x => x.MaestroId);
                });

            migrationBuilder.CreateTable(
                name: "Materia",
                schema: "dbo",
                columns: table => new
                {
                    MateriaId = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    HorarioInicio = table.Column<TimeOnly>(type: "time", maxLength: 500, nullable: false),
                    HoraFinal = table.Column<TimeOnly>(type: "time", maxLength: 500, nullable: false),
                    Serie = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsGlobal = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materia", x => x.MateriaId);
                });

            migrationBuilder.CreateTable(
                name: "Semestre",
                schema: "dbo",
                columns: table => new
                {
                    SemestreId = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semestre", x => x.SemestreId);
                });

            migrationBuilder.CreateTable(
                name: "Alumnos",
                schema: "dbo",
                columns: table => new
                {
                    NumeroControl = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    SemestreId = table.Column<int>(type: "int", nullable: false),
                    Carrera = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreditosTotales = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    CreditosUsados = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumnos", x => x.NumeroControl);
                    table.ForeignKey(
                        name: "FK_Alumnos_Semestre_SemestreId",
                        column: x => x.SemestreId,
                        principalSchema: "dbo",
                        principalTable: "Semestre",
                        principalColumn: "SemestreId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SemestreMateria",
                schema: "dbo",
                columns: table => new
                {
                    SemestreMateriasId = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SemestreId = table.Column<int>(type: "int", nullable: false),
                    MateriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SemestreMateria", x => x.SemestreMateriasId);
                    table.ForeignKey(
                        name: "FK_SemestreMateria_Materia_MateriaId",
                        column: x => x.MateriaId,
                        principalSchema: "dbo",
                        principalTable: "Materia",
                        principalColumn: "MateriaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SemestreMateria_Semestre_SemestreId",
                        column: x => x.SemestreId,
                        principalSchema: "dbo",
                        principalTable: "Semestre",
                        principalColumn: "SemestreId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Grupo",
                schema: "dbo",
                columns: table => new
                {
                    GrupoId = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaestroId = table.Column<int>(type: "int", nullable: false),
                    MateriaId = table.Column<int>(type: "int", nullable: false),
                    AlumnoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupo", x => x.GrupoId);
                    table.ForeignKey(
                        name: "FK_Grupo_Alumnos_AlumnoId",
                        column: x => x.AlumnoId,
                        principalSchema: "dbo",
                        principalTable: "Alumnos",
                        principalColumn: "NumeroControl",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Grupo_Maestro_MaestroId",
                        column: x => x.MaestroId,
                        principalSchema: "dbo",
                        principalTable: "Maestro",
                        principalColumn: "MaestroId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Grupo_Materia_MateriaId",
                        column: x => x.MateriaId,
                        principalSchema: "dbo",
                        principalTable: "Materia",
                        principalColumn: "MateriaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Maestro",
                columns: new[] { "MaestroId", "Name" },
                values: new object[,]
                {
                    { 1, "Alma Sofia" },
                    { 2, "Sergio Magdaleno" },
                    { 3, "El de IA" },
                    { 4, "Miguel Angel" },
                    { 5, "Miramontes" },
                    { 6, "Jose Jonathan" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Materia",
                columns: new[] { "MateriaId", "HoraFinal", "HorarioInicio", "IsGlobal", "Name", "Serie" },
                values: new object[,]
                {
                    { 1, new TimeOnly(14, 0, 0), new TimeOnly(13, 0, 0), true, "Gestion de proyectos de softweare", "SC-GP24" },
                    { 2, new TimeOnly(16, 0, 0), new TimeOnly(15, 0, 0), true, "Inteligencia Artificial", "SC-IA24" },
                    { 3, new TimeOnly(17, 0, 0), new TimeOnly(16, 0, 0), true, "Taller De Investigación", "SC-TI24" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Semestre",
                columns: new[] { "SemestreId", "Name" },
                values: new object[,]
                {
                    { 1, "Primer Semestre" },
                    { 2, "Segundo Semestre" },
                    { 3, "Tercer Semestre" },
                    { 4, "Cuarto Semestre" },
                    { 5, "Quinto Semestre" },
                    { 6, "Sexto Semestre" },
                    { 7, "Septimo Semestre" },
                    { 8, "Octavo Semestre" },
                    { 9, "Noveno Semestre" },
                    { 10, "Decimo Semestre" },
                    { 11, "Onceavo Semestre" },
                    { 12, "Doceavo Semestre" },
                    { 13, "Terceavo Semestre" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Alumnos",
                columns: new[] { "NumeroControl", "Carrera", "CreditosTotales", "CreditosUsados", "Email", "Name", "Password", "SemestreId" },
                values: new object[,]
                {
                    { 1, "Ing. Sistemas Computacionales", 1, 0, "1@tectijuana.edu.mx", "Edgar Uriel Rosales Espinoza", "12345", 8 },
                    { 2, "Ing. Sistemas Computacionales", 1, 0, "2@tectijuana.edu.mx", "Alan Jimenez Herrera", "12345", 8 },
                    { 3, "Ing. Sistemas Computacionales", 1, 0, "3tectijuana.edu.mx", "Yahir Emiliano Gonzalez Dominguez", "12345", 8 },
                    { 20211848, "Ing. Sistemas Computacionales", 1, 0, "l20211848@tectijuana.edu.mx", "Sergio Rosario Sobrado Espinoza", "Sobrado18", 8 }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "SemestreMateria",
                columns: new[] { "SemestreMateriasId", "MateriaId", "SemestreId" },
                values: new object[,]
                {
                    { 1, 1, 8 },
                    { 3, 3, 8 },
                    { 12, 2, 8 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alumnos_SemestreId",
                schema: "dbo",
                table: "Alumnos",
                column: "SemestreId");

            migrationBuilder.CreateIndex(
                name: "IX_Grupo_AlumnoId",
                schema: "dbo",
                table: "Grupo",
                column: "AlumnoId");

            migrationBuilder.CreateIndex(
                name: "IX_Grupo_MaestroId",
                schema: "dbo",
                table: "Grupo",
                column: "MaestroId");

            migrationBuilder.CreateIndex(
                name: "IX_Grupo_MateriaId",
                schema: "dbo",
                table: "Grupo",
                column: "MateriaId");

            migrationBuilder.CreateIndex(
                name: "IX_SemestreMateria_MateriaId",
                schema: "dbo",
                table: "SemestreMateria",
                column: "MateriaId");

            migrationBuilder.CreateIndex(
                name: "IX_SemestreMateria_SemestreId",
                schema: "dbo",
                table: "SemestreMateria",
                column: "SemestreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Grupo",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SemestreMateria",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Alumnos",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Maestro",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Materia",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Semestre",
                schema: "dbo");
        }
    }
}
