using DamageChecker.Data;
using DamageChecker.Services;
using Destiny2DataLibrary.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
namespace DamageChecker.Components
{
	partial class BuffsManager
	{
		//current archetype id 
		[CascadingParameter(Name = "ArchetypeId")]
		public int ArchetypeId { get; set; }

		//add buffs menu
		private string bottomBarStyle = "";

		private void HideAddBuffs()
		{
			if (addBuffs != null)
			{
				addBuffs.Hide();
			}
			OnChangeBuffs.InvokeAsync();
		}

		//Invokes while add,remove buffs or change stack of buffs
		[Parameter]
		public EventCallback OnChangeBuffs { get; set; }

		private void ChangeStack(IStackable buff, Object value)
		{
			int stackValue = int.Parse(value.ToString());
			Buffs.BuffStacks[buff] = stackValue;
			OnChangeBuffs.InvokeAsync();
		}

		//current combined buff of all applied buffs. 
		public CombinedBuff combinedBuff
		{
			get
			{
				return Buffs.GetCombinedBuff();
			}
		}

		private void ShowAddBuffs()
		{
			Console.WriteLine("perks in BUFFS MANAGER:");
			foreach (IStackable perk in Buffs.GetBuffList())
			{
				Console.WriteLine(perk.Id);
			}
			if (addBuffs != null)
			{
				addBuffs.Show();
			}
		}

		private void OnPerkOver(MouseEventArgs e, IStackable buff)
		{
			var args = new ShowPerkSummaryArgs()
			{
				PageX = e.PageX,
				PageY = e.PageY,
				Buff = buff
			};
			OnShowPerkSummary.InvokeAsync(args);
		}

		//call when perk summary will be hided
		[Parameter]
		public EventCallback OnHidePerkSummary { get; set; }

		//call when perk summary will be shown
		[Parameter]
		public EventCallback<ShowPerkSummaryArgs> OnShowPerkSummary { get; set; }

		[Inject]
		private ILoggerFactory loggerFactory { get; set; }

		private ILogger? logger;

		//Contain Active buffs
		[CascadingParameter]
		public BuffSet Buffs { get; set; }

		//AddBuff component
		AddBuffs? addBuffs;

		protected override Task OnParametersSetAsync()
		{
			logger = loggerFactory.CreateLogger<BuffSet>();
			return base.OnParametersSetAsync();
		}
	}
}
