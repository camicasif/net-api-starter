using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnet_api_template.Migrations
{
    /// <inheritdoc />
    public partial class CambiarSueldoADatoEntero : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Sueldo",
                table: "Empleados",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Sueldo",
                table: "Empleados",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
