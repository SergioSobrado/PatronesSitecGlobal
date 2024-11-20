using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SITEC.GLOBAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedCreditosToMaterias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    schema: "dbo",
            //    table: "Materia",
            //    keyColumn: "MateriaId",
            //    keyValue: 1);

            //migrationBuilder.DeleteData(
            //    schema: "dbo",
            //    table: "Materia",
            //    keyColumn: "MateriaId",
            //    keyValue: 2);

            //migrationBuilder.DeleteData(
            //    schema: "dbo",
            //    table: "Materia",
            //    keyColumn: "MateriaId",
            //    keyValue: 3);

            migrationBuilder.AddColumn<int>(
                name: "Creditos",
                schema: "dbo",
                table: "Materia",
                type: "int",
                maxLength: 500,
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Creditos",
                schema: "dbo",
                table: "Materia");

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
        }
    }
}
