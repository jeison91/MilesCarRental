using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MilesCarRental.Infrastructure.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Documento = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Localidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehiculos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Placa = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Modelo = table.Column<int>(type: "int", nullable: false),
                    IdMarca = table.Column<int>(type: "int", maxLength: 13, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehiculos_Marcas_IdMarca",
                        column: x => x.IdMarca,
                        principalTable: "Marcas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Alquileres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    IdVehiculo = table.Column<int>(type: "int", nullable: false),
                    IdlocalidadRecoge = table.Column<int>(type: "int", nullable: false),
                    IdLocalidadEntrega = table.Column<int>(type: "int", nullable: false),
                    FechaRecoge = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraRecoge = table.Column<int>(type: "int", nullable: false),
                    FechaEntrega = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraEntrega = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alquileres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alquileres_Clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alquileres_Localidades_IdLocalidadEntrega",
                        column: x => x.IdLocalidadEntrega,
                        principalTable: "Localidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Alquileres_Localidades_IdlocalidadRecoge",
                        column: x => x.IdlocalidadRecoge,
                        principalTable: "Localidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Alquileres_Vehiculos_IdVehiculo",
                        column: x => x.IdVehiculo,
                        principalTable: "Vehiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "Direccion", "Documento", "Email", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 1, "Carrera 42A", "1128436325", "jeison9101@gmail.com", "Jeison Cañas", "3137653881" },
                    { 2, "Calle 81", "1023468549", "carlos@example.com", "Carlos Perez", "3012568423" },
                    { 3, "Av 34 sur", "1165794321", "cata21@example.com", "Catalina Cifuentes", "3104526981" }
                });

            migrationBuilder.InsertData(
                table: "Localidades",
                columns: new[] { "Id", "Direccion", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 1, "Carrera 21", "Sede Principal", "3012584679" },
                    { 2, "Carrera 200", "Sede Bogota", "3012584613" },
                    { 3, " Carrera 80", "Sede Medellin Belen", "3005681285" },
                    { 4, "Calle 93", "Sede Bogota la 93", "3128964352" }
                });

            migrationBuilder.InsertData(
                table: "Marcas",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Renault" },
                    { 2, "Chevrolet" },
                    { 3, "Mazda" },
                    { 4, "Kia" }
                });

            migrationBuilder.InsertData(
                table: "Vehiculos",
                columns: new[] { "Id", "IdMarca", "Modelo", "Placa" },
                values: new object[,]
                {
                    { 1, 1, 2016, "AAQ 365" },
                    { 2, 1, 2021, "TIP 452" },
                    { 3, 2, 2022, "UTG 123" },
                    { 4, 3, 2015, "PRR 759" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alquileres_IdCliente",
                table: "Alquileres",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Alquileres_IdLocalidadEntrega",
                table: "Alquileres",
                column: "IdLocalidadEntrega");

            migrationBuilder.CreateIndex(
                name: "IX_Alquileres_IdlocalidadRecoge",
                table: "Alquileres",
                column: "IdlocalidadRecoge");

            migrationBuilder.CreateIndex(
                name: "IX_Alquileres_IdVehiculo",
                table: "Alquileres",
                column: "IdVehiculo");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_IdMarca",
                table: "Vehiculos",
                column: "IdMarca");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alquileres");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Localidades");

            migrationBuilder.DropTable(
                name: "Vehiculos");

            migrationBuilder.DropTable(
                name: "Marcas");
        }
    }
}
