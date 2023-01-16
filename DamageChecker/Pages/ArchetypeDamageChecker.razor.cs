using DamageChecker.Components;
using DamageChecker.Data;
using DamageChecker.Services;
using DamageChecker.Services.Data;
using DamageChecker.Shared;
using Destiny2DataLibrary.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Headers;

namespace DamageChecker.Pages
{
    public partial class ArchetypeDamageChecker
    {

        [Inject]
        private DestinyDataService dataService { get; set; }

        public Archetype CurrentArchetype { get; set; } = new Archetype();

        //link on archetype img
        private string? imgLink;

        private async Task GetArhetypeByIdASync()
        {
            var archetypeBuffer = await dataService.GetArchetypeAsync(ArchetypeId);
            if(archetypeBuffer == null)
            {
                throw new Exception("There isn't archetypes with that Id");
            }else
            {
                CurrentArchetype = archetypeBuffer;
            }   
        }

        protected override async Task OnParametersSetAsync()
        {
            if (buffsManager != null)
            {
                CombinedBuff = buffsManager.combinedBuff;
            }
            Buffs.ClearAll();
            await GetArhetypeByIdASync();
            CurrentArchetype.Name = CurrentArchetype.Name.ToUpper();
            imgLink = $"css/icons/WeaponTypes/{CurrentArchetype.WeaponType.Name}.svg";
            await base.OnParametersSetAsync();
        }

		[Parameter]
		public int ArchetypeId { get; set; }

		[Inject]
		BuffSet Buffs { get; set; }

		BuffsManager? buffsManager;

		private readonly int _offsetTop = -60;
		private readonly int _offsetleft = 20;

		public CombinedBuff? CombinedBuff
		{
			get; set;
		}

		private ShowPerkSummaryArgs? _currentArgs;

		private string _perkSummaryVisibility = "";

		private void ChangeBuffHandle()
		{
			CombinedBuff = buffsManager.combinedBuff;
		}

		private void HidePerkSummary()
		{
			_perkSummaryVisibility = "hidden";
		}

		private void ShowPerkSummary(ShowPerkSummaryArgs args)
		{
			_perkSummaryVisibility = "";
			_currentArgs = args;
		}
	}
}
