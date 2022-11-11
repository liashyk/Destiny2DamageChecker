using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destiny2DataLibrary.Models
{
    public class ShotDamage
    {
        public int Id { get; set; }
        public int? PveBulletDamage { get; set; }
        public int? PvePrecisionBulletDamage { get; set; }
        public int? PvpBulletDamage { get; set; }
        public int? PvpPrecisionBulletDamage { get; set; }
    }
}
