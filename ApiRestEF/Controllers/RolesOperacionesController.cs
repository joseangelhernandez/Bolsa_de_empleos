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
    public class RolesOperacionesController : ControllerBase
    {
        private readonly ApiRestEFContext _context;

        public RolesOperacionesController(ApiRestEFContext context)
        {
            _context = context;
        }

        // GET: api/RolesOperaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RolOperacion>>> GetRolOperacion()
        {
            return await _context.RolOperacion.ToListAsync();
        }

        // GET: api/RolesOperaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RolOperacion>> GetRolOperacion(int id)
        {
            var rolOperacion = await _context.RolOperacion.FindAsync(id);

            if (rolOperacion == null)
            {
                return NotFound();
            }

            return rolOperacion;
        }

        // PUT: api/RolesOperaciones/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRolOperacion(int id, RolOperacion rolOperacion)
        {
            if (id != rolOperacion.Id)
            {
                return BadRequest();
            }

            _context.Entry(rolOperacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RolOperacionExists(id))
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

        // POST: api/RolesOperaciones
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<RolOperacion>> PostRolOperacion(RolOperacion rolOperacion)
        {
            _context.RolOperacion.Add(rolOperacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRolOperacion", new { id = rolOperacion.Id }, rolOperacion);
        }

        // DELETE: api/RolesOperaciones/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RolOperacion>> DeleteRolOperacion(int id)
        {
            var rolOperacion = await _context.RolOperacion.FindAsync(id);
            if (rolOperacion == null)
            {
                return NotFound();
            }

            _context.RolOperacion.Remove(rolOperacion);
            await _context.SaveChangesAsync();

            return rolOperacion;
        }

        private bool RolOperacionExists(int id)
        {
            return _context.RolOperacion.Any(e => e.Id == id);
        }
    }
}
