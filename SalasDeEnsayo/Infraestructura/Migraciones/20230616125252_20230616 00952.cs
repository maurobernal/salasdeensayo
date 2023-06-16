using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalasDeEnsayo.Infraestructura.Migraciones
{
    /// <inheritdoc />
    public partial class _2023061600952 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "reservaid",
                table: "saladeensayo",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "reservaid",
                table: "saladeensayo");
        }
    }
}
