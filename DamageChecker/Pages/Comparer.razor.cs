using Blazored.LocalStorage;
using DamageChecker.Components;
using DamageChecker.Services;
using Microsoft.AspNetCore.Components;

namespace DamageChecker.Pages
{
	public partial class Comparer
	{
		[Inject]
		public ArchetypeContainer Container { get; set; }

		public IEnumerable<ContainerUnit> GetContainerUnits()
		{
			return Container.GetPages();
		}

		[Inject]
		private ILocalStorageService localStorage { get; set; }
	}
}
