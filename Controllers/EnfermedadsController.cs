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
    public class EnfermedadsController : ControllerBase
    {
        private readonly consultorioContext _context;

        public EnfermedadsController(consultorioContext context)
        {
            _context = context;
        }

        // GET: api/Enfermedads
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Enfermedad>>> GetEnfermedads()
        {
            return await _context.Enfermedads.ToListAsync();
        }

        // GET: api/Enfermedads/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Enfermedad>> GetEnfermedad(int id)
        {
            var enfermedad = await _context.Enfermedads.FindAsync(id);

            if (enfermedad == null)
            {
                return NotFound();
            }

            return enfermedad;
        }

        // PUT: api/Enfermedads/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnfermedad(int id, Enfermedad enfermedad)
        {
            if (id != enfermedad.Id)
            {
                return BadRequest();
            }

            _context.Entry(enfermedad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnfermedadExists(id))
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

        // POST: api/Enfermedads
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Enfermedad>> PostEnfermedad(Enfermedad enfermedad)
        {
            _context.Enfermedads.Add(enfermedad);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEnfermedad", new { id = enfermedad.Id }, enfermedad);
        }

        // DELETE: api/Enfermedads/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnfermedad(int id)
        {
            var enfermedad = await _context.Enfermedads.FindAsync(id);
            if (enfermedad == null)
            {
                return NotFound();
            }

            _context.Enfermedads.Remove(enfermedad);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EnfermedadExists(int id)
        {
            return _context.Enfermedads.Any(e => e.Id == id);
        }
    }
}
