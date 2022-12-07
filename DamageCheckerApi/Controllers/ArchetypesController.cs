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
            List<Archetype> archetypes = await GetArchetypesListAsync();
            return archetypes;
        }

        private async Task<List<Archetype>> GetArchetypesListAsync()
        {
            return await _context.Archetypes.
                Include(a => a.WeaponType).
                Include(a => a.AmmoType).
                Include(a => a.WeaponType).
                Include(a => a.BurstStats).
                Include(a => a.ShotDamage).ToListAsync();
        }

        private async Task<ActionResult<Archetype>> GetArchetypeWithId(int id)
        {
            var archetypes = await GetArchetypesListAsync();
            Archetype archetype = archetypes.Where(a => a.Id == id).FirstOrDefault();
            var weaponTypeBuffer= await _context.WeaponTypes
                .Include(w => w.ReloadStats)
                .Where(w => w.Id == archetype.WeaponType.Id)
                .FirstOrDefaultAsync();
            if (weaponTypeBuffer != null)
                archetype.WeaponType = weaponTypeBuffer;
            return archetype;
        }

        // GET: api/Archetypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Archetype>> GetArchetype(int id)
        {
            var archetype = await GetArchetypeWithId(id);

            if (archetype == null)
            {
                return NotFound();
            }

            return archetype;
        }

        //Take archetypeId and return perks that this archetype in contain
        [HttpGet("FromWeaponType/{weaponTypeId}")]
        public async Task<ActionResult<IEnumerable<Archetype>>> GetArchetypeWithWeaponTypeId(int weaponTypeId)
        {
            var archetypes = await GetArchetypesListAsync();
            var result = archetypes.Where(a => a.WeaponType.Id == weaponTypeId);
            if (result.Count() == 0)
            {
                return NotFound();
            }
            return result.ToList();
        }
    }
}
