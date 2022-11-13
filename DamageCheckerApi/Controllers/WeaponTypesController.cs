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
    public class WeaponTypesController : ControllerBase
    {
        private readonly Destiny2DataContext _context;

        public WeaponTypesController(Destiny2DataContext context)
        {
            _context = context;
        }

        // GET: api/WeaponTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeaponType>>> GetWeaponTypes()
        {
            return await _context.WeaponTypes.Include(w=>w.ReloadStats).ToListAsync();
        }

        // GET: api/WeaponTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WeaponType>> GetWeaponType(int id)
        {
            var weaponType = await _context.WeaponTypes
                .Include(w => w.ReloadStats)
                .Where(w => w.Id == id)
                .FirstOrDefaultAsync();

            if (weaponType == null)
            {
                return NotFound();
            }

            return weaponType;
        }

        // PUT: api/WeaponTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWeaponType(int id, WeaponType weaponType)
        {
            if (id != weaponType.Id)
            {
                return BadRequest();
            }

            _context.Entry(weaponType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WeaponTypeExists(id))
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

        // POST: api/WeaponTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WeaponType>> PostWeaponType(WeaponType weaponType)
        {
            _context.WeaponTypes.Add(weaponType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWeaponType", new { id = weaponType.Id }, weaponType);
        }

        // DELETE: api/WeaponTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeaponType(int id)
        {
            var weaponType = await _context.WeaponTypes.FindAsync(id);
            if (weaponType == null)
            {
                return NotFound();
            }

            _context.WeaponTypes.Remove(weaponType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WeaponTypeExists(int id)
        {
            return _context.WeaponTypes.Any(e => e.Id == id);
        }
    }
}
