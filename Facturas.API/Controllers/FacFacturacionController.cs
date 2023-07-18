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
    public class FacFacturacionController : ControllerBase
    {
        private readonly DataContext _context;

        public FacFacturacionController(DataContext context)
        {
            _context = context;
        }

        // GET: api/FacFacturacion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FacFacturacion>>> GetFacturacion()
        {
            if (_context.Facturacion == null)
            {
                return NotFound();
            }
            return await _context.Facturacion.Include(x => x.FactFacturaCabecera).ThenInclude(x => x.DetallesFactura).Include(x => x.TipoPago).ToListAsync();
        }

        // GET: api/FacFacturacion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FacFacturacion>> GetFacFacturacion(int id)
        {
          if (_context.Facturacion == null)
          {
              return NotFound();
          }
            var facFacturacion = await _context.Facturacion.FindAsync(id);

            if (facFacturacion == null)
            {
                return NotFound();
            }

            return facFacturacion;
        }

        // PUT: api/FacFacturacion/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFacFacturacion(int id, FacFacturacion facFacturacion)
        {
            if (id != facFacturacion.IdFactura)
            {
                return BadRequest();
            }

            _context.Entry(facFacturacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacFacturacionExists(id))
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

        // POST: api/FacFacturacion
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FacFacturacion>> PostFacFacturacion(FacFacturacion facFacturacion)
        {
          if (_context.Facturacion == null)
          {
              return Problem("Entity set 'DataContext.Facturacion'  is null.");
          }
            _context.Facturacion.Add(facFacturacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFacFacturacion", new { id = facFacturacion.IdFactura }, facFacturacion);
        }

        // DELETE: api/FacFacturacion/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFacFacturacion(int id)
        {
            if (_context.Facturacion == null)
            {
                return NotFound();
            }
            var facFacturacion = await _context.Facturacion.FindAsync(id);
            if (facFacturacion == null)
            {
                return NotFound();
            }

            _context.Facturacion.Remove(facFacturacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FacFacturacionExists(int id)
        {
            return (_context.Facturacion?.Any(e => e.IdFactura == id)).GetValueOrDefault();
        }
    }
}
