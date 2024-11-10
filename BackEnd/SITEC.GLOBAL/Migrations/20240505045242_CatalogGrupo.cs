using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SITEC.GLOBAL.Migrations
{
    /// <inheritdoc />
    public partial class CatalogGrupo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
