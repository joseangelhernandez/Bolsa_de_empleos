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
    public class OperacionesController : ControllerBase
    {
        private readonly ApiRestEFContext _context;

        public OperacionesController(ApiRestEFContext context)
        {
            _context = context;
        }

        // GET: api/Operaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Operaciones>>> GetOperaciones()
        {
            return await _context.Operaciones.ToListAsync();
        }

        // GET: api/Operaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Operaciones>> GetOperaciones(int id)
        {
            var operaciones = await _context.Operaciones.FindAsync(id);

            if (operaciones == null)
            {
                return NotFound();
            }

            return operaciones;
        }

        // PUT: api/Operaciones/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOperaciones(int id, Operaciones operaciones)
        {
            if (id != operaciones.Id)
            {
                return BadRequest();
            }

            _context.Entry(operaciones).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OperacionesExists(id))
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

        // POST: api/Operaciones
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Operaciones>> PostOperaciones(Operaciones operaciones)
        {
            _context.Operaciones.Add(operaciones);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOperaciones", new { id = operaciones.Id }, operaciones);
        }

        // DELETE: api/Operaciones/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Operaciones>> DeleteOperaciones(int id)
        {
            var operaciones = await _context.Operaciones.FindAsync(id);
            if (operaciones == null)
            {
                return NotFound();
            }

            _context.Operaciones.Remove(operaciones);
            await _context.SaveChangesAsync();

            return operaciones;
        }

        private bool OperacionesExists(int id)
        {
            return _context.Operaciones.Any(e => e.Id == id);
        }
    }
}
