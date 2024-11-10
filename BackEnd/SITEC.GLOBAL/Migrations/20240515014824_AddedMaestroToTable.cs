using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SITEC.GLOBAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedMaestroToTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaestroId",
                schema: "dbo",
                table: "MateriasAlumnos",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_MateriasAlumnos_MaestroId",
                schema: "dbo",
                table: "MateriasAlumnos",
                column: "MaestroId");

            migrationBuilder.AddForeignKey(
                name: "FK_MateriasAlumnos_Maestro_MaestroId",
                schema: "dbo",
                table: "MateriasAlumnos",
                column: "MaestroId",
                principalSchema: "dbo",
                principalTable: "Maestro",
                principalColumn: "MaestroId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MateriasAlumnos_Maestro_MaestroId",
                schema: "dbo",
                table: "MateriasAlumnos");

            migrationBuilder.DropIndex(
                name: "IX_MateriasAlumnos_MaestroId",
                schema: "dbo",
                table: "MateriasAlumnos");

            migrationBuilder.DropColumn(
                name: "MaestroId",
                schema: "dbo",
                table: "MateriasAlumnos");
        }
    }
}
