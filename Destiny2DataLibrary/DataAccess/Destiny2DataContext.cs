﻿using Destiny2DataLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace Destiny2DataLibrary.DataAccess
{
    public class Destiny2DataContext : DbContext
    {
        public Destiny2DataContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Destiny2DataBase;Username=postgres;Password=10524");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Perk> Perks { get; set; }
        public DbSet<Archetype> Archetypes { get; set; }
        public DbSet<BuffStack> BuffStacks { get; set; }
        public DbSet<WeaponType> WeaponTypes { get; set; }
        public DbSet<ShotDamage> ShotsDamage { get; set; }
        public DbSet<AmmoType> AmmoTypes { get; set; }
        public DbSet<BurstStats> BurstStats { get; set; }
        public DbSet<ReloadStat> ReloadStats { get; set; }
        public DbSet<BuffCategory> BuffCategories { get; set; }
        public DbSet<DamageBuff> DamageBuffs { get; set; }
    }
}
