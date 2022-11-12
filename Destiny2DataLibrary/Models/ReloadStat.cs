using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Destiny2DataLibrary.Models
{
    public class ReloadStat
    {
        public int Id { get; set; }
        public double a { get; set; }
        public double b { get; set; }
        public double c { get; set; }
    }
}