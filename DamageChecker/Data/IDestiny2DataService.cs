using Destiny2DataLibrary.Models;

namespace DamageChecker.Data
{
    public interface IDestiny2DataService
    {
        /// <summary>
        /// Return archetypes from database
        /// </summary>
        /// <returns> IEnumerable of Archetypes</returns>
        public Task<IEnumerable<Archetype>> GetArchetypesAsync();

        public Task<IEnumerable<Perk>> GetPerksAsync();
        public Task<IEnumerable<WeaponType>> GetWeaponTypesAsync();
    }
}