using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Destiny2DataLibrary.DataAccess;
using Destiny2DataLibrary.Models;

namespace DamageCheckerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArchetypesController : ControllerBase
    {
        private readonly Destiny2DataContext _context;

        public ArchetypesController(Destiny2DataContext context)
        {
            _context = context;
        }

        // GET: api/Archetypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Archetype>>> GetArchetypes()
        {
            return await _context.Archetypes.ToListAsync();
        }

        // GET: api/Archetypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Archetype>> GetArchetype(int id)
        {
            var archetype = await _context.Archetypes.FindAsync(id);

            if (archetype == null)
            {
                return NotFound();
            }

            return archetype;
        }

        // PUT: api/Archetypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArchetype(int id, Archetype archetype)
        {
            if (id != archetype.Id)
            {
                return BadRequest();
            }

            _context.Entry(archetype).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArchetypeExists(id))
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

        // POST: api/Archetypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Archetype>> PostArchetype(Archetype archetype)
        {
            _context.Archetypes.Add(archetype);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArchetype", new { id = archetype.Id }, archetype);
        }

        // DELETE: api/Archetypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArchetype(int id)
        {
            var archetype = await _context.Archetypes.FindAsync(id);
            if (archetype == null)
            {
                return NotFound();
            }

            _context.Archetypes.Remove(archetype);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArchetypeExists(int id)
        {
            return _context.Archetypes.Any(e => e.Id == id);
        }
    }
}
