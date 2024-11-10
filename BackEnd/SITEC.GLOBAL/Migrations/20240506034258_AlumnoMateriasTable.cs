using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SITEC.GLOBAL.Migrations
{
    /// <inheritdoc />
    public partial class AlumnoMateriasTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MateriasAlumnos",
                schema: "dbo",
                columns: table => new
                {
                    MateriaAlumnoId = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroControl = table.Column<int>(type: "int", nullable: false),
                    MateriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MateriasAlumnos", x => x.MateriaAlumnoId);
                    table.ForeignKey(
                        name: "FK_MateriasAlumnos_Alumnos_NumeroControl",
                        column: x => x.NumeroControl,
                        principalSchema: "dbo",
                        principalTable: "Alumnos",
                        principalColumn: "NumeroControl",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MateriasAlumnos_Materia_MateriaId",
                        column: x => x.MateriaId,
                        principalSchema: "dbo",
                        principalTable: "Materia",
                        principalColumn: "MateriaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MateriasAlumnos_MateriaId",
                schema: "dbo",
                table: "MateriasAlumnos",
                column: "MateriaId");

            migrationBuilder.CreateIndex(
                name: "IX_MateriasAlumnos_NumeroControl",
                schema: "dbo",
                table: "MateriasAlumnos",
                column: "NumeroControl");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MateriasAlumnos",
                schema: "dbo");
        }
    }
}
