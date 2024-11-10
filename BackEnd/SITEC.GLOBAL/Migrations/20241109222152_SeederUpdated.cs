using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SITEC.GLOBAL.Migrations
{
    /// <inheritdoc />
    public partial class SeederUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Alumnos",
                columns: new[] { "NumeroControl", "Carrera", "CreditosTotales", "CreditosUsados", "Email", "IsAdmin", "Name", "Password", "SemestreId", "TokensTotales", "TokensUsados" },
                values: new object[] { 100, "Departamento", 1, 0, "admin@tectijuana.edu.mx", true, "Admin", "12345", 8, 0, 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Alumnos",
                keyColumn: "NumeroControl",
                keyValue: 100);
        }
    }
}
