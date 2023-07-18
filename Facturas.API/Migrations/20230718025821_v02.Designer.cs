﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Facturas.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230718025821_v02")]
    partial class v02
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.9");

            modelBuilder.Entity("ProyectoFacturacion.FactCliente", b =>
                {
                    b.Property<string>("Identificacion")
                        .HasColumnType("TEXT");

                    b.Property<string>("CorreoElectronico")
                        .HasColumnType("TEXT");

                    b.Property<string>("Direccion")
                        .HasColumnType("TEXT");

                    b.Property<bool?>("Estado")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("FechaNacimiento")
                        .HasColumnType("TEXT");

                    b.Property<int?>("IdTipo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefono")
                        .HasColumnType("TEXT");

                    b.Property<int?>("TipoPagoIdTipoPago")
                        .HasColumnType("INTEGER");

                    b.HasKey("Identificacion");

                    b.HasIndex("TipoPagoIdTipoPago");

                    b.ToTable("FactCliente");
                });

            modelBuilder.Entity("ProyectoFacturacion.FactDetalleFactura", b =>
                {
                    b.Property<int>("IdDetalleFactura")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Cantidad")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("FacturaCabeceraIdFacturaCabecera")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("IdFacturaCabecera")
                        .HasColumnType("INTEGER");

                    b.Property<string>("IdProducto")
                        .HasColumnType("TEXT");

                    b.Property<string>("NombreProducto")
                        .HasColumnType("TEXT");

                    b.Property<double?>("Subtotal")
                        .HasColumnType("REAL");

                    b.HasKey("IdDetalleFactura");

                    b.HasIndex("FacturaCabeceraIdFacturaCabecera");

                    b.ToTable("FactDetalleFactura");
                });

            modelBuilder.Entity("ProyectoFacturacion.FactFacturaCabecera", b =>
                {
                    b.Property<int>("IdFacturaCabecera")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClienteIdentificacion")
                        .HasColumnType("TEXT");

                    b.Property<bool?>("Estado")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("FechaFactura")
                        .HasColumnType("TEXT");

                    b.Property<int?>("IdTipo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("IdentificacionCliente")
                        .HasColumnType("TEXT");

                    b.Property<double?>("Iva")
                        .HasColumnType("REAL");

                    b.Property<string>("NumeroFactura")
                        .HasColumnType("TEXT");

                    b.Property<double?>("Subtotal")
                        .HasColumnType("REAL");

                    b.Property<int?>("TipoPagoIdTipoPago")
                        .HasColumnType("INTEGER");

                    b.Property<double?>("Total")
                        .HasColumnType("REAL");

                    b.HasKey("IdFacturaCabecera");

                    b.HasIndex("ClienteIdentificacion");

                    b.HasIndex("TipoPagoIdTipoPago");

                    b.ToTable("FactFacturaCabecera");
                });

            modelBuilder.Entity("ProyectoFacturacion.FactTipoPago", b =>
                {
                    b.Property<int>("IdTipoPago")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Tipo")
                        .HasColumnType("TEXT");

                    b.HasKey("IdTipoPago");

                    b.ToTable("FactTipoPago");
                });

            modelBuilder.Entity("ProyectoFacturacion.Facturacion", b =>
                {
                    b.Property<int>("IdFactura")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("FactDetalleFacturaIdDetalleFactura")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("FactFacturaCabeceraIdFacturaCabecera")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TipoPagoIdTipoPago")
                        .HasColumnType("INTEGER");

                    b.HasKey("IdFactura");

                    b.HasIndex("FactDetalleFacturaIdDetalleFactura");

                    b.HasIndex("FactFacturaCabeceraIdFacturaCabecera");

                    b.HasIndex("TipoPagoIdTipoPago");

                    b.ToTable("Facturacion");
                });

            modelBuilder.Entity("ProyectoFacturacion.FactCliente", b =>
                {
                    b.HasOne("ProyectoFacturacion.FactTipoPago", "TipoPago")
                        .WithMany("Clientes")
                        .HasForeignKey("TipoPagoIdTipoPago");

                    b.Navigation("TipoPago");
                });

            modelBuilder.Entity("ProyectoFacturacion.FactDetalleFactura", b =>
                {
                    b.HasOne("ProyectoFacturacion.FactFacturaCabecera", "FacturaCabecera")
                        .WithMany("DetallesFactura")
                        .HasForeignKey("FacturaCabeceraIdFacturaCabecera");

                    b.Navigation("FacturaCabecera");
                });

            modelBuilder.Entity("ProyectoFacturacion.FactFacturaCabecera", b =>
                {
                    b.HasOne("ProyectoFacturacion.FactCliente", "Cliente")
                        .WithMany("FacturaCabeceras")
                        .HasForeignKey("ClienteIdentificacion");

                    b.HasOne("ProyectoFacturacion.FactTipoPago", "TipoPago")
                        .WithMany("FacturaCabeceras")
                        .HasForeignKey("TipoPagoIdTipoPago");

                    b.Navigation("Cliente");

                    b.Navigation("TipoPago");
                });

            modelBuilder.Entity("ProyectoFacturacion.Facturacion", b =>
                {
                    b.HasOne("ProyectoFacturacion.FactDetalleFactura", "FactDetalleFactura")
                        .WithMany()
                        .HasForeignKey("FactDetalleFacturaIdDetalleFactura");

                    b.HasOne("ProyectoFacturacion.FactFacturaCabecera", "FactFacturaCabecera")
                        .WithMany()
                        .HasForeignKey("FactFacturaCabeceraIdFacturaCabecera");

                    b.HasOne("ProyectoFacturacion.FactTipoPago", "TipoPago")
                        .WithMany()
                        .HasForeignKey("TipoPagoIdTipoPago");

                    b.Navigation("FactDetalleFactura");

                    b.Navigation("FactFacturaCabecera");

                    b.Navigation("TipoPago");
                });

            modelBuilder.Entity("ProyectoFacturacion.FactCliente", b =>
                {
                    b.Navigation("FacturaCabeceras");
                });

            modelBuilder.Entity("ProyectoFacturacion.FactFacturaCabecera", b =>
                {
                    b.Navigation("DetallesFactura");
                });

            modelBuilder.Entity("ProyectoFacturacion.FactTipoPago", b =>
                {
                    b.Navigation("Clientes");

                    b.Navigation("FacturaCabeceras");
                });
#pragma warning restore 612, 618
        }
    }
}
