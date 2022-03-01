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
    public class FactorRiesgosController : ControllerBase
    {
        private readonly consultorioContext _context;

        public FactorRiesgosController(consultorioContext context)
        {
            _context = context;
        }

        // GET: api/FactorRiesgos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Factorriesgo>>> GetFactorriesgos()
        {
            return await _context.Factorriesgos.ToListAsync();
        }

        // GET: api/FactorRiesgos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Factorriesgo>> GetFactorriesgo(int id)
        {
            var factorriesgo = await _context.Factorriesgos.FindAsync(id);

            if (factorriesgo == null)
            {
                return NotFound();
            }

            return factorriesgo;
        }

        // PUT: api/FactorRiesgos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFactorriesgo(int id, Factorriesgo factorriesgo)
        {
            if (id != factorriesgo.Id)
            {
                return BadRequest();
            }

            _context.Entry(factorriesgo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FactorriesgoExists(id))
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

        // POST: api/FactorRiesgos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Factorriesgo>> PostFactorriesgo(Factorriesgo factorriesgo)
        {
            _context.Factorriesgos.Add(factorriesgo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFactorriesgo", new { id = factorriesgo.Id }, factorriesgo);
        }

        // DELETE: api/FactorRiesgos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFactorriesgo(int id)
        {
            var factorriesgo = await _context.Factorriesgos.FindAsync(id);
            if (factorriesgo == null)
            {
                return NotFound();
            }

            _context.Factorriesgos.Remove(factorriesgo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FactorriesgoExists(int id)
        {
            return _context.Factorriesgos.Any(e => e.Id == id);
        }
    }
}
