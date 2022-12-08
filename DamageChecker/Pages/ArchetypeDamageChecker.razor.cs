using DamageChecker.Components;
using DamageChecker.Shared;
using Destiny2DataLibrary.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Headers;

namespace DamageChecker.Pages
{
    public partial class ArchetypeDamageChecker
    {

        [Inject]
        private HttpClient client { get; set; }

        [Inject]
        private ILoggerFactory? loggerFactory { get; set; }

        public Archetype CurrentArchetype { get; set; } = new Archetype();

        private ILogger logger { get; set; }

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
                throw new Exception($"Weapon {ArchetypeId} WAS NOT received");
            }
        }

        private string imgLink;

        protected override async Task OnParametersSetAsync()
        {
            if (buffsManager != null)
            {
                CombinedBuff = buffsManager.combinedBuff;
            }
            Buffs.ClearAll();
            logger = loggerFactory.CreateLogger<NavMenu>();
            await GetArhetypeByIdASync();
            CurrentArchetype.Name = CurrentArchetype.Name.ToUpper();
            imgLink = $"css/icons/WeaponTypes/{CurrentArchetype.WeaponType.Name}.svg";
            await base.OnParametersSetAsync();
        }
    }
}
