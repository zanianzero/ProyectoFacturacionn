using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFacturacion
{
    public class productos
    {
        [Key]
         public int pro_id { get; set; }
        public string pro_nombre { get; set; }
        public string pro_descripcion { get; set; }
        public double pro_valor_iva { get; set; }
        public double pro_costo { get; set; }
        public double pro_pvp { get; set; }
        public string pro_imagen { get; set; }
        public int cat_id { get; set; }
        public string cat_nombre { get; set; }
        public int pro_stock { get; set; }
    }
}
