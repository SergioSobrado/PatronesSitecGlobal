using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SITEC.GLOBAL.Migrations
{
    /// <inheritdoc />
    public partial class AlumnoIsAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                schema: "dbo",
                table: "Alumnos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Alumnos",
                keyColumn: "NumeroControl",
                keyValue: 1,
                column: "IsAdmin",
                value: false);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Alumnos",
                keyColumn: "NumeroControl",
                keyValue: 2,
                column: "IsAdmin",
                value: false);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Alumnos",
                keyColumn: "NumeroControl",
                keyValue: 3,
                column: "IsAdmin",
                value: false);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Alumnos",
                keyColumn: "NumeroControl",
                keyValue: 20211848,
                column: "IsAdmin",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdmin",
                schema: "dbo",
                table: "Alumnos");
        }
    }
}
