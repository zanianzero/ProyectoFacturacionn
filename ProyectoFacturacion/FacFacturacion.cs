using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFacturacion
{
    public class FacFacturacion
    {
        [Key]
        public int IdFactura { get; set; }
        public virtual FactFacturaCabecera? FactFacturaCabecera { get; set; }
        public virtual FactDetalleFactura? FactDetalleFactura { get; set; }
        public virtual FactTipoPago? TipoPago { get; set; }

    }
}

