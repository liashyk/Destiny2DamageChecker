using Destiny2DataLibrary.Models;
using Microsoft.AspNetCore.Components.Web;

namespace DamageChecker.Services
{
    public class ShowPerkSummaryArgs
    {
        public IStackable Buff { get; set; }
        /// <summary>
        /// The X coordinate of the mouse pointer relative to the whole document.
        /// </summary>
        public double PageX { get; set; }

        /// <summary>
        /// The Y coordinate of the mouse pointer relative to the whole document.
        /// </summary>
        public double PageY { get; set; }
    }
}
