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
    public class productosController : ControllerBase
    {
        private readonly DataContext _context;

        public productosController(DataContext context)
        {
            _context = context;
        }

        // GET: api/productos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<productos>>> Getproductos()
        {
          if (_context.productos == null)
          {
              return NotFound();
          }
            return await _context.productos.ToListAsync();
        }

        // GET: api/productos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<productos>> Getproductos(int id)
        {
          if (_context.productos == null)
          {
              return NotFound();
          }
            var productos = await _context.productos.FindAsync(id);

            if (productos == null)
            {
                return NotFound();
            }

            return productos;
        }

        // PUT: api/productos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putproductos(int id, productos productos)
        {
            if (id != productos.pro_id)
            {
                return BadRequest();
            }

            _context.Entry(productos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!productosExists(id))
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

        // POST: api/productos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<productos>> Postproductos(productos productos)
        {
          if (_context.productos == null)
          {
              return Problem("Entity set 'DataContext.productos'  is null.");
          }
            _context.productos.Add(productos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getproductos", new { id = productos.pro_id }, productos);
        }

        // DELETE: api/productos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteproductos(int id)
        {
            if (_context.productos == null)
            {
                return NotFound();
            }
            var productos = await _context.productos.FindAsync(id);
            if (productos == null)
            {
                return NotFound();
            }

            _context.productos.Remove(productos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool productosExists(int id)
        {
            return (_context.productos?.Any(e => e.pro_id == id)).GetValueOrDefault();
        }
    }
}
