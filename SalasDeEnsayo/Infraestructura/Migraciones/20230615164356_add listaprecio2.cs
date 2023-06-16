using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalasDeEnsayo.Infraestructura.Migraciones
{
    /// <inheritdoc />
    public partial class addlistaprecio2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tipodesala",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(type: "Varchar(100)", maxLength: 100, nullable: false),
                    habilitado = table.Column<bool>(type: "bit", nullable: false),
                    creado = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipodesala", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "listadeprecio",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tiposalaid = table.Column<int>(type: "int", nullable: false),
                    dia = table.Column<string>(type: "Varchar(100)", maxLength: 100, nullable: false),
                    precioxhora = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_listadeprecio", x => x.id);
                    table.ForeignKey(
                        name: "FK_listadeprecio_tipodesala_tiposalaid",
                        column: x => x.tiposalaid,
                        principalTable: "tipodesala",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "saladeensayo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipodesalaid = table.Column<int>(type: "int", nullable: false),
                    capacidad = table.Column<int>(type: "int", nullable: false),
                    descripcion_sala = table.Column<string>(type: "Varchar(50)", maxLength: 50, nullable: false),
                    habilitado = table.Column<bool>(type: "bit", nullable: false),
                    creado = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_saladeensayo", x => x.id);
                    table.ForeignKey(
                        name: "FK_saladeensayo_tipodesala_tipodesalaid",
                        column: x => x.tipodesalaid,
                        principalTable: "tipodesala",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_listadeprecio_tiposalaid",
                table: "listadeprecio",
                column: "tiposalaid");

            migrationBuilder.CreateIndex(
                name: "IX_saladeensayo_tipodesalaid",
                table: "saladeensayo",
                column: "tipodesalaid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "listadeprecio");

            migrationBuilder.DropTable(
                name: "saladeensayo");

            migrationBuilder.DropTable(
                name: "tipodesala");
        }
    }
}
