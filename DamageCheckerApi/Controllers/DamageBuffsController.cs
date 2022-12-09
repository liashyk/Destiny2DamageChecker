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
    public class DamageBuffsController : ControllerBase
    {
        private readonly Destiny2DataContext _context;

        public DamageBuffsController(Destiny2DataContext context)
        {
            _context = context;
        }

        // GET: api/DamageBuffs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DamageBuff>>> GetDamageBuffs()
        {
            return await _context.DamageBuffs
                .Include(b=>b.BuffCategory)
                .Include(b=>b.BuffStacks)
                .ToListAsync();
        }

        // GET: api/DamageBuffs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DamageBuff>> GetDamageBuff(int id)
        {
            var damageBuff = await 
                _context.DamageBuffs
                .Include(_b => _b.BuffCategory)
                .Include(_b => _b.BuffStacks)
                .Where(b => b.Id == id)
                .SingleOrDefaultAsync();

            if (damageBuff == null)
            {
                return NotFound();
            }

            return damageBuff;
        }

        //// PUT: api/DamageBuffs/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutDamageBuff(int id, DamageBuff damageBuff)
        //{
        //    if (id != damageBuff.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(damageBuff).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!DamageBuffExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/DamageBuffs
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<DamageBuff>> PostDamageBuff(DamageBuff damageBuff)
        //{
        //    _context.DamageBuffs.Add(damageBuff);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetDamageBuff", new { id = damageBuff.Id }, damageBuff);
        //}

        //// DELETE: api/DamageBuffs/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteDamageBuff(int id)
        //{
        //    var damageBuff = await _context.DamageBuffs.FindAsync(id);
        //    if (damageBuff == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.DamageBuffs.Remove(damageBuff);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool DamageBuffExists(int id)
        //{
        //    return _context.DamageBuffs.Any(e => e.Id == id);
        //}
    }
}
