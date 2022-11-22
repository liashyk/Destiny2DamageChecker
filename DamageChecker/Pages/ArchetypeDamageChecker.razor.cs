using DamageChecker.Components;
using Destiny2DataLibrary.Models;
using Microsoft.AspNetCore.Components;

namespace DamageChecker.Pages
{
    public partial class ArchetypeDamageChecker
    {
        private string bottomBarStyle = "";

        AddBuffs? addBuffs;

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

        [Parameter]
        public Archetype? CurrentArchetype { get; set; }
    }
}
