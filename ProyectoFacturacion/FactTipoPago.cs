using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFacturacion
{
    public class FactTipoPago
    {
        [Key]
        public int IdTipoPago { get; set; }
        public string? Tipo { get; set; }

        public virtual ICollection<FactCliente> Clientes { get; } = new List<FactCliente>();

        public virtual ICollection<FactFacturaCabecera> FacturaCabeceras { get; } = new List<FactFacturaCabecera>();
    }
}
