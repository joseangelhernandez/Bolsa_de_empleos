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
    public class SolicitanteController : ControllerBase
    {
        private readonly ApiRestEFContext _context;

        public SolicitanteController(ApiRestEFContext context)
        {
            _context = context;
        }

        // GET: api/Solicitante
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Solicitante>>> GetSolicitante()
        {
            return await _context.Solicitante.ToListAsync();
        }

        // GET: api/Solicitante/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Solicitante>> GetSolicitante(int id)
        {
            var solicitante = await _context.Solicitante.FindAsync(id);

            if (solicitante == null)
            {
                return NotFound();
            }

            return solicitante;
        }

        // PUT: api/Solicitante/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSolicitante(int id, Solicitante solicitante)
        {
            if (id != solicitante.soli_id)
            {
                return BadRequest();
            }

            _context.Entry(solicitante).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SolicitanteExists(id))
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

        // POST: api/Solicitante
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Solicitante>> PostSolicitante(Solicitante solicitante)
        {
            _context.Solicitante.Add(solicitante);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSolicitante", new { id = solicitante.soli_id }, solicitante);
        }

        // DELETE: api/Solicitante/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Solicitante>> DeleteSolicitante(int id)
        {
            var solicitante = await _context.Solicitante.FindAsync(id);
            if (solicitante == null)
            {
                return NotFound();
            }

            _context.Solicitante.Remove(solicitante);
            await _context.SaveChangesAsync();

            return solicitante;
        }

        private bool SolicitanteExists(int id)
        {
            return _context.Solicitante.Any(e => e.soli_id == id);
        }
    }
}
