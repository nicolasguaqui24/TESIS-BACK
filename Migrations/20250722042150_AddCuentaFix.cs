using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KioscoAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddCuentaFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CuentaId",
                table: "Ventas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CuentaId",
                table: "PagosFiado",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cuentas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaCierre = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Saldo = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    id_cliente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuentas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cuentas_Clientes_id_cliente",
                        column: x => x.id_cliente,
                        principalTable: "Clientes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_CuentaId",
                table: "Ventas",
                column: "CuentaId");

            migrationBuilder.CreateIndex(
                name: "IX_PagosFiado_CuentaId",
                table: "PagosFiado",
                column: "CuentaId");

            migrationBuilder.CreateIndex(
                name: "IX_Cuentas_id_cliente",
                table: "Cuentas",
                column: "id_cliente");

            migrationBuilder.AddForeignKey(
                name: "FK_PagosFiado_Cuentas_CuentaId",
                table: "PagosFiado",
                column: "CuentaId",
                principalTable: "Cuentas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Cuentas_CuentaId",
                table: "Ventas",
                column: "CuentaId",
                principalTable: "Cuentas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PagosFiado_Cuentas_CuentaId",
                table: "PagosFiado");

            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Cuentas_CuentaId",
                table: "Ventas");

            migrationBuilder.DropTable(
                name: "Cuentas");

            migrationBuilder.DropIndex(
                name: "IX_Ventas_CuentaId",
                table: "Ventas");

            migrationBuilder.DropIndex(
                name: "IX_PagosFiado_CuentaId",
                table: "PagosFiado");

            migrationBuilder.DropColumn(
                name: "CuentaId",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "CuentaId",
                table: "PagosFiado");
        }
    }
}
