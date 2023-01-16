using DamageChecker.Services.Data;
using Destiny2DataLibrary.Models;

namespace DamageChecker.Services
{
    public class SearchService
    {
        //contain string key of each archetype.
        //Key template: {weapon type} {archetype} {rpm}

        private Dictionary<string, Archetype> _archetypeDictionary;
        private IEnumerable<Perk> perks;
        private Dictionary<string, DamageBuff> _buffDictionary;

        public SearchService()
        {
            DestinyDataService dataService = new DestinyDataService();
            List<IStackable> stackableList = new List<IStackable>();
            _archetypeDictionary = MakeArchetypeDictionary(dataService.GetArchetypes());
            //_perkDictionary = MakePerkDictionary(dataService.GetPerks());
            perks=dataService.GetPerks();
            _buffDictionary = MakeBuffDictionary(dataService.GetDamageBuffs());
        }

        private Dictionary<string, Perk> MakePerkDictionary(IEnumerable<Perk> perks)
        {
            var perkDictionary= new Dictionary<string, Perk>();
            if (perks == null) return perkDictionary;
            foreach (Perk perk in perks)
            {
                perkDictionary.Add(perk.Name, perk);
            }
            return perkDictionary;
        }

        private Dictionary<string, DamageBuff> MakeBuffDictionary(IEnumerable<DamageBuff> buffs)
        {
            var buffsDictionary = new Dictionary<string, DamageBuff>();
            if (buffs == null) return buffsDictionary;
            foreach (DamageBuff buff in buffs)
            {
                buffsDictionary.Add(buff.Name, buff);
            }
            return buffsDictionary;
        }

        private Dictionary<string, Archetype> MakeArchetypeDictionary(IEnumerable<Archetype> archetypes)
        {
            Dictionary<string, Archetype> archetypeDictionary = new Dictionary<string, Archetype>();
            foreach (Archetype archetype in archetypes)
            {
                string query =$"{archetype.WeaponType.Name} {archetype.Name} {archetype.RoundsPerMinute}";
                archetypeDictionary.Add(query,archetype);
            }
            return archetypeDictionary;
        }

        public IEnumerable<Archetype> FindArchetypes(string userQuery)
        {
            List<Archetype> result = new List<Archetype>();
            foreach(string key in _archetypeDictionary.Keys) 
            {
                if (KeyIsContain(key,userQuery))
                {
                    result.Add(_archetypeDictionary[key]);
                }
            }
            return result;
        }

        public IEnumerable<IStackable> FindStackables(string userQuery,int archetypeId)
        {
            List<IStackable> result = new List<IStackable>();
            foreach (Perk perk in perks)
            {
                if (KeyIsContain(perk.Name, userQuery))
                {
                    if (perk.Archetypes.Any(a => a.Id == archetypeId))
                    {
                        result.Add(perk);
                    }
                }
            }
            foreach (string key in _buffDictionary.Keys)
            {
                if (KeyIsContain(key, userQuery))
                {
                    result.Add(_buffDictionary[key]);
                }
            }
            return result;
        }


        /// <summary>
        /// Return true if key contains words in query
        /// </summary>
        /// <param name="key"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        private bool KeyIsContain(string key,string query)
        {
            key= key.ToLower();
            query= query.ToLower();
            string[] queryWords=query.Split(' ');
            string[] keyWords = key.Split(' ');
            foreach (string word in queryWords) 
            {
                if (!keyWords.Any(keyWord => keyWord.StartsWith(word)))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
