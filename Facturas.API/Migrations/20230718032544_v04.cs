using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Facturas.API.Migrations
{
    /// <inheritdoc />
    public partial class v04 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                table: "FactDetalleFactura",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FactFacturaCabeceraFacturacion",
                columns: table => new
                {
                    FactFacturaCabeceraIdFacturaCabecera = table.Column<int>(type: "INTEGER", nullable: false),
                    FacturacionIdFactura = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactFacturaCabeceraFacturacion", x => new { x.FactFacturaCabeceraIdFacturaCabecera, x.FacturacionIdFactura });
                    table.ForeignKey(
                        name: "FK_FactFacturaCabeceraFacturacion_FactFacturaCabecera_FactFacturaCabeceraIdFacturaCabecera",
                        column: x => x.FactFacturaCabeceraIdFacturaCabecera,
                        principalTable: "FactFacturaCabecera",
                        principalColumn: "IdFacturaCabecera",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FactFacturaCabeceraFacturacion_Facturacion_FacturacionIdFactura",
                        column: x => x.FacturacionIdFactura,
                        principalTable: "Facturacion",
                        principalColumn: "IdFactura",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FactTipoPagoFacturacion",
                columns: table => new
                {
                    FacturacionIdFactura = table.Column<int>(type: "INTEGER", nullable: false),
                    TipoPagoIdTipoPago = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactTipoPagoFacturacion", x => new { x.FacturacionIdFactura, x.TipoPagoIdTipoPago });
                    table.ForeignKey(
                        name: "FK_FactTipoPagoFacturacion_FactTipoPago_TipoPagoIdTipoPago",
                        column: x => x.TipoPagoIdTipoPago,
                        principalTable: "FactTipoPago",
                        principalColumn: "IdTipoPago",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FactTipoPagoFacturacion_Facturacion_FacturacionIdFactura",
                        column: x => x.FacturacionIdFactura,
                        principalTable: "Facturacion",
                        principalColumn: "IdFactura",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FactDetalleFactura_FacturacionIdFactura",
                table: "FactDetalleFactura",
                column: "FacturacionIdFactura");

            migrationBuilder.CreateIndex(
                name: "IX_FactFacturaCabeceraFacturacion_FacturacionIdFactura",
                table: "FactFacturaCabeceraFacturacion",
                column: "FacturacionIdFactura");

            migrationBuilder.CreateIndex(
                name: "IX_FactTipoPagoFacturacion_TipoPagoIdTipoPago",
                table: "FactTipoPagoFacturacion",
                column: "TipoPagoIdTipoPago");

            migrationBuilder.AddForeignKey(
                name: "FK_FactDetalleFactura_Facturacion_FacturacionIdFactura",
                table: "FactDetalleFactura",
                column: "FacturacionIdFactura",
                principalTable: "Facturacion",
                principalColumn: "IdFactura");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FactDetalleFactura_Facturacion_FacturacionIdFactura",
                table: "FactDetalleFactura");

            migrationBuilder.DropTable(
                name: "FactFacturaCabeceraFacturacion");

            migrationBuilder.DropTable(
                name: "FactTipoPagoFacturacion");

            migrationBuilder.DropIndex(
                name: "IX_FactDetalleFactura_FacturacionIdFactura",
                table: "FactDetalleFactura");

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
    }
}
