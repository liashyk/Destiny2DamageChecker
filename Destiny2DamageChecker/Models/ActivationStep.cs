using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destiny2DataLibrary.Models
{
    public class ActivationStep
    {
        public int Id { get; set; }
        public Perk Perk { get; set; }
        public int StepNumber { get; set; }
        public int DamageBuffPercent { get; set; }
    }
}
