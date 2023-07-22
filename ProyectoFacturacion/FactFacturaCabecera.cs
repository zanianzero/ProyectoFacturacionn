using System.ComponentModel.DataAnnotations;

namespace ProyectoFacturacion
{
    public class FactFacturaCabecera
    {
        [Key]
        public int IdFacturaCabecera { get; set; }

        public DateTime? FechaFactura { get; set; }

        public double? Subtotal { get; set; }

        public double? Iva { get; set; }

        public double? Total { get; set; }

        public bool? Estado { get; set; }

        public string? NumeroFactura { get; set; }

        public string? IdentificacionCliente { get; set; }

        public int? IdTipo { get; set; }

        public virtual FactCliente? Cliente { get; set; }

        public List<FactDetalleFactura> DetallesFactura { get; set; }
        //public virtual ICollection<FacFacturacion> Facturacion { get; } = new List<FacFacturacion>();
        public virtual FactTipoPago? TipoPago { get; set; }
    }
}
