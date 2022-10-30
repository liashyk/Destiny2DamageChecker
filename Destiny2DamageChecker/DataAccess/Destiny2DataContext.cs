using Microsoft.EntityFrameworkCore;
using Destiny2DataLibrary.Models;

namespace Destiny2DataLibrary.DataAccess
{
    public class Destiny2DataContext:DbContext
    {
        public Destiny2DataContext(DbContextOptions options) : base(options) { }
        public DbSet<Perk> Perks { get; set; }
        public DbSet<Archetype> Archetypes { get; set; }
        public DbSet<ActivationStep> ActivationSteps { get; set; }
    }
}
