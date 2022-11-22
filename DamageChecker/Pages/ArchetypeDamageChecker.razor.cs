using DamageChecker.Components;
using DamageChecker.Shared;
using Destiny2DataLibrary.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Headers;

namespace DamageChecker.Pages
{
    public partial class ArchetypeDamageChecker
    {

        private string bottomBarStyle = "";

        AddBuffs? addBuffs;

        [Inject]
        private HttpClient client { get; set; }

        [Inject]
        private ILoggerFactory? loggerFactory { get; set; }

        public Archetype CurrentArchetype { get; set; } = new Archetype();

        private ILogger logger { get; set; }

        private void HideAddBuffs()
        {
            if (addBuffs == null) return;
            addBuffs.Hide();
        }

        private void ShowAddBuffs()
        {
            if (addBuffs == null) return;
            addBuffs.Show();
        }
        private async Task GetArhetypeByIdASync()
        {
            var responce = await client.GetAsync($"api/Archetypes/{ArchetypeId}");
            if (responce.IsSuccessStatusCode)
            {
                CurrentArchetype = await responce.Content.ReadFromJsonAsync<Archetype>();
                logger.LogInformation("Weapons was received");
            }
            else
            {
                logger.LogCritical("Weapons WAS NOT received");
            }
        }

        private string imgLink;

        protected override async Task OnParametersSetAsync()
        {
            logger = loggerFactory.CreateLogger<NavMenu>();
            await GetArhetypeByIdASync();
            CurrentArchetype.Name = CurrentArchetype.Name.ToUpper();
            imgLink = $"css/icons/WeaponTypes/{CurrentArchetype.WeaponType.Name}.svg";
            await base.OnParametersSetAsync();
        }
    }
}
