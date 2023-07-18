using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFacturacion
{
    public class FactAuditoria
    {
        [Key]
        public int aud_id { get; set; }
        public string aud_usuario { get; set; }
        public DateTime aud_fecha { get; set; }
        public string aud_accion { get; set; }
        public string aud_modulo { get; set; }
        public string aud_funcionalidad { get; set; }
        public string aud_observacion { get; set; }
    }
}
