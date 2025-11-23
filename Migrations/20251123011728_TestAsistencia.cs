using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibroDigital.Migrations
{
    /// <inheritdoc />
    public partial class TestAsistencia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asistencia_Cursos_CursoId",
                table: "Asistencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Asistencia_Estudiantes_EstudianteId",
                table: "Asistencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Asistencia_Eventos_EventoId",
                table: "Asistencia");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Asistencia",
                table: "Asistencia");

            migrationBuilder.RenameTable(
                name: "Asistencia",
                newName: "Asistencias");

            migrationBuilder.RenameIndex(
                name: "IX_Asistencia_EventoId",
                table: "Asistencias",
                newName: "IX_Asistencias_EventoId");

            migrationBuilder.RenameIndex(
                name: "IX_Asistencia_EstudianteId",
                table: "Asistencias",
                newName: "IX_Asistencias_EstudianteId");

            migrationBuilder.RenameIndex(
                name: "IX_Asistencia_CursoId",
                table: "Asistencias",
                newName: "IX_Asistencias_CursoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Asistencias",
                table: "Asistencias",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Asistencias_Cursos_CursoId",
                table: "Asistencias",
                column: "CursoId",
                principalTable: "Cursos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Asistencias_Estudiantes_EstudianteId",
                table: "Asistencias",
                column: "EstudianteId",
                principalTable: "Estudiantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Asistencias_Eventos_EventoId",
                table: "Asistencias",
                column: "EventoId",
                principalTable: "Eventos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asistencias_Cursos_CursoId",
                table: "Asistencias");

            migrationBuilder.DropForeignKey(
                name: "FK_Asistencias_Estudiantes_EstudianteId",
                table: "Asistencias");

            migrationBuilder.DropForeignKey(
                name: "FK_Asistencias_Eventos_EventoId",
                table: "Asistencias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Asistencias",
                table: "Asistencias");

            migrationBuilder.RenameTable(
                name: "Asistencias",
                newName: "Asistencia");

            migrationBuilder.RenameIndex(
                name: "IX_Asistencias_EventoId",
                table: "Asistencia",
                newName: "IX_Asistencia_EventoId");

            migrationBuilder.RenameIndex(
                name: "IX_Asistencias_EstudianteId",
                table: "Asistencia",
                newName: "IX_Asistencia_EstudianteId");

            migrationBuilder.RenameIndex(
                name: "IX_Asistencias_CursoId",
                table: "Asistencia",
                newName: "IX_Asistencia_CursoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Asistencia",
                table: "Asistencia",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Asistencia_Cursos_CursoId",
                table: "Asistencia",
                column: "CursoId",
                principalTable: "Cursos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Asistencia_Estudiantes_EstudianteId",
                table: "Asistencia",
                column: "EstudianteId",
                principalTable: "Estudiantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Asistencia_Eventos_EventoId",
                table: "Asistencia",
                column: "EventoId",
                principalTable: "Eventos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
