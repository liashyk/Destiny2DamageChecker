using Destiny2DataLibrary.Models;

namespace DamageChecker.Data
{
    //contain activated perks and buff
    public interface IBuffTransfer
    {
        //Add buff to transfer
        public bool AddBuff(DamageBuff buff);
        public bool RemoveBuff(int buffId);
        //Add buff to transfer
        public bool AddPerk(Perk perk);
        public bool RemovePerk(int perkId);
        public bool HavePerk(int perkId);
        public IEnumerable<Perk> GetPerkList();

        public void ClearAll();
    }
}