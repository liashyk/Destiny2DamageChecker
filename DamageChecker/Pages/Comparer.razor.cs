using DamageChecker.Services;
using Microsoft.AspNetCore.Components;

namespace DamageChecker.Pages
{
	public partial class Comparer
	{
		[Inject]
		public ArchetypeContainer Container { get; set; }

		public IEnumerable<ArchetypeDamageChecker> GetArchetypes()
		{
			return Container.GetPages();
		}

	}
}
