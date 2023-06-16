using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalasDeEnsayo.Infraestructura.Migraciones
{
    /// <inheritdoc />
    public partial class StartUp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "instrumento",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    marca = table.Column<string>(type: "Varchar(100)", maxLength: 100, nullable: false),
                    descripcion = table.Column<string>(type: "Varchar(100)", maxLength: 100, nullable: false),
                    fechacompra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    habilitado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_instrumento", x => x.id);
                });

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

            migrationBuilder.CreateTable(
                name: "saladeensayoequipamiento",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    salasdeensayoid = table.Column<int>(type: "int", nullable: false),
                    instrumentoid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_saladeensayoequipamiento", x => x.id);
                    table.ForeignKey(
                        name: "FK_saladeensayoequipamiento_instrumento_instrumentoid",
                        column: x => x.instrumentoid,
                        principalTable: "instrumento",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_saladeensayoequipamiento_saladeensayo_salasdeensayoid",
                        column: x => x.salasdeensayoid,
                        principalTable: "saladeensayo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_saladeensayo_tipodesalaid",
                table: "saladeensayo",
                column: "tipodesalaid");

            migrationBuilder.CreateIndex(
                name: "IX_saladeensayoequipamiento_instrumentoid",
                table: "saladeensayoequipamiento",
                column: "instrumentoid");

            migrationBuilder.CreateIndex(
                name: "IX_saladeensayoequipamiento_salasdeensayoid",
                table: "saladeensayoequipamiento",
                column: "salasdeensayoid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "saladeensayoequipamiento");

            migrationBuilder.DropTable(
                name: "instrumento");

            migrationBuilder.DropTable(
                name: "saladeensayo");

            migrationBuilder.DropTable(
                name: "tipodesala");
        }
    }
}
