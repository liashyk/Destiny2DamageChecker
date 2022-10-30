using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destiny2DataLibrary.Models
{
    public class Archetype
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RoundsPerMinute { get; set; }
        public int BulletDamage { get; set; }
        public ICollection<Perk> Perks { get; set; }=new HashSet<Perk>();  
    }
}
