using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Facturas.API.Migrations
{
    /// <inheritdoc />
    public partial class v05 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FactDetalleFactura_Facturacion_FacturacionIdFactura",
                table: "FactDetalleFactura");

            migrationBuilder.DropIndex(
                name: "IX_FactDetalleFactura_FacturacionIdFactura",
                table: "FactDetalleFactura");

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

            migrationBuilder.CreateIndex(
                name: "IX_FactDetalleFacturaFacturacion_FacturacionIdFactura",
                table: "FactDetalleFacturaFacturacion",
                column: "FacturacionIdFactura");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FactDetalleFacturaFacturacion");

            migrationBuilder.AddColumn<int>(
                name: "FacturacionIdFactura",
                table: "FactDetalleFactura",
                type: "INTEGER",
                nullable: true);

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
        }
    }
}
