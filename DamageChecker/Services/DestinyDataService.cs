using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Destiny2DataLibrary.DataAccess;
using Destiny2DataLibrary.Models;

namespace DamageChecker.Services.Data
{
    public class DestinyDataService
    {
        public DestinyDataService()
        {
        }

        #region archetypes
        public async Task<IEnumerable<Archetype>> GetArchetypes()
        {
            List<Archetype> archetypes = await GetArchetypesListAsync();
            return archetypes;
        }

        private async Task<List<Archetype>> GetArchetypesListAsync()
        {
            using (var context = new Destiny2DataContext())
            {
                return await context.Archetypes.
                Include(a => a.WeaponType).
                Include(a => a.AmmoType).
                Include(a => a.WeaponType).
                Include(a => a.BurstStats).
                Include(a => a.ShotDamage).ToListAsync();
            }
        }

        private async Task<Archetype> GetArchetypeWithId(int id)
        {
            using(var context = new Destiny2DataContext())
            {
                var archetypes = await GetArchetypesListAsync();
                Archetype archetype = archetypes.Where(a => a.Id == id).FirstOrDefault();
                var weaponTypeBuffer = await context.WeaponTypes
                    .Include(w => w.ReloadStats)
                    .Where(w => w.Id == archetype.WeaponType.Id)
                    .FirstOrDefaultAsync();
                if (weaponTypeBuffer != null)
                    archetype.WeaponType = weaponTypeBuffer;
                return archetype;
            }
        }

        public async Task<Archetype> GetArchetype(int id)
        {
            using (var context = new Destiny2DataContext())
            {
                var archetype = await GetArchetypeWithId(id);
                return archetype;
            }
        }

        public async Task<IEnumerable<Archetype>> GetArchetypeWithWeaponTypeId(int weaponTypeId)
        {
            var archetypes = await GetArchetypesListAsync();
            var result = archetypes.Where(a => a.WeaponType.Id == weaponTypeId);
            if (result.Count() == 0)
            {
            }
            return result.ToList();
        }
        #endregion

        #region DamageBuffs

        public async Task<IEnumerable<DamageBuff>> GetDamageBuffs()
        {
            using (var context = new Destiny2DataContext())
            {
                return await context.DamageBuffs
                .Include(b => b.BuffCategory)
                .Include(b => b.BuffStacks)
                .ToListAsync();
            }
        }

        public async Task<DamageBuff> GetDamageBuff(int id)
        {
            using (var context = new Destiny2DataContext())
            {
                var damageBuff = await
                context.DamageBuffs
                .Include(_b => _b.BuffCategory)
                .Include(_b => _b.BuffStacks)
                .Where(b => b.Id == id)
                .SingleOrDefaultAsync();
                return damageBuff;
            }
        }
        #endregion

        #region Perks
        public async Task<ActionResult<IEnumerable<Perk>>> GetPerks()
        {
            using (var context = new Destiny2DataContext())
            {
                return await context.Perks.Include(p => p.BuffStacks).ToListAsync();
            }

        }

        public async Task<ActionResult<Perk>> GetPerk(int id)
        {
            Perk? perk = await GetPerkByID(id);
            return perk;
        }

        public async Task<IEnumerable<Perk>> GetPerksFromArchetypeId(int archetypeID)
        {
            using (var context = new Destiny2DataContext())
            {
                Archetype? archetype = await context.Archetypes.Include(a => a.Perks).
                Where(a => a.Id == archetypeID).FirstOrDefaultAsync();
                var archetypePerks = archetype.Perks.ToList();
                List<Perk> perks = await context.Perks.Include(p => p.BuffStacks).ToListAsync();
                List<Task<Perk>> perkTasks = new List<Task<Perk>>();
                foreach (Perk it in archetypePerks)
                {
                    var currentID = it.Id;
                    perkTasks.Add(GetPerkByID(currentID));
                }
                return await Task.WhenAll(perkTasks);
            }
        }

        private async Task<Perk> GetPerkByID(int perkId)
        {
            using (var context = new Destiny2DataContext())
            {
                Perk? perk = await context.Perks.Include(p => p.BuffStacks)
                .Where(p => p.Id == perkId)
                .FirstOrDefaultAsync();
                perk.Archetypes = null;
                return perk;
            }
        }
        #endregion

        #region WeaponTypes

        public async Task<IEnumerable<WeaponType>> GetWeaponTypes()
        {
            using (var context = new Destiny2DataContext())
            {
                return await context.WeaponTypes.Include(w => w.ReloadStats).ToListAsync();
            }
        }

        public async Task<WeaponType> GetWeaponType(int id)
        {
            using (var context = new Destiny2DataContext())
            {
                var weaponType = await context.WeaponTypes
                .Include(w => w.ReloadStats)
                .Where(w => w.Id == id)
                .FirstOrDefaultAsync();

                return weaponType;
            }
        }

        private bool WeaponTypeExists(int id)
        {
            using (var context = new Destiny2DataContext())
            {
                return context.WeaponTypes.Any(e => e.Id == id);
            }
        }
        #endregion
    }
}
