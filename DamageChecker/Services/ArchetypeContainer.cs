using DamageChecker.Data;
using DamageChecker.Pages;
using Destiny2DataLibrary.Models;

namespace DamageChecker.Services
{
	public class ArchetypeContainer
	{

		private List<ContainerUnit> units;
		public ArchetypeContainer() 
		{
			units = new List<ContainerUnit>();
		}

		public void AddPage(Archetype archetype, BuffSet buffSet)
		{
			units.Add(new ContainerUnit(archetype, buffSet ));
		}

		public IEnumerable<ContainerUnit> GetPages()
		{
			return units;
		}

		public void DeleteUnit(ContainerUnit containerUnit)
		{
			units.Remove(containerUnit);
		}

		public bool HasUnit(ContainerUnit containerUnit)
		{
			foreach(var unit in units)
			{
				if (unit == containerUnit)
				{
					return true ;
				}
			}
			return false;
		}
	}

	public class ContainerUnit
	{
		public ContainerUnit(Archetype archetype, BuffSet buffSet) 
		{
			this.Archetype = archetype;
			this.BuffSet = buffSet;
		}
		public Archetype Archetype { get; set; }
		public BuffSet BuffSet { get; set; }

	}
}
