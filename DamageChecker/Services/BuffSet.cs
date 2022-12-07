using DamageChecker.Services;
using Destiny2DataLibrary.Models;
using System;
using System.Collections.Generic;

namespace DamageChecker.Data
{
    public class BuffSet
    {

        //Key is Perk id and Value is stack number>
        public Dictionary<IStackable, int> BuffStacks { get; set; }

        private HashSet<IStackable> _perks;
        private HashSet<IStackable> _damageBuffs;

        public BuffSet()
        {
            _perks= new HashSet<IStackable>();
            _damageBuffs=new HashSet<IStackable>();
            BuffStacks = new Dictionary<IStackable, int>();
        }



        public bool AddBuff(DamageBuff buff)
        {
            throw new NotImplementedException();
        }

        public bool AddBuff(IStackable buff)
        {
            var collection = _damageBuffs;
            if(buff is Perk)
            {
                collection = _perks;
            }
            if (collection.Any(p => p.Id == buff.Id))
            {
                return false;
            }
            else
            {
                collection.Add(buff);
                BuffStacks.Add(buff, 1);
                return true;
            }
        }

        public IEnumerable<IStackable> GetBuffList()
        {
            return _perks.Concat(_damageBuffs);
        }

        public bool HaveBuff(IStackable buff)
        {
            if(buff is Perk)
            {
                return _perks.Any(p => p.Id == buff.Id);
            }
            return _damageBuffs.Any(b => b.Id == buff.Id);

        }

        public bool RemoveBuff(IStackable buff)
        {
            BuffStacks.Remove(buff);
            if (buff is Perk)
            {
                return _perks.Remove(buff);
            }
            else
            {
                return _damageBuffs.Remove(buff);
            }
        }

        public void ClearAll()
        {
            _perks.Clear();
            _damageBuffs.Clear();
            BuffStacks.Clear();
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
                foreach (IStackable buff in BuffStacks.Keys)
                {
                    if (buff != null)
                    {
                        combinedBuff.PveDamageBuffPercent *= (1 + GetPerksBuff(buff).PveDamageBuffPercent / 100);
                        combinedBuff.PvpDamageBuffPercent *= (1 + GetPerksBuff(buff).PvpDamageBuffPercent / 100);
                        combinedBuff.PvpRapidFireBuffPercent *= (1 + GetPerksBuff(buff).PvpRapidFireBuffPercent / 100);
                        combinedBuff.PveRapidFirePercent *= (1 + GetPerksBuff(buff).PveRapidFirePercent / 100);
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

        public bool SetPerkStack(IStackable buff, int stack)
        {
            if(stack>0 && buff.ActivationSteps!=null && stack<= buff.ActivationSteps.Count && BuffStacks.ContainsKey(buff))
            {
                BuffStacks[buff] = stack;
                return true;
            }else return false;
        }

        public BuffStack? GetPerksBuff(IStackable buff)
        {
            if (buff != null && buff.ActivationSteps != null)
            {
                return buff.ActivationSteps.Where(s => s.StepNumber == BuffStacks[buff]).SingleOrDefault();
            }
            else return null;
        }
    }
}
