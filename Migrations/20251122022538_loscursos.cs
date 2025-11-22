using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibroDigital.Migrations
{
    /// <inheritdoc />
    public partial class loscursos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Cursos_ProfesorId",
                table: "Cursos",
                column: "ProfesorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cursos_Profesores_ProfesorId",
                table: "Cursos",
                column: "ProfesorId",
                principalTable: "Profesores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cursos_Profesores_ProfesorId",
                table: "Cursos");

            migrationBuilder.DropIndex(
                name: "IX_Cursos_ProfesorId",
                table: "Cursos");
        }
    }
}
