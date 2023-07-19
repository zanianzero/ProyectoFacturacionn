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
    public class FactAuditoriaController : ControllerBase
    {
        private readonly DataContext _context;

        public FactAuditoriaController(DataContext context)
        {
            _context = context;
        }

        // GET: api/FactAuditoria
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FactAuditoria>>> GetFactAuditoria()
        {
          if (_context.FactAuditoria == null)
          {
              return NotFound();
          }
            return await _context.FactAuditoria.ToListAsync();
        }

        // GET: api/FactAuditoria/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FactAuditoria>> GetFactAuditoria(int id)
        {
          if (_context.FactAuditoria == null)
          {
              return NotFound();
          }
            var factAuditoria = await _context.FactAuditoria.FindAsync(id);

            if (factAuditoria == null)
            {
                return NotFound();
            }

            return factAuditoria;
        }

        // PUT: api/FactAuditoria/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFactAuditoria(int id, FactAuditoria factAuditoria)
        {
            if (id != factAuditoria.aud_id)
            {
                return BadRequest();
            }

            _context.Entry(factAuditoria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FactAuditoriaExists(id))
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

        // POST: api/FactAuditoria
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FactAuditoria>> PostFactAuditoria(FactAuditoria factAuditoria)
        {
          if (_context.FactAuditoria == null)
          {
              return Problem("Entity set 'DataContext.FactAuditoria'  is null.");
          }
            _context.FactAuditoria.Add(factAuditoria);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFactAuditoria", new { id = factAuditoria.aud_id }, factAuditoria);
        }

        // DELETE: api/FactAuditoria/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFactAuditoria(int id)
        {
            if (_context.FactAuditoria == null)
            {
                return NotFound();
            }
            var factAuditoria = await _context.FactAuditoria.FindAsync(id);
            if (factAuditoria == null)
            {
                return NotFound();
            }

            _context.FactAuditoria.Remove(factAuditoria);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FactAuditoriaExists(int id)
        {
            return (_context.FactAuditoria?.Any(e => e.aud_id == id)).GetValueOrDefault();
        }
    }
}
