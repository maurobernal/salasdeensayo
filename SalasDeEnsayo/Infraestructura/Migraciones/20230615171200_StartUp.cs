using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalasDeEnsayo.Infraestructura.Migraciones
{
    /// <inheritdoc />
<<<<<<< HEAD:SalasDeEnsayo/Infraestructura/Migraciones/20230615164356_add listaprecio2.cs
    public partial class addlistaprecio2 : Migration
=======
    public partial class StartUp : Migration
>>>>>>> 0425b26e3dbd324ba73832f131ec632d3399901a:SalasDeEnsayo/Infraestructura/Migraciones/20230615171200_StartUp.cs
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
<<<<<<< HEAD:SalasDeEnsayo/Infraestructura/Migraciones/20230615164356_add listaprecio2.cs
                name: "listadeprecio",
=======
                name: "saladeensayo",
>>>>>>> 0425b26e3dbd324ba73832f131ec632d3399901a:SalasDeEnsayo/Infraestructura/Migraciones/20230615171200_StartUp.cs
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
<<<<<<< HEAD:SalasDeEnsayo/Infraestructura/Migraciones/20230615164356_add listaprecio2.cs
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
=======
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
>>>>>>> 0425b26e3dbd324ba73832f131ec632d3399901a:SalasDeEnsayo/Infraestructura/Migraciones/20230615171200_StartUp.cs
                        principalTable: "tipodesala",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
<<<<<<< HEAD:SalasDeEnsayo/Infraestructura/Migraciones/20230615164356_add listaprecio2.cs
                name: "saladeensayo",
=======
                name: "reserva",
>>>>>>> 0425b26e3dbd324ba73832f131ec632d3399901a:SalasDeEnsayo/Infraestructura/Migraciones/20230615171200_StartUp.cs
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
<<<<<<< HEAD:SalasDeEnsayo/Infraestructura/Migraciones/20230615164356_add listaprecio2.cs
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
=======
                    salaDeEnsayoId = table.Column<int>(type: "int", nullable: false),
                    fechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    precioPorHora = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reserva", x => x.id);
                    table.ForeignKey(
                        name: "FK_reserva_saladeensayo_salaDeEnsayoId",
                        column: x => x.salaDeEnsayoId,
                        principalTable: "saladeensayo",
>>>>>>> 0425b26e3dbd324ba73832f131ec632d3399901a:SalasDeEnsayo/Infraestructura/Migraciones/20230615171200_StartUp.cs
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
<<<<<<< HEAD:SalasDeEnsayo/Infraestructura/Migraciones/20230615164356_add listaprecio2.cs
                name: "IX_listadeprecio_tiposalaid",
                table: "listadeprecio",
                column: "tiposalaid");
=======
                name: "IX_reserva_salaDeEnsayoId",
                table: "reserva",
                column: "salaDeEnsayoId");
>>>>>>> 0425b26e3dbd324ba73832f131ec632d3399901a:SalasDeEnsayo/Infraestructura/Migraciones/20230615171200_StartUp.cs

            migrationBuilder.CreateIndex(
                name: "IX_saladeensayo_tipodesalaid",
                table: "saladeensayo",
                column: "tipodesalaid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
<<<<<<< HEAD:SalasDeEnsayo/Infraestructura/Migraciones/20230615164356_add listaprecio2.cs
                name: "listadeprecio");
=======
                name: "reserva");
>>>>>>> 0425b26e3dbd324ba73832f131ec632d3399901a:SalasDeEnsayo/Infraestructura/Migraciones/20230615171200_StartUp.cs

            migrationBuilder.DropTable(
                name: "saladeensayo");

            migrationBuilder.DropTable(
                name: "tipodesala");
        }
    }
}
