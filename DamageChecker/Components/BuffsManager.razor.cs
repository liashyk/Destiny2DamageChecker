using DamageChecker.Data;
using Destiny2DataLibrary.Models;
using Microsoft.AspNetCore.Components;
using System.Collections;
namespace DamageChecker.Components
{
    partial class BuffsManager
    {
        [Inject]
        private HttpClient client { get; set; }

        [Inject]
        private ILoggerFactory loggerFactory { get; set; }

        private ILogger? logger;

        [Inject]
        public IBuffTransfer Buffs { get; set; }

        AddBuffs? addBuffs;

        public List<Perk>? ActivePerks { get; set; } = new List<Perk>();

        public List<DamageBuff>? ActiveBuffs { get; set; } = new List<DamageBuff>();


        protected override Task OnParametersSetAsync()
        {
            Buffs.ClearAll();
            logger=loggerFactory.CreateLogger<BuffTransfer>();
            return base.OnParametersSetAsync();
        }

        protected override Task OnAfterRenderAsync(bool firstRender)
        {
            addBuffs.Buffs = Buffs;
            return base.OnAfterRenderAsync(firstRender);
        }

    }

}
