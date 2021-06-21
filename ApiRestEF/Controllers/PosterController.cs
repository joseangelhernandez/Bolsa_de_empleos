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
    public class PosterController : ControllerBase
    {
        private readonly ApiRestEFContext _context;

        public PosterController(ApiRestEFContext context)
        {
            _context = context;
        }

        // GET: api/Poster
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Poster>>> GetPoster()
        {
            return await _context.Poster.ToListAsync();
        }

        // GET: api/Poster/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Poster>> GetPoster(int id)
        {
            var poster = await _context.Poster.FindAsync(id);

            if (poster == null)
            {
                return NotFound();
            }

            return poster;
        }

        // PUT: api/Poster/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPoster(int id, Poster poster)
        {
            if (id != poster.poster_id)
            {
                return BadRequest();
            }

            _context.Entry(poster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PosterExists(id))
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

        // POST: api/Poster
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Poster>> PostPoster(Poster poster)
        {
            _context.Poster.Add(poster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPoster", new { id = poster.poster_id }, poster);
        }

        // DELETE: api/Poster/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Poster>> DeletePoster(int id)
        {
            var poster = await _context.Poster.FindAsync(id);
            if (poster == null)
            {
                return NotFound();
            }

            _context.Poster.Remove(poster);
            await _context.SaveChangesAsync();

            return poster;
        }

        private bool PosterExists(int id)
        {
            return _context.Poster.Any(e => e.poster_id == id);
        }
    }
}
