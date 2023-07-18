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
    public class FactClientesController : ControllerBase
    {
        private readonly DataContext _context;

        public FactClientesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/FactClientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FactCliente>>> GetFactCliente()
        {
          if (_context.FactCliente == null)
          {
              return NotFound();
          }

            // Configurar la cabecera CORS en la respuesta
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            ///incluir  el TipoPago  return
            //return await _context.FactCliente.Include(x => x.FacturaCabeceras).Include(x => x.TipoPago).ToListAsync();
            //tambien desplegar la cabecera de cada factura
            return await _context.FactCliente.Include(x => x.FacturaCabeceras).ThenInclude(x => x.DetallesFactura).ToListAsync();



        }

        // GET: api/FactClientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FactCliente>> GetFactCliente(string id)
        {
          if (_context.FactCliente == null)
          {
              return NotFound();
          }
            //var factCliente = await _context.FactCliente.FindAsync(id);
            //tambien desplegar la cabecera en cada factura
            var factCliente = await _context.FactCliente.Include(x => x.FacturaCabeceras).ThenInclude(x => x.DetallesFactura).FirstOrDefaultAsync(x => x.Identificacion == id);



            if (factCliente == null)
            {
                return NotFound();
            }

            // Configurar la cabecera CORS en la respuesta
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            return factCliente;
        }

        // PUT: api/FactClientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFactCliente(string id, FactCliente factCliente)
        {
            if (id != factCliente.Identificacion)
            {
                return BadRequest();
            }

            _context.Entry(factCliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FactClienteExists(id))
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

        // POST: api/FactClientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FactCliente>> PostFactCliente(FactCliente factCliente)
        {
          if (_context.FactCliente == null)
          {
              return Problem("Entity set 'DataContext.FactCliente'  is null.");
          }
            _context.FactCliente.Add(factCliente);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FactClienteExists(factCliente.Identificacion))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFactCliente", new { id = factCliente.Identificacion }, factCliente);
        }

        // DELETE: api/FactClientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFactCliente(string id)
        {
            if (_context.FactCliente == null)
            {
                return NotFound();
            }
            var factCliente = await _context.FactCliente.FindAsync(id);
            if (factCliente == null)
            {
                return NotFound();
            }

            _context.FactCliente.Remove(factCliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FactClienteExists(string id)
        {
            return (_context.FactCliente?.Any(e => e.Identificacion == id)).GetValueOrDefault();
        }
    }
}
