﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destiny2DataLibrary.Models
{
    public class Archetype
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public WeaponType WeaponType { get; set; }
        public ShotDamage ShotDamage { get; set; }
        public double RoundsPerMinute { get; set; }
        public AmmoType? AmmoType { get; set; }
        public double FramesBetweenShots { get; set; }
        public bool IsBurst { get; set; }
        public BurstStats? BurstStats { get; set; }
        public ICollection<Perk>? Perks { get; set; }
	}
}
