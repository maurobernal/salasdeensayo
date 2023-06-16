using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalasDeEnsayo.Infraestructura.Migraciones
{
    /// <inheritdoc />
    public partial class _202306161305 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "confirmado",
                table: "reserva",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaDeConfirmacion",
                table: "reserva",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "confirmado",
                table: "reserva");

            migrationBuilder.DropColumn(
                name: "fechaDeConfirmacion",
                table: "reserva");
        }
    }
}
