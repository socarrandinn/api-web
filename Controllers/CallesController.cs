#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api_web.Models;

namespace api_web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CallesController : ControllerBase
    {
        private readonly consultorioContext _context;

        public CallesController(consultorioContext context)
        {
            _context = context;
        }

        // GET: api/Calles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Calle>>> GetCalles()
        {
            return await _context.Calles.ToListAsync();
        }

        // GET: api/Calles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Calle>> GetCalle(int id)
        {
            var calle = await _context.Calles.FindAsync(id);

            if (calle == null)
            {
                return NotFound();
            }

            return calle;
        }

        // PUT: api/Calles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCalle(int id, Calle calle)
        {
            if (id != calle.Id)
            {
                return BadRequest();
            }

            _context.Entry(calle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalleExists(id))
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

        // POST: api/Calles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Calle>> PostCalle(Calle calle)
        {
            _context.Calles.Add(calle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCalle", new { id = calle.Id }, calle);
        }

        // DELETE: api/Calles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCalle(int id)
        {
            var calle = await _context.Calles.FindAsync(id);
            if (calle == null)
            {
                return NotFound();
            }

            _context.Calles.Remove(calle);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CalleExists(int id)
        {
            return _context.Calles.Any(e => e.Id == id);
        }
    }
}
