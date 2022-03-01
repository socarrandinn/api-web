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
    public class ConsultoriomedicosController : ControllerBase
    {
        private readonly consultorioContext _context;

        public ConsultoriomedicosController(consultorioContext context)
        {
            _context = context;
        }

        // GET: api/Consultoriomedicos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Consultoriomedico>>> GetConsultoriomedicos()
        {
            return await _context.Consultoriomedicos.ToListAsync();
        }

        // GET: api/Consultoriomedicos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Consultoriomedico>> GetConsultoriomedico(int id)
        {
            var consultoriomedico = await _context.Consultoriomedicos.FindAsync(id);

            if (consultoriomedico == null)
            {
                return NotFound();
            }

            return consultoriomedico;
        }

        // PUT: api/Consultoriomedicos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConsultoriomedico(int id, Consultoriomedico consultoriomedico)
        {
            if (id != consultoriomedico.Id)
            {
                return BadRequest();
            }

            _context.Entry(consultoriomedico).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsultoriomedicoExists(id))
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

        // POST: api/Consultoriomedicos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Consultoriomedico>> PostConsultoriomedico(Consultoriomedico consultoriomedico)
        {
            _context.Consultoriomedicos.Add(consultoriomedico);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConsultoriomedico", new { id = consultoriomedico.Id }, consultoriomedico);
        }

        // DELETE: api/Consultoriomedicos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConsultoriomedico(int id)
        {
            var consultoriomedico = await _context.Consultoriomedicos.FindAsync(id);
            if (consultoriomedico == null)
            {
                return NotFound();
            }

            _context.Consultoriomedicos.Remove(consultoriomedico);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConsultoriomedicoExists(int id)
        {
            return _context.Consultoriomedicos.Any(e => e.Id == id);
        }
    }
}
