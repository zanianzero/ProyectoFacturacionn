using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFacturacion
{
    public class FactDetalleFactura
    {
        [Key]
        public int IdDetalleFactura { get; set; }

        public int? Cantidad { get; set; }

        public double? Subtotal { get; set; }

        public string? IdProducto { get; set; }

        public string? NombreProducto { get; set; }

        public int? IdFacturaCabecera { get; set; }
        public virtual FactFacturaCabecera? FacturaCabecera { get; set; }

    }
}
