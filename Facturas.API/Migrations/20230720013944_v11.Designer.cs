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
    [Migration("20230720013944_v11")]
    partial class v11
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.9");

            modelBuilder.Entity("ProyectoFacturacion.FacFacturacion", b =>
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

            modelBuilder.Entity("ProyectoFacturacion.FactAuditoria", b =>
                {
                    b.Property<int>("aud_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("aud_accion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("aud_fecha")
                        .HasColumnType("TEXT");

                    b.Property<string>("aud_funcionalidad")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("aud_modulo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("aud_observacion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("aud_usuario")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("aud_id");

                    b.ToTable("FactAuditoria");
                });

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

                    b.Property<int?>("Productospro_id")
                        .HasColumnType("INTEGER");

                    b.Property<double?>("Subtotal")
                        .HasColumnType("REAL");

                    b.HasKey("IdDetalleFactura");

                    b.HasIndex("FacturaCabeceraIdFacturaCabecera");

                    b.HasIndex("Productospro_id");

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

            modelBuilder.Entity("ProyectoFacturacion.productos", b =>
                {
                    b.Property<int>("pro_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("cat_id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("cat_nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("pro_costo")
                        .HasColumnType("REAL");

                    b.Property<string>("pro_descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("pro_imagen")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("pro_nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("pro_pvp")
                        .HasColumnType("REAL");

                    b.Property<int>("pro_stock")
                        .HasColumnType("INTEGER");

                    b.Property<double>("pro_valor_iva")
                        .HasColumnType("REAL");

                    b.HasKey("pro_id");

                    b.ToTable("productos");
                });

            modelBuilder.Entity("ProyectoFacturacion.FacFacturacion", b =>
                {
                    b.HasOne("ProyectoFacturacion.FactDetalleFactura", "FactDetalleFactura")
                        .WithMany("Facturacion")
                        .HasForeignKey("FactDetalleFacturaIdDetalleFactura");

                    b.HasOne("ProyectoFacturacion.FactFacturaCabecera", "FactFacturaCabecera")
                        .WithMany("Facturacion")
                        .HasForeignKey("FactFacturaCabeceraIdFacturaCabecera");

                    b.HasOne("ProyectoFacturacion.FactTipoPago", "TipoPago")
                        .WithMany("Facturaciones")
                        .HasForeignKey("TipoPagoIdTipoPago");

                    b.Navigation("FactDetalleFactura");

                    b.Navigation("FactFacturaCabecera");

                    b.Navigation("TipoPago");
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

                    b.HasOne("ProyectoFacturacion.productos", "Productos")
                        .WithMany("DetallesFactura")
                        .HasForeignKey("Productospro_id");

                    b.Navigation("FacturaCabecera");

                    b.Navigation("Productos");
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

            modelBuilder.Entity("ProyectoFacturacion.FactCliente", b =>
                {
                    b.Navigation("FacturaCabeceras");
                });

            modelBuilder.Entity("ProyectoFacturacion.FactDetalleFactura", b =>
                {
                    b.Navigation("Facturacion");
                });

            modelBuilder.Entity("ProyectoFacturacion.FactFacturaCabecera", b =>
                {
                    b.Navigation("DetallesFactura");

                    b.Navigation("Facturacion");
                });

            modelBuilder.Entity("ProyectoFacturacion.FactTipoPago", b =>
                {
                    b.Navigation("Clientes");

                    b.Navigation("FacturaCabeceras");

                    b.Navigation("Facturaciones");
                });

            modelBuilder.Entity("ProyectoFacturacion.productos", b =>
                {
                    b.Navigation("DetallesFactura");
                });
#pragma warning restore 612, 618
        }
    }
}
