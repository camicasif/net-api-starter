using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnet_api_template.Migrations
{
    /// <inheritdoc />
    public partial class AddAuditableFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Empleados",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Empleados",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Empleados",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Empleados",
                type: "datetime(6)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Empleados");
        }
    }
}
