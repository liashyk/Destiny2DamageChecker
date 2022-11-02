using Microsoft.EntityFrameworkCore;
using Destiny2DataLibrary.DataAccess;
using Destiny2DataLibrary.Models;
using Destiny2DataLibrary.Migrations;
using Microsoft.EntityFrameworkCore.Storage;

namespace DbTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var changer = new DataChanger();
            //changer.FillPerk("D:\\програмрование\\проги\\Destiny2DataLibrary\\DbTest\\tables\\perks\\surroundedSwords.csv");
            //using (var context = new Destiny2DataContext())
            //{
            //    Perk perk = context.Perks.OrderBy(x => x.Id).Last();
            //    var achetypes = Enumerable.ToArray(context.Archetypes
            //        .Where(a=>a.WeaponType.Name=="sword"));
            //    perk.Archetypes = achetypes;
            //    perk.Summary = "While within 8 metres of 3+ Enemies: 30% Increased Damage. " +
            //        "(Swords receive a 25% Damage Increase) Surrounded Spec increases Damage by an additive 10% and adds a " +
            //        "linger effect for 1.5 seconds Enhanced: " +
            //        "Surrounded's damage buff is increased by a multiplicative 5%.";
            //    context.SaveChanges();
            //}
        }
    }
}