using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibroDigital.Migrations
{
    /// <inheritdoc />
    public partial class Cuatro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "Profesores",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "Estudiantes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Activo",
                table: "Profesores");

            migrationBuilder.DropColumn(
                name: "Activo",
                table: "Estudiantes");
        }
    }
}
