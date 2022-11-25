using Destiny2DataLibrary.Models;
using Microsoft.AspNetCore.Components;

namespace DamageChecker.Components
{
    partial class AddBuffs
    {
        [Inject]
        public HttpClient client { get; set; }

        [Inject]
        private ILoggerFactory loggerFactory { get; set; }

        private ILogger? logger;

        private IEnumerable<Perk>? archetypePerks=new List<Perk>();

        private async Task GetPerksAsync(int archetypeId)
        {
            var responce = await client.GetAsync($"api/Perks/FromArchetype/{archetypeId}");
            if (responce.IsSuccessStatusCode)
            {
                archetypePerks = await responce.Content.ReadFromJsonAsync<IEnumerable<Perk>>();
                logger.LogInformation("Perks was received");
            }
            else
            {
                logger.LogCritical("Perks WAS NOT received");
            }
        }

        [Parameter]
        public int ArchetypeID { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            await GetPerksAsync(ArchetypeID);
            await base.OnParametersSetAsync();
        }

        protected async override Task OnInitializedAsync()
        {
            if (logger == null)
            {
                logger = loggerFactory.CreateLogger<AddBuffs>();
            }
            await base.OnInitializedAsync();
        }

        public override Task SetParametersAsync(ParameterView parameters)
        {
            return base.SetParametersAsync(parameters);
        }
    }
}
