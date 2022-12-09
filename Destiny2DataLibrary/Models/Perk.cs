using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Destiny2DataLibrary.Models
{
    public class Perk : IStackable
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; } = "";
        public string? Summary { get; set; }
        public int? BuffStacksAmount { get; set; }
        public bool IsAdvanced { get; set; }
        public ICollection<Archetype>? Archetypes { get; set; }
        public ICollection<BuffStack>? BuffStacks { get; set; }
    }
}