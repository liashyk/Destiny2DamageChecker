using DamageChecker.Data;
using DamageChecker.Services;
using DamageChecker.Services.Data;
using Destiny2DataLibrary.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace DamageChecker.Components
{
    partial class AddBuffs
    {
		//search suggest menu's classes values
		private string hiddenSearchSuggestMenu = "search-suggest-menu-hidden";
		private string showSearchSuggestMenu = "search-suggest-menu";

        //default search suggest menu class value
		private string searchSuggestMenuClass = "search-suggest-menu-hidden";

        //buffs that suggested in search field
		private IEnumerable<IStackable> suggestedBuffs = new IStackable[0];

		private void HideSuggestMenu()
        {
            searchSuggestMenuClass = hiddenSearchSuggestMenu;
        }

        //Data service
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

        //Set of current damage buffs and perks
        [CascadingParameter]
        public BuffSet Buffs { get; set; }

        private ILogger? logger;

        //Collection of buff selectors in addbuffs menu
        private List<BuffSelector> buffSelectors=new List<BuffSelector>();

		private string query = "";

		[Inject]
		public SearchService SearchService { get; set; }

		[Parameter]
		public EventCallback OnHidePerkSummary { get; set; }

		//Show perk summary
		[Parameter]
		public EventCallback<ShowPerkSummaryArgs> OnShowPerkSummary { get; set; }

		#region style-fields
		//style of hided add buffs menu
		private string addBuffHideStyle = "height: 0;";

        //Dictionary, where key is    buff_selectors_header and value is inner buff_list style
        private Dictionary<BuffSelector, string> buffSelectorsStyle = new Dictionary<BuffSelector, string>();

		//style of hided selector
		private string hideSelectorStyle = "padding:0;";

		//style of not hided selector
		private string showSelectorStyle = "max-height: 100vh;";
        #endregion

        #region GetData
        private IEnumerable<IStackable> GetPerks(int archetypeId)
        {
            return dataService.GetPerksFromArchetypeId(archetypeId);
        }

        private  IEnumerable<IStackable> GetDamageBuffs()
        {
            return dataService.GetDamageBuffs();
        }

        #endregion

        public override async Task SetParametersAsync(ParameterView parameters)
        {
            //save previus and new archetypes' id
            object prevArchetypeId = ArchetypeId;
            object currentArchetypeId= parameters.ToDictionary()["ArchetypeId"];
            await base.SetParametersAsync(parameters);
            if (logger == null)
            {
                logger = loggerFactory.CreateLogger<AddBuffs>();
            }
			//if new archetype id is different or there aren't buff selectors - make them
			if (!prevArchetypeId.Equals(currentArchetypeId) || buffSelectors[0].Buffs.Count()==0)
            {
                MakePerkSelector();
                MakeBuffSelectors();
            }
        }

		/// <summary>
		/// make buff selector with perks
		/// </summary>
		private void MakePerkSelector()
        {
            buffSelectors[0].Buffs= GetPerks(ArchetypeId);
        }

		/// <summary>
		/// make buff selectors
		/// </summary>
		private void MakeBuffSelectors()
        {
            IEnumerable<DamageBuff>? damageBuffs = GetDamageBuffs() as IEnumerable<DamageBuff>;
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
                Buffs.RemoveBuff(buff);
                logger.LogInformation($"Buff {buff.Id} deletion.");
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

        /// <summary>
        /// Selector with buffs that can be hided
        /// </summary>
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

		private void OnPerkOver(MouseEventArgs e, IStackable buff)
		{
			var args = new ShowPerkSummaryArgs()
			{
				PageX = e.PageX,
				PageY = e.PageY,
				Buff = buff
			};
            //show perk summary
			OnShowPerkSummary.InvokeAsync(args);
		}

        //find buffs with query
		private void FindBuffs(string? query)
		{
			searchSuggestMenuClass = showSearchSuggestMenu;
			if (SearchService == null || query == null) return;
			var findedBuffs = SearchService.FindStackables(query, ArchetypeId);
			//cleand suggested buffs
			suggestedBuffs = new IStackable[0];
			if (findedBuffs.Count() == 0) return;
			suggestedBuffs = findedBuffs;
			Console.WriteLine(query);
		}
	}

}
