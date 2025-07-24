using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KioscoAPI.Migrations
{
    /// <inheritdoc />
    public partial class CambiosProductoCodigoBarraLong : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PagosFiado_Cuentas_CuentaId",
                table: "PagosFiado");

            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Cuentas_CuentaId",
                table: "Ventas");

            migrationBuilder.DropIndex(
                name: "IX_PagosFiado_CuentaId",
                table: "PagosFiado");

            migrationBuilder.DropColumn(
                name: "CuentaId",
                table: "PagosFiado");

            migrationBuilder.RenameColumn(
                name: "CuentaId",
                table: "Ventas",
                newName: "id_cuenta");

            migrationBuilder.RenameIndex(
                name: "IX_Ventas_CuentaId",
                table: "Ventas",
                newName: "IX_Ventas_id_cuenta");

            migrationBuilder.AlterColumn<long>(
                name: "codigo_barra",
                table: "Productos",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "id_cuenta",
                table: "PagosFiado",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PagosFiado_id_cuenta",
                table: "PagosFiado",
                column: "id_cuenta");

            migrationBuilder.AddForeignKey(
                name: "FK_PagosFiado_Cuentas_id_cuenta",
                table: "PagosFiado",
                column: "id_cuenta",
                principalTable: "Cuentas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Cuentas_id_cuenta",
                table: "Ventas",
                column: "id_cuenta",
                principalTable: "Cuentas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PagosFiado_Cuentas_id_cuenta",
                table: "PagosFiado");

            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Cuentas_id_cuenta",
                table: "Ventas");

            migrationBuilder.DropIndex(
                name: "IX_PagosFiado_id_cuenta",
                table: "PagosFiado");

            migrationBuilder.DropColumn(
                name: "id_cuenta",
                table: "PagosFiado");

            migrationBuilder.RenameColumn(
                name: "id_cuenta",
                table: "Ventas",
                newName: "CuentaId");

            migrationBuilder.RenameIndex(
                name: "IX_Ventas_id_cuenta",
                table: "Ventas",
                newName: "IX_Ventas_CuentaId");

            migrationBuilder.AlterColumn<int>(
                name: "codigo_barra",
                table: "Productos",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<int>(
                name: "CuentaId",
                table: "PagosFiado",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PagosFiado_CuentaId",
                table: "PagosFiado",
                column: "CuentaId");

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
    }
}
