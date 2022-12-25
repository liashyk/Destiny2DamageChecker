using DamageChecker.Data;
using DamageChecker.Services.Data;
using Destiny2DataLibrary.Models;
using Microsoft.AspNetCore.Components;

namespace DamageChecker.Components
{
    partial class AddBuffs
    {
        [Inject]
        public DestinyDataService dataService { get; set; }

        [Inject]
        private ILoggerFactory loggerFactory { get; set; }

        //Current ArchetypeId
        [CascadingParameter(Name = "ArchetypeId")]
        public int ArchetypeId { get; set; }

        //event that hapenns when apply button is clicked
        [Parameter]
        public EventCallback OnApplyCallback { get; set; }

        [CascadingParameter]
        public BuffSet Buffs { get; set; }

        private ILogger? logger;
        //All posible perks in current Archetype

        //private IEnumerable<Perk>? archetypePerks=new List<Perk>();

        private List<BuffSelector> buffSelectors=new List<BuffSelector>();

        #region style-fields
        private string query = "";

        private string addBuffHideStyle = "height: 0;";

        //Dictionary, where key is    buff_selectors_header and value is inner buff_list style
        private Dictionary<BuffSelector, string> buffSelectorsStyle = new Dictionary<BuffSelector, string>();

        private string hideSelectorStyle = "padding:0;";

        private string showSelectorStyle = "max-height: 100vh;";
        #endregion

        #region GetDataFromAPi
        private async Task<IEnumerable<IStackable>> GetPerksAsync(int archetypeId)
        {
            return await dataService.GetPerksFromArchetypeIdAsync(archetypeId);
        }

        private async Task<IEnumerable<IStackable>> GetDamageBuffsAsync()
        {
            return dataService.GetDamageBuffs();
        }

        #endregion

        public override async Task SetParametersAsync(ParameterView parameters)
        {
            object prevArchetypeId = ArchetypeId;
            object currentArchetypeId= parameters.ToDictionary()["ArchetypeId"];
            await base.SetParametersAsync(parameters);
            if (logger == null)
            {
                logger = loggerFactory.CreateLogger<AddBuffs>();
            }
            if (!prevArchetypeId.Equals(currentArchetypeId) || buffSelectors[0].Buffs.Count()==0)
            {
                await MakePerkSelector();
                await MakeBuffSelectors();
            }
        }

        private async Task MakePerkSelector()
        {
            buffSelectors[0].Buffs= await GetPerksAsync(ArchetypeId);
        }

        private async Task MakeBuffSelectors()
        {
            IEnumerable<DamageBuff>? damageBuffs = await GetDamageBuffsAsync() as IEnumerable<DamageBuff>;
            if (damageBuffs == null) return;
            buffSelectors[1].Buffs = damageBuffs.Where(b=>b.BuffCategory.Id==2);
            buffSelectors[2].Buffs = damageBuffs.Where(b => b.BuffCategory.Id == 1);
            buffSelectors[3].Buffs = damageBuffs.Where(b => b.BuffCategory.Id == 3);
        }

        protected override async Task OnInitializedAsync()
        {
            buffSelectors.Add(new BuffSelector(showSelectorStyle, "DAMAGE WEAPON PERKS"));
            buffSelectors.Add(new BuffSelector(showSelectorStyle, "EMPOWERING BUFFS"));
            buffSelectors.Add(new BuffSelector(showSelectorStyle, "GLOBAL DEBUFFS"));
            buffSelectors.Add(new BuffSelector(showSelectorStyle, "AMPLIFICATION MODIFIERS"));
            await base.OnInitializedAsync();
        }

        //Hide or show buff list in selector
        private void HideBuffList(BuffSelector selector)
        {
            if (selector.Style == hideSelectorStyle)
            {
                selector.Style = showSelectorStyle;
            }
            else
            {
                selector.Style = hideSelectorStyle;
            }

        }

        ///hide this component
        public void Hide()
        {
            addBuffHideStyle = "height: 0;";
        }

        //Add perk to Transfer if it have been already added. Otherwise delete this perk;
        private void ClickBuff(IStackable buff)
        {
            if (Buffs.HaveBuff(buff))
            {
                logger.LogInformation($"Buff {buff.Id} deletion: " + Buffs.RemoveBuff(buff).ToString());
            }
            else
            {
                Buffs.AddBuff(buff);
            }
        }

        ///show this component
        public void Show()
        {
            Console.WriteLine("perks in ADD BUFFS:");
            foreach (IStackable perk in Buffs.GetBuffList())
            {
                Console.WriteLine(perk.Id);
            }
            addBuffHideStyle = "";
        }

        private class BuffSelector
        {
            public BuffSelector(string style, string header)
            {
                Style = style;
                Header = header;
            }
            public string Style { get; set; }
            public string Header { get; set; }
            public IEnumerable<IStackable> Buffs { get; set; } =new List<IStackable>();
        }
    }
}
