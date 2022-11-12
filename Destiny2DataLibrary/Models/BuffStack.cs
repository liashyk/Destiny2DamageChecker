using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destiny2DataLibrary.Models
{
    public class BuffStack
    {
        public int Id { get; set; }
        public int StepNumber { get; set; }
        public double PvpDamageBuffPercent { get; set; }
        public double PveDamageBuffPercent { get; set; }
        public double PvpRapidFireBuffPercent { get; set; }
        public double PveRapidFirePercent { get; set; }
        public ReloadStat? ReloadStat { get; set; }
    }
}
