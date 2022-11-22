using Destiny2DataLibrary.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Headers;

namespace DamageChecker.Shared
{
    public partial class NavMenu
    {
        [Inject]
        private HttpClient client { get; set; }

        [Inject]
        private ILoggerFactory loggerFactory { get; set; }

        private ILogger logger { get; set; }

        private IEnumerable<WeaponType> weaponTypes= new List<WeaponType>();

        public Archetype? CurrentArchetype { get; set; } = null;

        private IEnumerable<Archetype> WeaponTypeArchetypes = new List<Archetype>();

        private async Task GetWeaponTypesAsync()
        {
            var responce = await client.GetAsync("api/WeaponTypes");
            if (responce.IsSuccessStatusCode)
            {
                weaponTypes = await responce.Content.ReadFromJsonAsync<IEnumerable<WeaponType>>();
                logger.LogInformation("Weapons was received");
            }
            else
            {
                logger.LogCritical("Weapons WAS NOT received");
            }
        }

        private async Task ShowArchetypes(int id)
        {
            var responce = await client.GetAsync($"api/Archetypes/FromWeaponType/{id}");
            if (responce.IsSuccessStatusCode)
            {
                WeaponTypeArchetypes= await responce.Content.ReadFromJsonAsync<IEnumerable<Archetype>>();
                logger.LogInformation($"Archetypos from weapon type : {id} was received");
            }else logger.LogCritical($"Archetypos from weapon type : {id} was NOT received!");
            if (archetypeDisplayParam == "width:0")
            {
                archetypeDisplayParam = "";
            }
        }


        protected override async Task OnInitializedAsync()
        {
            logger = loggerFactory.CreateLogger<NavMenu>();
            client.BaseAddress = new Uri("https://localhost:7208/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            await GetWeaponTypesAsync();
        }


    }
}
