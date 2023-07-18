using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoFacturacion;

namespace Facturas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BLFacturasController : ControllerBase
    {
        private readonly DataContext _context;

        public BLFacturasController(DataContext context)
        {
            _context = context;
        }

        // GET: api/DalFacturas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FactCliente>>> NumeroClientes()
        {
            if (_context.FactCliente == null)
            {
                return NotFound();
            }
         
            
            //retonar el nombre de los cluienes que tengan una factura registrada
            return await _context.FactCliente.Where(x => x.FacturaCabeceras.Count > 0).ToListAsync();


           


        }


    }

}

