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
    public class SolicitasController : ControllerBase
    {
        private readonly ApiRestEFContext _context;

        public SolicitasController(ApiRestEFContext context)
        {
            _context = context;
        }

        // GET: api/Solicitas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Solicita>>> GetSolicita()
        {
            return await _context.Solicita.ToListAsync();
        }

        // GET: api/Solicitas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Solicita>> GetSolicita(int id)
        {
            var solicita = await _context.Solicita.FindAsync(id);

            if (solicita == null)
            {
                return NotFound();
            }

            return solicita;
        }

        // PUT: api/Solicitas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSolicita(int id, Solicita solicita)
        {
            if (id != solicita.solicita_id)
            {
                return BadRequest();
            }

            _context.Entry(solicita).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SolicitaExists(id))
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

        // POST: api/Solicitas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Solicita>> PostSolicita(Solicita solicita)
        {
            _context.Solicita.Add(solicita);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSolicita", new { id = solicita.solicita_id }, solicita);
        }

        // DELETE: api/Solicitas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Solicita>> DeleteSolicita(int id)
        {
            var solicita = await _context.Solicita.FindAsync(id);
            if (solicita == null)
            {
                return NotFound();
            }

            _context.Solicita.Remove(solicita);
            await _context.SaveChangesAsync();

            return solicita;
        }

        private bool SolicitaExists(int id)
        {
            return _context.Solicita.Any(e => e.solicita_id == id);
        }
    }
}
