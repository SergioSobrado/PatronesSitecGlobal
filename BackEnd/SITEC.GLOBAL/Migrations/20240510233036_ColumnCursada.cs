using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SITEC.GLOBAL.Migrations
{
    /// <inheritdoc />
    public partial class ColumnCursada : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Cursada",
                schema: "dbo",
                table: "MateriasAlumnos",
                type: "bit",
                maxLength: 50,
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cursada",
                schema: "dbo",
                table: "MateriasAlumnos");
        }
    }
}
