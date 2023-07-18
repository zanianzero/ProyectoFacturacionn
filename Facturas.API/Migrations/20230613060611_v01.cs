using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Facturas.API.Migrations
{
    /// <inheritdoc />
    public partial class v01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FactTipoPago",
                columns: table => new
                {
                    IdTipoPago = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Tipo = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactTipoPago", x => x.IdTipoPago);
                });

            migrationBuilder.CreateTable(
                name: "FactCliente",
                columns: table => new
                {
                    Identificacion = table.Column<string>(type: "TEXT", nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Direccion = table.Column<string>(type: "TEXT", nullable: true),
                    Telefono = table.Column<string>(type: "TEXT", nullable: true),
                    CorreoElectronico = table.Column<string>(type: "TEXT", nullable: true),
                    Estado = table.Column<bool>(type: "INTEGER", nullable: true),
                    IdTipo = table.Column<int>(type: "INTEGER", nullable: true),
                    TipoPagoIdTipoPago = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactCliente", x => x.Identificacion);
                    table.ForeignKey(
                        name: "FK_FactCliente_FactTipoPago_TipoPagoIdTipoPago",
                        column: x => x.TipoPagoIdTipoPago,
                        principalTable: "FactTipoPago",
                        principalColumn: "IdTipoPago");
                });

            migrationBuilder.CreateTable(
                name: "FactFacturaCabecera",
                columns: table => new
                {
                    IdFacturaCabecera = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FechaFactura = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Subtotal = table.Column<double>(type: "REAL", nullable: true),
                    Iva = table.Column<double>(type: "REAL", nullable: true),
                    Total = table.Column<double>(type: "REAL", nullable: true),
                    Estado = table.Column<bool>(type: "INTEGER", nullable: true),
                    NumeroFactura = table.Column<string>(type: "TEXT", nullable: true),
                    IdentificacionCliente = table.Column<string>(type: "TEXT", nullable: true),
                    IdTipo = table.Column<int>(type: "INTEGER", nullable: true),
                    ClienteIdentificacion = table.Column<string>(type: "TEXT", nullable: true),
                    TipoPagoIdTipoPago = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactFacturaCabecera", x => x.IdFacturaCabecera);
                    table.ForeignKey(
                        name: "FK_FactFacturaCabecera_FactCliente_ClienteIdentificacion",
                        column: x => x.ClienteIdentificacion,
                        principalTable: "FactCliente",
                        principalColumn: "Identificacion");
                    table.ForeignKey(
                        name: "FK_FactFacturaCabecera_FactTipoPago_TipoPagoIdTipoPago",
                        column: x => x.TipoPagoIdTipoPago,
                        principalTable: "FactTipoPago",
                        principalColumn: "IdTipoPago");
                });

            migrationBuilder.CreateTable(
                name: "FactDetalleFactura",
                columns: table => new
                {
                    IdDetalleFactura = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: true),
                    Subtotal = table.Column<double>(type: "REAL", nullable: true),
                    IdProducto = table.Column<string>(type: "TEXT", nullable: true),
                    NombreProducto = table.Column<string>(type: "TEXT", nullable: true),
                    IdFacturaCabecera = table.Column<int>(type: "INTEGER", nullable: true),
                    FacturaCabeceraIdFacturaCabecera = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactDetalleFactura", x => x.IdDetalleFactura);
                    table.ForeignKey(
                        name: "FK_FactDetalleFactura_FactFacturaCabecera_FacturaCabeceraIdFacturaCabecera",
                        column: x => x.FacturaCabeceraIdFacturaCabecera,
                        principalTable: "FactFacturaCabecera",
                        principalColumn: "IdFacturaCabecera");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FactCliente_TipoPagoIdTipoPago",
                table: "FactCliente",
                column: "TipoPagoIdTipoPago");

            migrationBuilder.CreateIndex(
                name: "IX_FactDetalleFactura_FacturaCabeceraIdFacturaCabecera",
                table: "FactDetalleFactura",
                column: "FacturaCabeceraIdFacturaCabecera");

            migrationBuilder.CreateIndex(
                name: "IX_FactFacturaCabecera_ClienteIdentificacion",
                table: "FactFacturaCabecera",
                column: "ClienteIdentificacion");

            migrationBuilder.CreateIndex(
                name: "IX_FactFacturaCabecera_TipoPagoIdTipoPago",
                table: "FactFacturaCabecera",
                column: "TipoPagoIdTipoPago");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FactDetalleFactura");

            migrationBuilder.DropTable(
                name: "FactFacturaCabecera");

            migrationBuilder.DropTable(
                name: "FactCliente");

            migrationBuilder.DropTable(
                name: "FactTipoPago");
        }
    }
}
