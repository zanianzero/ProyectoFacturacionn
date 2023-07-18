using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Facturas.API.Migrations
{
    /// <inheritdoc />
    public partial class v07 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FactDetalleFactura_Facturacion_FacturacionIdFactura",
                table: "FactDetalleFactura");

            migrationBuilder.DropForeignKey(
                name: "FK_FactFacturaCabecera_Facturacion_FacturacionIdFactura",
                table: "FactFacturaCabecera");

            migrationBuilder.DropForeignKey(
                name: "FK_FactTipoPago_Facturacion_FacturacionIdFactura",
                table: "FactTipoPago");

            migrationBuilder.DropIndex(
                name: "IX_FactTipoPago_FacturacionIdFactura",
                table: "FactTipoPago");

            migrationBuilder.DropIndex(
                name: "IX_FactFacturaCabecera_FacturacionIdFactura",
                table: "FactFacturaCabecera");

            migrationBuilder.DropIndex(
                name: "IX_FactDetalleFactura_FacturacionIdFactura",
                table: "FactDetalleFactura");

            migrationBuilder.DropColumn(
                name: "FacturacionIdFactura",
                table: "FactTipoPago");

            migrationBuilder.DropColumn(
                name: "FacturacionIdFactura",
                table: "FactFacturaCabecera");

            migrationBuilder.DropColumn(
                name: "FacturacionIdFactura",
                table: "FactDetalleFactura");

            migrationBuilder.AddColumn<int>(
                name: "FactDetalleFacturaIdDetalleFactura",
                table: "Facturacion",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FactFacturaCabeceraIdFacturaCabecera",
                table: "Facturacion",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoPagoIdTipoPago",
                table: "Facturacion",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Facturacion_FactDetalleFacturaIdDetalleFactura",
                table: "Facturacion",
                column: "FactDetalleFacturaIdDetalleFactura");

            migrationBuilder.CreateIndex(
                name: "IX_Facturacion_FactFacturaCabeceraIdFacturaCabecera",
                table: "Facturacion",
                column: "FactFacturaCabeceraIdFacturaCabecera");

            migrationBuilder.CreateIndex(
                name: "IX_Facturacion_TipoPagoIdTipoPago",
                table: "Facturacion",
                column: "TipoPagoIdTipoPago");

            migrationBuilder.AddForeignKey(
                name: "FK_Facturacion_FactDetalleFactura_FactDetalleFacturaIdDetalleFactura",
                table: "Facturacion",
                column: "FactDetalleFacturaIdDetalleFactura",
                principalTable: "FactDetalleFactura",
                principalColumn: "IdDetalleFactura");

            migrationBuilder.AddForeignKey(
                name: "FK_Facturacion_FactFacturaCabecera_FactFacturaCabeceraIdFacturaCabecera",
                table: "Facturacion",
                column: "FactFacturaCabeceraIdFacturaCabecera",
                principalTable: "FactFacturaCabecera",
                principalColumn: "IdFacturaCabecera");

            migrationBuilder.AddForeignKey(
                name: "FK_Facturacion_FactTipoPago_TipoPagoIdTipoPago",
                table: "Facturacion",
                column: "TipoPagoIdTipoPago",
                principalTable: "FactTipoPago",
                principalColumn: "IdTipoPago");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facturacion_FactDetalleFactura_FactDetalleFacturaIdDetalleFactura",
                table: "Facturacion");

            migrationBuilder.DropForeignKey(
                name: "FK_Facturacion_FactFacturaCabecera_FactFacturaCabeceraIdFacturaCabecera",
                table: "Facturacion");

            migrationBuilder.DropForeignKey(
                name: "FK_Facturacion_FactTipoPago_TipoPagoIdTipoPago",
                table: "Facturacion");

            migrationBuilder.DropIndex(
                name: "IX_Facturacion_FactDetalleFacturaIdDetalleFactura",
                table: "Facturacion");

            migrationBuilder.DropIndex(
                name: "IX_Facturacion_FactFacturaCabeceraIdFacturaCabecera",
                table: "Facturacion");

            migrationBuilder.DropIndex(
                name: "IX_Facturacion_TipoPagoIdTipoPago",
                table: "Facturacion");

            migrationBuilder.DropColumn(
                name: "FactDetalleFacturaIdDetalleFactura",
                table: "Facturacion");

            migrationBuilder.DropColumn(
                name: "FactFacturaCabeceraIdFacturaCabecera",
                table: "Facturacion");

            migrationBuilder.DropColumn(
                name: "TipoPagoIdTipoPago",
                table: "Facturacion");

            migrationBuilder.AddColumn<int>(
                name: "FacturacionIdFactura",
                table: "FactTipoPago",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FacturacionIdFactura",
                table: "FactFacturaCabecera",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FacturacionIdFactura",
                table: "FactDetalleFactura",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FactTipoPago_FacturacionIdFactura",
                table: "FactTipoPago",
                column: "FacturacionIdFactura");

            migrationBuilder.CreateIndex(
                name: "IX_FactFacturaCabecera_FacturacionIdFactura",
                table: "FactFacturaCabecera",
                column: "FacturacionIdFactura");

            migrationBuilder.CreateIndex(
                name: "IX_FactDetalleFactura_FacturacionIdFactura",
                table: "FactDetalleFactura",
                column: "FacturacionIdFactura");

            migrationBuilder.AddForeignKey(
                name: "FK_FactDetalleFactura_Facturacion_FacturacionIdFactura",
                table: "FactDetalleFactura",
                column: "FacturacionIdFactura",
                principalTable: "Facturacion",
                principalColumn: "IdFactura");

            migrationBuilder.AddForeignKey(
                name: "FK_FactFacturaCabecera_Facturacion_FacturacionIdFactura",
                table: "FactFacturaCabecera",
                column: "FacturacionIdFactura",
                principalTable: "Facturacion",
                principalColumn: "IdFactura");

            migrationBuilder.AddForeignKey(
                name: "FK_FactTipoPago_Facturacion_FacturacionIdFactura",
                table: "FactTipoPago",
                column: "FacturacionIdFactura",
                principalTable: "Facturacion",
                principalColumn: "IdFactura");
        }
    }
}
