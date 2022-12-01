using DamageChecker.Services;
using Destiny2DataLibrary.Models;
using System;

namespace DamageChecker.Data
{
    public class BuffSet
    {

        //Key is Perk id and Value is stack number>
        public Dictionary<int, int> PerkStacks { get; set; }

        private HashSet<Perk> _perks;
        private HashSet<DamageBuff> _damageBuffs;

        public BuffSet()
        {
            _perks= new HashSet<Perk>();
            _damageBuffs=new HashSet<DamageBuff>();
            PerkStacks = new Dictionary<int, int>();
        }



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
                PerkStacks.Add(perk.Id, 1);
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
            Perk perk = _perks.FirstOrDefault(p => p.Id == perkId);
            PerkStacks.Remove(perkId);
            return _perks.Remove(perk);
        }

        public void ClearAll()
        {
            _perks.Clear();
            _damageBuffs.Clear();
            PerkStacks.Clear();
        }

        public CombinedBuff GetCombinedBuff()
        {
            CombinedBuff combinedBuff = new CombinedBuff()
            {
                PveRapidFirePercent = 1,
                PvpRapidFireBuffPercent = 1,
                PveDamageBuffPercent = 1,
                PvpDamageBuffPercent = 1,
            };
            try
            {
                foreach (int perkId in PerkStacks.Keys)
                {
                    Perk? currentPerk = GetPerk(perkId);
                    if (currentPerk != null)
                    {
                        combinedBuff.PveDamageBuffPercent *= (1 + GetPerksBuff(perkId).PveDamageBuffPercent / 100);
                        combinedBuff.PvpDamageBuffPercent *= (1 + GetPerksBuff(perkId).PvpDamageBuffPercent / 100);
                        combinedBuff.PvpRapidFireBuffPercent *= (1 + GetPerksBuff(perkId).PvpRapidFireBuffPercent / 100);
                        combinedBuff.PveRapidFirePercent *= (1 + GetPerksBuff(perkId).PveRapidFirePercent / 100);
                    }
                }
                combinedBuff.PveDamageBuffPercent = (combinedBuff.PveDamageBuffPercent - 1) * 100;
                combinedBuff.PvpDamageBuffPercent = (combinedBuff.PvpDamageBuffPercent - 1) * 100;
                combinedBuff.PvpRapidFireBuffPercent = (combinedBuff.PvpRapidFireBuffPercent - 1) * 100;
                combinedBuff.PveRapidFirePercent = (combinedBuff.PveRapidFirePercent - 1) * 100;
            }
            catch (Exception ex) 
            {
                throw new Exception("Wrong combined buff calculating!");
            }

            return combinedBuff;
        }

        public bool SetPerkStack(int perkId,int stack)
        {
            Perk perk = GetPerk(perkId);
            if(stack>0 && perk.ActivationSteps!=null && stack<=perk.ActivationSteps.Count && PerkStacks.ContainsKey(perkId))
            {
                PerkStacks[perkId] = stack;
                return true;
            }else return false;
        }

        public BuffStack? GetPerksBuff(int perkId)
        {
            Perk? perk=GetPerk(perkId);
            if (perk != null && perk.ActivationSteps != null)
            {
                return perk.ActivationSteps.Where(s => s.StepNumber == PerkStacks[perkId]).SingleOrDefault();
            }
            else return null;
        }
        private Perk? GetPerk(int perkId)
        {
            return _perks.Where(p => p.Id == perkId).FirstOrDefault();
        }
    }
}
