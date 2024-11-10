using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SITEC.GLOBAL.Migrations
{
    /// <inheritdoc />
    public partial class removedseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Grupo",
                keyColumn: "GrupoId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Grupo",
                keyColumn: "GrupoId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Grupo",
                keyColumn: "GrupoId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Grupo",
                keyColumn: "GrupoId",
                keyValue: 4);

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Materia",
                columns: new[] { "MateriaId", "Creditos", "HoraFinal", "HorarioInicio", "IsGlobal", "Name", "Serie" },
                values: new object[,]
                {
                    { 1, 5, new TimeOnly(14, 0, 0), new TimeOnly(13, 0, 0), true, "Gestion de proyectos de softweare", "SC-GP24" },
                    { 2, 5, new TimeOnly(16, 0, 0), new TimeOnly(15, 0, 0), true, "Inteligencia Artificial", "SC-IA24" },
                    { 3, 5, new TimeOnly(17, 0, 0), new TimeOnly(16, 0, 0), true, "Taller De Investigación", "SC-TI24" }
                });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "SemestreMateria",
                keyColumn: "SemestreMateriasId",
                keyValue: 1,
                column: "MateriaId",
                value: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Materia",
                keyColumn: "MateriaId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Materia",
                keyColumn: "MateriaId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Materia",
                keyColumn: "MateriaId",
                keyValue: 3);

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Grupo",
                columns: new[] { "GrupoId", "AlumnoId", "MaestroId", "MateriaId" },
                values: new object[,]
                {
                    { 1, 20211848, 1, 1 },
                    { 2, 1, 1, 1 },
                    { 3, 2, 1, 1 },
                    { 4, 3, 1, 1 }
                });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "SemestreMateria",
                keyColumn: "SemestreMateriasId",
                keyValue: 1,
                column: "MateriaId",
                value: 1);
        }
    }
}
