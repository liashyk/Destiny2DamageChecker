using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destiny2DataLibrary.Models
{
	public interface IStackable
	{
        int Id { get; set; }
        string Name { get; set; }
        string? Summary { get; set; }
        int? BuffStacksAmount { get; set; }
        ICollection<BuffStack>? BuffStacks { get; set; }
    }
}
