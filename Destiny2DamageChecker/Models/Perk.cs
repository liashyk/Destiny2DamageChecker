using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Destiny2DataLibrary.Models
{
    public class Perk
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string? Summary { get; set; }
        public int ActivationStepsAmount { get; set; }
        public ICollection<ActivationStep> ActivationSteps{ get; set;}=new HashSet<ActivationStep>();
        public ICollection<Archetype> Archetypes { get; set; } = new HashSet<Archetype>();
    }
}