﻿using System;
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
    public class MotoristasController : ControllerBase
    {
        private readonly GoHorseContext _context;

        public MotoristasController(GoHorseContext context)
        {
            _context = context;
        }

        // GET: api/Motoristas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Motorista>>> GetMotoristas()
        {
            return await _context.Motoristas.ToListAsync();
        }

        // GET: api/Motoristas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Motorista>> GetMotorista(int id)
        {
            var motorista = await _context.Motoristas.FindAsync(id);

            if (motorista == null)
            {
                return NotFound();
            }

            return motorista;
        }

        // PUT: api/Motoristas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMotorista(int id, Motorista motorista)
        {
            if (id != motorista.Id)
            {
                return BadRequest();
            }

            _context.Entry(motorista).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MotoristaExists(id))
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

        // POST: api/Motoristas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Motorista>> PostMotorista(Motorista motorista)
        {
            _context.Motoristas.Add(motorista);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMotorista", new { id = motorista.Id }, motorista);
        }

        // DELETE: api/Motoristas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Motorista>> DeleteMotorista(int id)
        {
            var motorista = await _context.Motoristas.FindAsync(id);
            if (motorista == null)
            {
                return NotFound();
            }

            _context.Motoristas.Remove(motorista);
            await _context.SaveChangesAsync();

            return motorista;
        }

        private bool MotoristaExists(int id)
        {
            return _context.Motoristas.Any(e => e.Id == id);
        }
    }
}
