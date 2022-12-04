using DamageChecker.Data;
using DamageChecker.Services;
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

        //Contain Active buffs
        [CascadingParameter]
        public BuffSet Buffs { get; set; }

        //AddBuff component
        AddBuffs? addBuffs;

        protected override Task OnParametersSetAsync()
        {
            logger=loggerFactory.CreateLogger<BuffSet>();
            return base.OnParametersSetAsync();
        }

        protected override Task OnAfterRenderAsync(bool firstRender)
        {
            //addBuffs.Buffs = Buffs;
            return base.OnAfterRenderAsync(firstRender);
        }

        private void ShowPerkSummary(ShowPerkSummaryArgs args)
        {
            //Console.WriteLine($"x: {args.PageX} y: {args.PageY} perk: {args.Perk.Name}");
        }

    }

}
