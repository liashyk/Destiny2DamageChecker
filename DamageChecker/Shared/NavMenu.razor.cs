using DamageChecker.Services;
using DamageChecker.Services.Data;
using Destiny2DataLibrary.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using System.Net.Http.Headers;

namespace DamageChecker.Shared
{
    public partial class NavMenu
    {
        [Inject]
        private DestinyDataService dataService { get; set; }

        [Inject]
        private ILoggerFactory? loggerFactory { get; set; }

        [Inject]
        private SearchService? searchService { get; set; }

        private ILogger logger { get; set; }

        private IEnumerable<WeaponType> weaponTypes= new List<WeaponType>();

        public Archetype? CurrentArchetype { get; set; } = null;

        private IEnumerable<Archetype> WeaponTypeArchetypes = new List<Archetype>();

        private void GetWeaponTypes()
        {
            weaponTypes = dataService.GetWeaponTypes();
        }

        private async Task ShowArchetypes(int weaponTypeID)
        {
            WeaponTypeArchetypes= await dataService.GetArchetypeWithWeaponTypeId(weaponTypeID);
            if (archetypeDisplayParam == "width:0")
            {
                archetypeDisplayParam = "";
            }
        }


        protected override async Task OnInitializedAsync()
        {
            logger = loggerFactory.CreateLogger<NavMenu>();
            GetWeaponTypes();
        }

    }
}
