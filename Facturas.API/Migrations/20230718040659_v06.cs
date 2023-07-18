using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Facturas.API.Migrations
{
    /// <inheritdoc />
    public partial class v06 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FactDetalleFacturaFacturacion");

            migrationBuilder.DropTable(
                name: "FactFacturaCabeceraFacturacion");

            migrationBuilder.DropTable(
                name: "FactTipoPagoFacturacion");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "FactDetalleFacturaFacturacion",
                columns: table => new
                {
                    FactDetalleFacturaIdDetalleFactura = table.Column<int>(type: "INTEGER", nullable: false),
                    FacturacionIdFactura = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactDetalleFacturaFacturacion", x => new { x.FactDetalleFacturaIdDetalleFactura, x.FacturacionIdFactura });
                    table.ForeignKey(
                        name: "FK_FactDetalleFacturaFacturacion_FactDetalleFactura_FactDetalleFacturaIdDetalleFactura",
                        column: x => x.FactDetalleFacturaIdDetalleFactura,
                        principalTable: "FactDetalleFactura",
                        principalColumn: "IdDetalleFactura",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FactDetalleFacturaFacturacion_Facturacion_FacturacionIdFactura",
                        column: x => x.FacturacionIdFactura,
                        principalTable: "Facturacion",
                        principalColumn: "IdFactura",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_FactDetalleFacturaFacturacion_FacturacionIdFactura",
                table: "FactDetalleFacturaFacturacion",
                column: "FacturacionIdFactura");

            migrationBuilder.CreateIndex(
                name: "IX_FactFacturaCabeceraFacturacion_FacturacionIdFactura",
                table: "FactFacturaCabeceraFacturacion",
                column: "FacturacionIdFactura");

            migrationBuilder.CreateIndex(
                name: "IX_FactTipoPagoFacturacion_TipoPagoIdTipoPago",
                table: "FactTipoPagoFacturacion",
                column: "TipoPagoIdTipoPago");
        }
    }
}
