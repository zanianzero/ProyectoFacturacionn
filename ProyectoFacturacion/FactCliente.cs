using System.ComponentModel.DataAnnotations;

namespace ProyectoFacturacion
{
    public class FactCliente
    {
        [Key]
        public string Identificacion { get; set; } = null!;

        public string? Nombre { get; set; }

        public DateTime? FechaNacimiento { get; set; }

        public string? Direccion { get; set; }

        public string? Telefono { get; set; }

        public string? CorreoElectronico { get; set; }

        public bool? Estado { get; set; }

        public int? IdTipo { get; set; }

        public virtual ICollection<FactFacturaCabecera> FacturaCabeceras { get; } = new List<FactFacturaCabecera>();

        public virtual FactTipoPago? TipoPago { get; set; }
    }
}
