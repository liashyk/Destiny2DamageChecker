using Destiny2DataLibrary.Models;

namespace DamageChecker.Data
{
    public class Destiny2DataService : IDestiny2DataService
    {
        public Task<IEnumerable<Archetype>> GetArchetypesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Perk>> GetPerksAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<WeaponType>> GetWeaponTypesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
