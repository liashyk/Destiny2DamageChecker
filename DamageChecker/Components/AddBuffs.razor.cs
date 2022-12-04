using DamageChecker.Data;
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
        //All posible perks in current Archetype

        private IEnumerable<Perk>? archetypePerks=new List<Perk>();

        //Current ArchetypeId
        [CascadingParameter(Name = "ArchetypeId")]
        public int ArchetypeId { get; set; }


        //event that hapenns when apply button is clicked
        [Parameter]
        public EventCallback OnApplyCallback { get; set; }

        [CascadingParameter]
        public BuffSet Buffs { get; set; }

        #region style-fields
        private string query = "";

        private string addBuffHideStyle = "height: 0;";

        //Dictionary, where key is    buff_selectors_header and value is inner buff_list style
        private Dictionary<string, string> buff_selectors_style = new Dictionary<string, string>();

        private string hideSelectorStyle = "padding:0;";

        private string showSelectorStyle = "max-height: 100vh;";
        #endregion

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
                logger.LogCritical($"Perks from {archetypeId} WAS NOT received");
            }
        }


        protected override async Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();
        }


        public override async Task SetParametersAsync(ParameterView parameters)
        {
            object prevArchetypeId = ArchetypeId;
            object currentArchetypeId= parameters.ToDictionary()["ArchetypeId"];
            await base.SetParametersAsync(parameters);
            if (logger == null)
            {
                logger = loggerFactory.CreateLogger<AddBuffs>();
            }
            if (!prevArchetypeId.Equals(currentArchetypeId))
            {
                await GetPerksAsync(ArchetypeId);
            }
        }
        protected async override Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            buff_selectors_style["DAMAGE WEAPON PERKS"] = showSelectorStyle;
            //buff_selectors_style["EMPOWERING BUFFS"] = showSelectorStyle;
            //buff_selectors_style["GLOBAL DEBUFS"] = showSelectorStyle;
        }

        //Hide or show buff list in selector
        private void HideBuffList(string selectorName)
        {
            if (buff_selectors_style[selectorName] == hideSelectorStyle)
            {
                buff_selectors_style[selectorName] = showSelectorStyle;
            }
            else
            {
                buff_selectors_style[selectorName] = hideSelectorStyle;
            }

        }

        ///hide this component
        public void Hide()
        {
            addBuffHideStyle = "height: 0;";
        }

        //Add perk to Transfer if it have been already added. Otherwise delete this perk;
        private void ClickPerk(Perk perk)
        {
            if (Buffs.HaveBuff(perk))
            {
                logger.LogInformation($"Perk {perk.Id} deletion: " + Buffs.RemoveBuff(perk).ToString());
            }
            else
            {
                Buffs.AddBuff(perk);
            }
        }

        ///show this component
        public void Show()
        {
            Console.WriteLine("perks in ADD BUFFS:");
            foreach (Perk perk in Buffs.GetPerkList())
            {
                Console.WriteLine(perk.Id);
            }
            addBuffHideStyle = "";
        }
    }
}
