using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnet_api_template.Migrations
{
    /// <inheritdoc />
    public partial class QuitarRestriccionUnicaDni : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Eliminar índice único anterior (si existía)
            migrationBuilder.DropIndex(
                name: "IX_Empleados_Dni",
                table: "Empleados");

            // Crear índice normal (permite duplicados)
            migrationBuilder.CreateIndex(
                name: "IX_Empleados_Dni",
                table: "Empleados",
                column: "Dni");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Eliminar índice normal
            migrationBuilder.DropIndex(
                name: "IX_Empleados_Dni",
                table: "Empleados");

            // Volver a crear índice único
            migrationBuilder.CreateIndex(
                name: "IX_Empleados_Dni",
                table: "Empleados",
                column: "Dni",
                unique: true);
        }
    }
}
