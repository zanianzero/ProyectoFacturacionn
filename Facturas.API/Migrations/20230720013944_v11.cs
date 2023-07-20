using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Facturas.API.Migrations
{
    /// <inheritdoc />
    public partial class v11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Productospro_id",
                table: "FactDetalleFactura",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FactAuditoria",
                columns: table => new
                {
                    aud_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    aud_usuario = table.Column<string>(type: "TEXT", nullable: false),
                    aud_fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    aud_accion = table.Column<string>(type: "TEXT", nullable: false),
                    aud_modulo = table.Column<string>(type: "TEXT", nullable: false),
                    aud_funcionalidad = table.Column<string>(type: "TEXT", nullable: false),
                    aud_observacion = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactAuditoria", x => x.aud_id);
                });

            migrationBuilder.CreateTable(
                name: "productos",
                columns: table => new
                {
                    pro_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    pro_nombre = table.Column<string>(type: "TEXT", nullable: false),
                    pro_descripcion = table.Column<string>(type: "TEXT", nullable: false),
                    pro_valor_iva = table.Column<double>(type: "REAL", nullable: false),
                    pro_costo = table.Column<double>(type: "REAL", nullable: false),
                    pro_pvp = table.Column<double>(type: "REAL", nullable: false),
                    pro_imagen = table.Column<string>(type: "TEXT", nullable: false),
                    cat_id = table.Column<int>(type: "INTEGER", nullable: false),
                    cat_nombre = table.Column<string>(type: "TEXT", nullable: false),
                    pro_stock = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productos", x => x.pro_id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FactDetalleFactura_Productospro_id",
                table: "FactDetalleFactura",
                column: "Productospro_id");

            migrationBuilder.AddForeignKey(
                name: "FK_FactDetalleFactura_productos_Productospro_id",
                table: "FactDetalleFactura",
                column: "Productospro_id",
                principalTable: "productos",
                principalColumn: "pro_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FactDetalleFactura_productos_Productospro_id",
                table: "FactDetalleFactura");

            migrationBuilder.DropTable(
                name: "FactAuditoria");

            migrationBuilder.DropTable(
                name: "productos");

            migrationBuilder.DropIndex(
                name: "IX_FactDetalleFactura_Productospro_id",
                table: "FactDetalleFactura");

            migrationBuilder.DropColumn(
                name: "Productospro_id",
                table: "FactDetalleFactura");
        }
    }
}
