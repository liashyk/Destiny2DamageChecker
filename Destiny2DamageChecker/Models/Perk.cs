using Microsoft.EntityFrameworkCore;

namespace Destiny2DataLibrary.Models
{
    public class Perk
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string? Summary { get; set; }
        public int ActivationStepsAmount { get; set; }
        public int MyProperty { get; set; }

        public ICollection<Archetype> Archetypes { get; set; }
        
    }
}