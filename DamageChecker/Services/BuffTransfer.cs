using Destiny2DataLibrary.Models;
using System;

namespace DamageChecker.Data
{
    public class BuffTransfer: IBuffTransfer
    {
        public BuffTransfer()
        {
            _perks= new HashSet<Perk>();
            _damageBuffs=new HashSet<DamageBuff>();
        }

        private HashSet<Perk> _perks;
        private HashSet<DamageBuff> _damageBuffs;

        public bool AddBuff(DamageBuff buff)
        {
            throw new NotImplementedException();
        }

        public bool AddPerk(Perk perk)
        {
            if (_perks.Any(p => p.Id == perk.Id))
            {
                return false;
            }
            else
            {
                _perks.Add(perk);
                return true;
            }
        }

        public IEnumerable<Perk> GetPerkList()
        {
            return _perks.ToArray();
        }

        public bool HavePerk(int perkId)
        {
            return _perks.Any(p => p.Id == perkId);
        }

        public bool RemoveBuff(int buffId)
        {
            throw new NotImplementedException();
        }

        public bool RemovePerk(int perkId)
        {
            return _perks.RemoveWhere(p => p.Id == perkId) > 0;
        }

        public void ClearAll()
        {
            _perks.Clear();
            _damageBuffs.Clear();
        }
    }
}
