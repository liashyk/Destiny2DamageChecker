using Blazored.LocalStorage;
using DamageChecker.Components;
using DamageChecker.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Text.Json;

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
	}
}
