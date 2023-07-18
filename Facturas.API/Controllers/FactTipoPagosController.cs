using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoFacturacion;

namespace Facturas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("enableCors")]

    public class FactTipoPagosController : ControllerBase
    {
        private readonly DataContext _context;

        public FactTipoPagosController(DataContext context)
        {
            _context = context;
        }

        // GET: api/FactTipoPagos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FactTipoPago>>> GetFactTipoPago()
        {
          if (_context.FactTipoPago == null)
          {
              return NotFound();
          }
            // Configurar la cabecera CORS en la respuesta
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            // return await _context.FactTipoPago.ToListAsync();
            //Incluir Clientes, FacturaCabeceras, detalleFacturas
            return await _context.FactTipoPago.Include(x => x.FacturaCabeceras).Include(x => x.Clientes).ToListAsync();



        }

        // GET: api/FactTipoPagos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FactTipoPago>> GetFactTipoPago(int id)
        {
          if (_context.FactTipoPago == null)
          {
              return NotFound();
          }

            var factTipoPago = await _context.FactTipoPago.FindAsync(id);
            //Incluir Clientes, FacturaCabeceras, detalleFacturas
            var FactTipoPago = _context.FactTipoPago.
                Include(x => x.FacturaCabeceras).
                Include(x => x.Clientes).
                FirstOrDefault(x => x.IdTipoPago == id);



            if (factTipoPago == null)
            {
                return NotFound();
            }
            // Configurar la cabecera CORS en la respuesta
            Response.Headers.Add("Access-Control-Allow-Origin", "*");

            return factTipoPago;
        }

        // PUT: api/FactTipoPagos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFactTipoPago(int id, FactTipoPago factTipoPago)
        {
            if (id != factTipoPago.IdTipoPago)
            {
                return BadRequest();
            }

            _context.Entry(factTipoPago).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FactTipoPagoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/FactTipoPagos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FactTipoPago>> PostFactTipoPago(FactTipoPago factTipoPago)
        {
          if (_context.FactTipoPago == null)
          {
              return Problem("Entity set 'DataContext.FactTipoPago'  is null.");
          }
            _context.FactTipoPago.Add(factTipoPago);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFactTipoPago", new { id = factTipoPago.IdTipoPago }, factTipoPago);
        }

        // DELETE: api/FactTipoPagos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFactTipoPago(int id)
        {
            if (_context.FactTipoPago == null)
            {
                return NotFound();
            }
            var factTipoPago = await _context.FactTipoPago.FindAsync(id);
            if (factTipoPago == null)
            {
                return NotFound();
            }

            _context.FactTipoPago.Remove(factTipoPago);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FactTipoPagoExists(int id)
        {
            return (_context.FactTipoPago?.Any(e => e.IdTipoPago == id)).GetValueOrDefault();
        }
    }
}
