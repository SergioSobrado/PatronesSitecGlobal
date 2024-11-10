using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SITEC.GLOBAL.Migrations
{
    /// <inheritdoc />
    public partial class changebooltoState : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Cursada",
                schema: "dbo",
                table: "MateriasAlumnos",
                type: "int",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldMaxLength: 50);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Cursada",
                schema: "dbo",
                table: "MateriasAlumnos",
                type: "bit",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 50);
        }
    }
}
