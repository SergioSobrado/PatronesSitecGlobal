using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SITEC.GLOBAL.Migrations
{
    /// <inheritdoc />
    public partial class Tokens : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TokensTotales",
                schema: "dbo",
                table: "Alumnos",
                type: "int",
                maxLength: 50,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TokensUsados",
                schema: "dbo",
                table: "Alumnos",
                type: "int",
                maxLength: 50,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Alumnos",
                keyColumn: "NumeroControl",
                keyValue: 1,
                columns: new[] { "TokensTotales", "TokensUsados" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Alumnos",
                keyColumn: "NumeroControl",
                keyValue: 2,
                columns: new[] { "TokensTotales", "TokensUsados" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Alumnos",
                keyColumn: "NumeroControl",
                keyValue: 3,
                columns: new[] { "TokensTotales", "TokensUsados" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Alumnos",
                keyColumn: "NumeroControl",
                keyValue: 20211848,
                columns: new[] { "TokensTotales", "TokensUsados" },
                values: new object[] { 0, 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TokensTotales",
                schema: "dbo",
                table: "Alumnos");

            migrationBuilder.DropColumn(
                name: "TokensUsados",
                schema: "dbo",
                table: "Alumnos");
        }
    }
}
