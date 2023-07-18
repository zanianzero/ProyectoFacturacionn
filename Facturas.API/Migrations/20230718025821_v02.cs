using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Facturas.API.Migrations
{
    /// <inheritdoc />
    public partial class v02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Facturacion",
                columns: table => new
                {
                    IdFactura = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FactFacturaCabeceraIdFacturaCabecera = table.Column<int>(type: "INTEGER", nullable: true),
                    FactDetalleFacturaIdDetalleFactura = table.Column<int>(type: "INTEGER", nullable: true),
                    TipoPagoIdTipoPago = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturacion", x => x.IdFactura);
                    table.ForeignKey(
                        name: "FK_Facturacion_FactDetalleFactura_FactDetalleFacturaIdDetalleFactura",
                        column: x => x.FactDetalleFacturaIdDetalleFactura,
                        principalTable: "FactDetalleFactura",
                        principalColumn: "IdDetalleFactura");
                    table.ForeignKey(
                        name: "FK_Facturacion_FactFacturaCabecera_FactFacturaCabeceraIdFacturaCabecera",
                        column: x => x.FactFacturaCabeceraIdFacturaCabecera,
                        principalTable: "FactFacturaCabecera",
                        principalColumn: "IdFacturaCabecera");
                    table.ForeignKey(
                        name: "FK_Facturacion_FactTipoPago_TipoPagoIdTipoPago",
                        column: x => x.TipoPagoIdTipoPago,
                        principalTable: "FactTipoPago",
                        principalColumn: "IdTipoPago");
                });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Facturacion");
        }
    }
}
