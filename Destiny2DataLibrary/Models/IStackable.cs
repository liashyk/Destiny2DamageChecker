using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destiny2DataLibrary.Models
{
	public class IStackable
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Summary { get; set; }
        public int? ActivationStepsAmount { get; set; }
        public ICollection<BuffStack>? ActivationSteps { get; set; }
    }
}
