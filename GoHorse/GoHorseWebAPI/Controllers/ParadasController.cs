using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GoHorseClassLibrary;
using GoHorseDAL;

namespace GoHorseWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParadasController : ControllerBase
    {
        private readonly GoHorseContext _context;

        public ParadasController(GoHorseContext context)
        {
            _context = context;
        }

        // GET: api/Paradas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Parada>>> GetParadas()
        {
            return await _context.Paradas.ToListAsync();
        }

        // GET: api/Paradas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Parada>> GetParada(int id)
        {
            var parada = await _context.Paradas.FindAsync(id);

            if (parada == null)
            {
                return NotFound();
            }

            return parada;
        }

        // PUT: api/Paradas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParada(int id, Parada parada)
        {
            if (id != parada.Id)
            {
                return BadRequest();
            }

            _context.Entry(parada).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParadaExists(id))
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

        // POST: api/Paradas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Parada>> PostParada(Parada parada)
        {
            _context.Paradas.Add(parada);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParada", new { id = parada.Id }, parada);
        }

        // DELETE: api/Paradas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Parada>> DeleteParada(int id)
        {
            var parada = await _context.Paradas.FindAsync(id);
            if (parada == null)
            {
                return NotFound();
            }

            _context.Paradas.Remove(parada);
            await _context.SaveChangesAsync();

            return parada;
        }

        private bool ParadaExists(int id)
        {
            return _context.Paradas.Any(e => e.Id == id);
        }
    }
}
