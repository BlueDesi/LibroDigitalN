using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibroDigital.Migrations
{
    /// <inheritdoc />
    public partial class nuevocampo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DiaClase",
                table: "Cursos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiaClase",
                table: "Cursos");
        }
    }
}
