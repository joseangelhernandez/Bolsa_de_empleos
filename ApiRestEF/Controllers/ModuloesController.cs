using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiRestEF.Data;
using ApiRestEF.Models;

namespace ApiRestEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModuloesController : ControllerBase
    {
        private readonly ApiRestEFContext _context;

        public ModuloesController(ApiRestEFContext context)
        {
            _context = context;
        }

        // GET: api/Moduloes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Modulo>>> GetModulo()
        {
            return await _context.Modulo.ToListAsync();
        }

        // GET: api/Moduloes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Modulo>> GetModulo(int id)
        {
            var modulo = await _context.Modulo.FindAsync(id);

            if (modulo == null)
            {
                return NotFound();
            }

            return modulo;
        }

        // PUT: api/Moduloes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModulo(int id, Modulo modulo)
        {
            if (id != modulo.Id)
            {
                return BadRequest();
            }

            _context.Entry(modulo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModuloExists(id))
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

        // POST: api/Moduloes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Modulo>> PostModulo(Modulo modulo)
        {
            _context.Modulo.Add(modulo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetModulo", new { id = modulo.Id }, modulo);
        }

        // DELETE: api/Moduloes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Modulo>> DeleteModulo(int id)
        {
            var modulo = await _context.Modulo.FindAsync(id);
            if (modulo == null)
            {
                return NotFound();
            }

            _context.Modulo.Remove(modulo);
            await _context.SaveChangesAsync();

            return modulo;
        }

        private bool ModuloExists(int id)
        {
            return _context.Modulo.Any(e => e.Id == id);
        }
    }
}
