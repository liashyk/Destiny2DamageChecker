using DamageChecker.Services;
using Microsoft.AspNetCore.Components;

namespace DamageChecker.Components
{
	partial class DamageMenu
	{
		[Inject]
		public DamageService DamageService { get; set; }

	}
}
