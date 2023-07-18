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

    public class FactDetalleFacturasController : ControllerBase
    {
        private readonly DataContext _context;

        public FactDetalleFacturasController(DataContext context)
        {
            _context = context;
        }

        // GET: api/FactDetalleFacturas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FactDetalleFactura>>> GetFactDetalleFactura()
        {
          if (_context.FactDetalleFactura == null)
          {
              return NotFound();
          }
            //return await _context.FactDetalleFactura.ToListAsync();

            // Configurar la cabecera CORS en la respuesta
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            //incluir la cabecera de la FacturaCabecera
            //return await _context.FactDetalleFactura.Include(x => x.FacturaCabecera).ToListAsync();
            //icluir el cliente el la cabecera
            return await _context.FactDetalleFactura.Include(x => x.FacturaCabecera).ThenInclude(x => x.Cliente).ToListAsync();




        }

        // GET: api/FactDetalleFacturas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FactDetalleFactura>> GetFactDetalleFactura(int id)
        {
          if (_context.FactDetalleFactura == null)
          {
              return NotFound();
          }
            var factDetalleFactura = await _context.FactDetalleFactura.FindAsync(id);

            if (factDetalleFactura == null)
            {
                return NotFound();
            }
            // Configurar la cabecera CORS en la respuesta
            Response.Headers.Add("Access-Control-Allow-Origin", "*");

            return factDetalleFactura;
        }

        // PUT: api/FactDetalleFacturas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFactDetalleFactura(int id, FactDetalleFactura factDetalleFactura)
        {
            if (id != factDetalleFactura.IdDetalleFactura)
            {
                return BadRequest();
            }

            _context.Entry(factDetalleFactura).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FactDetalleFacturaExists(id))
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

        // POST: api/FactDetalleFacturas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FactDetalleFactura>> PostFactDetalleFactura(FactDetalleFactura factDetalleFactura)
        {
          if (_context.FactDetalleFactura == null)
          {
              return Problem("Entity set 'DataContext.FactDetalleFactura'  is null.");
          }
            _context.FactDetalleFactura.Add(factDetalleFactura);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFactDetalleFactura", new { id = factDetalleFactura.IdDetalleFactura }, factDetalleFactura);
        }

        // DELETE: api/FactDetalleFacturas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFactDetalleFactura(int id)
        {
            if (_context.FactDetalleFactura == null)
            {
                return NotFound();
            }
            var factDetalleFactura = await _context.FactDetalleFactura.FindAsync(id);
            if (factDetalleFactura == null)
            {
                return NotFound();
            }

            _context.FactDetalleFactura.Remove(factDetalleFactura);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FactDetalleFacturaExists(int id)
        {
            return (_context.FactDetalleFactura?.Any(e => e.IdDetalleFactura == id)).GetValueOrDefault();
        }
    }
}
