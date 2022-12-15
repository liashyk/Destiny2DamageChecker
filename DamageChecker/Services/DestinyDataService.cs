using Microsoft.AspNetCore.Mvc;
using Destiny2DataLibrary.DataAccess;
using Destiny2DataLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace DamageChecker.Services.Data
{
    public class DestinyDataService
    {
        private readonly Destiny2DataContext _context;
        public DestinyDataService()
        {
            _context = new Destiny2DataContext();
        }

        #region archetypes
        public async Task<IEnumerable<Archetype>> GetArchetypes()
        {
            List<Archetype> archetypes = GetArchetypesList();
            return archetypes;
        }

        private  List<Archetype> GetArchetypesList()
        {
            return _context.Archetypes.
                Include(a => a.WeaponType).
                Include(a => a.AmmoType).
                Include(a => a.WeaponType).
                Include(a => a.BurstStats).
                Include(a => a.ShotDamage).ToList();
        }

        private  Archetype GetArchetypeWithId(int id)
        {
            var archetypes = GetArchetypesList();
            Archetype archetype = archetypes.Where(a => a.Id == id).FirstOrDefault();
            var weaponTypeBuffer = _context.WeaponTypes
                .Include(w => w.ReloadStats)
                .Where(w => w.Id == archetype.WeaponType.Id)
                .FirstOrDefault();
            if (weaponTypeBuffer != null)
                archetype.WeaponType = weaponTypeBuffer;
            return archetype;
        }

        public async Task<Archetype> GetArchetype(int id)
        {
            var archetype = GetArchetypeWithId(id);
            return archetype;
        }

        public IEnumerable<Archetype> GetArchetypeWithWeaponTypeId(int weaponTypeId)
        {
            var archetypes = GetArchetypesList();
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
            return await _context.DamageBuffs
                .Include(b => b.BuffCategory)
                .Include(b => b.BuffStacks)
                .ToListAsync();
        }

        public async Task<DamageBuff> GetDamageBuff(int id)
        {
            var damageBuff = await
                _context.DamageBuffs
                .Include(_b => _b.BuffCategory)
                .Include(_b => _b.BuffStacks)
                .Where(b => b.Id == id)
                .SingleOrDefaultAsync();
            return damageBuff;
        }
        #endregion

        #region Perks
        public IEnumerable<Perk> GetPerks()
        {
            return _context.Perks.Include(p => p.BuffStacks).ToList();

        }

        public Perk GetPerk(int id)
        {
            Perk? perk = GetPerkByID(id);
            return perk;
        }

        public IEnumerable<Perk> GetPerksFromArchetypeId(int archetypeID)
        {
            Archetype? archetype = await _context.Archetypes.Include(a => a.Perks).
                Where(a => a.Id == archetypeID).FirstOrDefaultAsync();
            var archetypePerks = archetype.Perks.ToList();
            List<Perk> perks = await _context.Perks.Include(p => p.BuffStacks).ToListAsync();
            foreach (Perk it in archetypePerks)
            {
                var currentID = it.Id;
                perks.Add(GetPerkByID(currentID));
            }
            return await Task.WhenAll(perkTasks);
        }

        private Perk GetPerkByID(int perkId)
        {
            Perk? perk = _context.Perks.Include(p => p.BuffStacks)
                .Where(p => p.Id == perkId)
                .FirstOrDefault();
            return perk;
        }
        #endregion

        #region WeaponTypes

        public async Task<IEnumerable<WeaponType>> GetWeaponTypes()
        {
            return await _context.WeaponTypes.Include(w => w.ReloadStats).ToListAsync();
        }

        public async Task<WeaponType> GetWeaponType(int id)
        {
            var weaponType = await _context.WeaponTypes
                .Include(w => w.ReloadStats)
                .Where(w => w.Id == id)
                .FirstOrDefaultAsync();

            return weaponType;
        }

        private bool WeaponTypeExists(int id)
        {
            return _context.WeaponTypes.Any(e => e.Id == id);
        }
        #endregion
    }
}
