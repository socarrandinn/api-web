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
    public class PoblacionsController : ControllerBase
    {
        private readonly consultorioContext _context;

        public PoblacionsController(consultorioContext context)
        {
            _context = context;
        }

        // GET: api/Poblacions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Poblacion>>> GetPoblacions()
        {
            return await _context.Poblacions.ToListAsync();
        }

        // GET: api/Poblacions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Poblacion>> GetPoblacion(int id)
        {
            var poblacion = await _context.Poblacions.FindAsync(id);

            if (poblacion == null)
            {
                return NotFound();
            }

            return poblacion;
        }

        // PUT: api/Poblacions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPoblacion(int id, Poblacion poblacion)
        {
            if (id != poblacion.Id)
            {
                return BadRequest();
            }

            _context.Entry(poblacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PoblacionExists(id))
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

        // POST: api/Poblacions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Poblacion>> PostPoblacion(Poblacion poblacion)
        {
            _context.Poblacions.Add(poblacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPoblacion", new { id = poblacion.Id }, poblacion);
        }

        // DELETE: api/Poblacions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePoblacion(int id)
        {
            var poblacion = await _context.Poblacions.FindAsync(id);
            if (poblacion == null)
            {
                return NotFound();
            }

            _context.Poblacions.Remove(poblacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PoblacionExists(int id)
        {
            return _context.Poblacions.Any(e => e.Id == id);
        }
    }
}
