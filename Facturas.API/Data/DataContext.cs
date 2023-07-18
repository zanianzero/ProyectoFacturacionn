using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoFacturacion;

    public class DataContext : DbContext
    {
        public DataContext (DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<ProyectoFacturacion.FactTipoPago> FactTipoPago { get; set; } = default!;

        public DbSet<ProyectoFacturacion.FactFacturaCabecera> FactFacturaCabecera { get; set; } = default!;

        public DbSet<ProyectoFacturacion.FactDetalleFactura> FactDetalleFactura { get; set; } = default!;

        public DbSet<ProyectoFacturacion.FactCliente> FactCliente { get; set; } = default!;
    }
