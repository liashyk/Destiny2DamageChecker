﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destiny2DataLibrary.Models
{
    public class DamageBuff : IStackable
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public string? Summary { get; set; }
        public BuffCategory BuffCategory { get; set; }
        public int? BuffStacksAmount { get; set; }
        public ICollection<BuffStack>? BuffStacks { get; set; }
    }
}
