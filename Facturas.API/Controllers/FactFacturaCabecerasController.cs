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

    public class FactFacturaCabecerasController : ControllerBase
    {
        private readonly DataContext _context;

        public FactFacturaCabecerasController(DataContext context)
        {
            _context = context;
        }

        // GET: api/FactFacturaCabeceras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FactFacturaCabecera>>> GetFactFacturaCabecera()
        {
          if (_context.FactFacturaCabecera == null)
          {
              return NotFound();
          }
            // Configurar la cabecera CORS en la respuesta
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            // return await _context.FactFacturaCabecera.ToListAsync();
            //incluir el Cliente, DetalleFactura, TipoPago
            return await _context.FactFacturaCabecera.Include(x => x.Cliente).Include(x => x.DetallesFactura).Include(x => x.TipoPago).ToListAsync();




        }

        // GET: api/FactFacturaCabeceras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FactFacturaCabecera>> GetFactFacturaCabecera(int id)
        {
          if (_context.FactFacturaCabecera == null)
          {
              return NotFound();
          }
            var factFacturaCabecera = await _context.FactFacturaCabecera.FindAsync(id);

            if (factFacturaCabecera == null)
            {
                return NotFound();
            }
            // Configurar la cabecera CORS en la respuesta
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            return factFacturaCabecera;
        }

        // PUT: api/FactFacturaCabeceras/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFactFacturaCabecera(int id, FactFacturaCabecera factFacturaCabecera)
        {
            if (id != factFacturaCabecera.IdFacturaCabecera)
            {
                return BadRequest();

            }

            _context.Entry(factFacturaCabecera).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FactFacturaCabeceraExists(id))
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

        // POST: api/FactFacturaCabeceras
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FactFacturaCabecera>> PostFactFacturaCabecera(FactFacturaCabecera factFacturaCabecera)
        {
          if (_context.FactFacturaCabecera == null)
          {
              return Problem("Entity set 'DataContext.FactFacturaCabecera'  is null.");
          }
            _context.FactFacturaCabecera.Add(factFacturaCabecera);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFactFacturaCabecera", new { id = factFacturaCabecera.IdFacturaCabecera }, factFacturaCabecera);
        }

        // DELETE: api/FactFacturaCabeceras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFactFacturaCabecera(int id)
        {
            if (_context.FactFacturaCabecera == null)
            {
                return NotFound();
            }
            var factFacturaCabecera = await _context.FactFacturaCabecera.FindAsync(id);
            if (factFacturaCabecera == null)
            {
                return NotFound();
            }

            _context.FactFacturaCabecera.Remove(factFacturaCabecera);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FactFacturaCabeceraExists(int id)
        {
            return (_context.FactFacturaCabecera?.Any(e => e.IdFacturaCabecera == id)).GetValueOrDefault();
        }
    }
}
