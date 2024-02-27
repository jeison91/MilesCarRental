using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MilesCarRental.Infrastructure.Migrations
{
    public partial class LocalidadVehiculoDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdLocalidadActual",
                table: "Vehiculos",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("Relational:ColumnOrder", 5);

            migrationBuilder.UpdateData(
                table: "Vehiculos",
                keyColumn: "Id",
                keyValue: 1,
                column: "IdLocalidadActual",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Vehiculos",
                keyColumn: "Id",
                keyValue: 2,
                column: "IdLocalidadActual",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Vehiculos",
                keyColumn: "Id",
                keyValue: 3,
                column: "IdLocalidadActual",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Vehiculos",
                keyColumn: "Id",
                keyValue: 4,
                column: "IdLocalidadActual",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_IdLocalidadActual",
                table: "Vehiculos",
                column: "IdLocalidadActual");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehiculos_Localidades_IdLocalidadActual",
                table: "Vehiculos",
                column: "IdLocalidadActual",
                principalTable: "Localidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehiculos_Localidades_IdLocalidadActual",
                table: "Vehiculos");

            migrationBuilder.DropIndex(
                name: "IX_Vehiculos_IdLocalidadActual",
                table: "Vehiculos");

            migrationBuilder.DropColumn(
                name: "IdLocalidadActual",
                table: "Vehiculos");
        }
    }
}
