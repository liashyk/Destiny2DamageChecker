using Destiny2DataLibrary.DataAccess;
using Destiny2DataLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.AccessControl;

namespace DamageCheckerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerksController : ControllerBase
    {
        Destiny2DataContext _context;
        public PerksController(Destiny2DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Perk>>> GetPerks()
        {
            return await _context.Perks.Include(p => p.ActivationSteps).ToListAsync();

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Perk>> GetPerk(int id)
        {
            Perk? perk = await _context.Perks.Include(p => p.ActivationSteps)
                .Where(p => p.Id == id).FirstOrDefaultAsync();
            if (perk == null)
            {
                return NotFound();
            }
            return perk;
        }

        //[HttpGet("/with-archetype/{archetypeID}")]
        //public async Task<ActionResult<IEnumerable<Perk>>> GetPerksWithArchetypeId(int archetypeID)
        //{
        //    Archetype? archetype = await _context.Archetypes.Include(a => a.Perks).
        //        Where(a => a.Id == archetypeID).FirstOrDefaultAsync();
        //    if (archetype == null)
        //    {
        //        return NotFound();
        //    }
        //    return archetype.Perks.ToList();
        //}

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePerk(int id)
        {
            Perk? perk = await _context.Perks.FindAsync(id);
            if (perk == null)
            {
                return NotFound();
            }
            _context.Perks.Remove(perk);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult> PostPerk(Perk perk)
        {
            _context.Perks.Add(perk);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetPerk", new { id = perk.Id }, perk);
        }
    }
}
