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
        public async Task<IEnumerable<Archetype>> GetArchetypesAsync()
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

        public IEnumerable<Archetype> GetArchetypes()
        {
            using (var context = new Destiny2DataContext())
            {
                return context.Archetypes.
                Include(a => a.WeaponType).
                Include(a => a.AmmoType).
                Include(a => a.WeaponType).
                Include(a => a.BurstStats).
                Include(a => a.ShotDamage).ToList();
            }
        }

        private async Task<Archetype> GetArchetypeWithIdAsync(int id)
        {
            using(var context = new Destiny2DataContext())
            {
                var archetypes = await GetArchetypesAsync();
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

        public async Task<Archetype> GetArchetypeAsync(int id)
        {
            using (var context = new Destiny2DataContext())
            {
                var archetype = await GetArchetypeWithIdAsync(id);
                return archetype;
            }
        }

        public async Task<IEnumerable<Archetype>> GetArchetypeWithWeaponTypeId(int weaponTypeId)
        {
            var archetypes = await GetArchetypesAsync();
            var result = archetypes.Where(a => a.WeaponType.Id == weaponTypeId);
            if (result.Count() == 0)
            {
            }
            return result.ToList();
        }
        #endregion

        #region DamageBuffs

        public IEnumerable<DamageBuff> GetDamageBuffs()
        {
            using (var context = new Destiny2DataContext())
            {
                return context.DamageBuffs
                .Include(b => b.BuffCategory)
                .Include(b => b.BuffStacks)
                .ToList();
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
        public IEnumerable<Perk> GetPerks()
        {
            using (var context = new Destiny2DataContext())
            {
                return context.Perks
                    .Include(p => p.BuffStacks)
                    .Include(p=>p.Archetypes)
                    .ToList();
            }

        }

        public async Task<Perk> GetPerk(int id)
        {
            Perk? perk = await GetPerkByIdAsync(id);
            return perk;
        }

        public async Task<IEnumerable<Perk>> GetPerksFromArchetypeIdAsync(int archetypeID)
        {
            using (var context = new Destiny2DataContext())
            {
                var perks = GetPerks();
                return perks.Where(p => p.Archetypes.Any(a => a.Id == archetypeID));
            }
        }

        public IEnumerable<Perk> GetPerksFromArchetypeId(int archetypeID)
        {
            using (var context = new Destiny2DataContext())
            {
                var perks = GetPerks();
                return perks.Where(p=>p.Archetypes.Any(a=>a.Id==archetypeID));

            }
        }

        private async Task<Perk> GetPerkByIdAsync(int perkId)
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

        public IEnumerable<WeaponType> GetWeaponTypes()
        {
            using (var context = new Destiny2DataContext())
            {
                return context.WeaponTypes.Include(w => w.ReloadStats).ToList();
            }
        }

        public WeaponType GetWeaponType(int id)
        {
            using (var context = new Destiny2DataContext())
            {
                var weaponType = context.WeaponTypes
                .Include(w => w.ReloadStats)
                .Where(w => w.Id == id)
                .FirstOrDefault();

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
