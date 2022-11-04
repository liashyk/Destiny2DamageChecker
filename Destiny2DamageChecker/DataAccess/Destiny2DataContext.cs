using Microsoft.EntityFrameworkCore;
using Destiny2DataLibrary.Models;

namespace Destiny2DataLibrary.DataAccess
{
    public class Destiny2DataContext:DbContext
    {
        public Destiny2DataContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Destiny2DataBase;Username=postgres;Password=10524");
        }
        public DbSet<Perk> Perks { get; set; }
        public DbSet<Archetype> Archetypes { get; set; }
        public DbSet<ActivationStep> ActivationSteps { get; set; }
        public DbSet<WeaponType> WeaponTypes { get; set; }
        public DbSet<ShotDamage> ShotsDamage { get; set; }
        public DbSet<AmmoType> AmmoTypes { get; set; }
        public DbSet<BurstStats> BurstStats { get; set; }
    }
}
