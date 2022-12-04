using Destiny2DataLibrary.DataAccess;
using Destiny2DataLibrary.Migrations;
using Destiny2DataLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic.FileIO;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace DbTest
{
    internal class Program
    {
        static void FillPvp()
        {
            var path = "D:\\програмрование\\проги\\Destiny2DataLibrary\\DbTest\\tables\\pvp.csv";
            var parser = new TextFieldParser(path);
            parser.SetDelimiters(",");
            parser.HasFieldsEnclosedInQuotes = true;
            List<string[]> rows = new List<string[]>();
            parser.ReadFields();
            while (!parser.EndOfData)
            {
                rows.Add(parser.ReadFields());
            }
            using (var context = new Destiny2DataContext())
            {
                List<string> archetypes = new List<string>();
                foreach (var fields in rows)
                {
                    Archetype archetype = null;
                    try
                    {
                        archetype = context.Archetypes.Include(a => a.WeaponType).Include(a => a.ShotDamage)
                            .Where(
                            a => (a.WeaponType.Name.Equals(fields[0].ToLower())
                            && a.Name.Equals(fields[1].ToLower()))
                            ).Single();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine(fields[0] + " " + fields[1]);
                        archetypes.Add(fields[0] + " " + fields[1]);
                    }
                    if (archetype != null && archetype.ShotDamage.PvpPrecisionBulletDamage == -1)
                    {
                        archetype.ShotDamage.PvpBulletDamage = int.Parse(fields[3]);
                        if (fields[2] != "")
                        {
                            archetype.ShotDamage.PvpPrecisionBulletDamage = int.Parse(fields[2]);
                        }
                        else
                        {
                            archetype.ShotDamage.PvpPrecisionBulletDamage = int.Parse(fields[3]);
                        }
                        archetype.FramesBetweenShots = double.Parse(fields[6]);
                        if (fields[4] != "")
                        {
                            archetype.IsBurst = true;
                            archetype.BurstStats = new BurstStats()
                            {
                                BulletsInBurst = int.Parse(fields[4]),
                                FramesPerBurstt = int.Parse(fields[5])
                            };
                        }
                        else
                        {
                            archetype.IsBurst = false;
                        }
                    }
                }
                context.SaveChanges();
            }
        }

        static void ClearArchetypes()
        {
            using (var context = new Destiny2DataContext())
            {
                var archetypes = Enumerable.ToArray(context.Archetypes);
                foreach (var it in archetypes)
                {
                    context.Archetypes.Remove(it);
                }
                context.SaveChanges();
            }
        }
        static void ShowArchetypes()
        {
            using (var context = new Destiny2DataContext())
            {
                var archetypes = (context.Archetypes.Include(a => a.WeaponType).Include(a => a.ShotDamage));
                foreach (var it in archetypes)
                {
                    Console.WriteLine(it.Id + ": " + it.WeaponType.Name + " " + it.Name + " " + it.RoundsPerMinute + " " + it.ShotDamage.PvpPrecisionBulletDamage);
                }
            }
        }

        static void AddArchetype()
        {
            using (var context = new Destiny2DataContext())
            {
                var shotDamage = new ShotDamage()
                {
                    PveBulletDamage = 338,
                    PvePrecisionBulletDamage = 474,
                    PvpBulletDamage = 13,
                    PvpPrecisionBulletDamage = 17
                };
                Archetype archetype = new Archetype()
                {
                    AmmoType = context.AmmoTypes.Where(a => a.Id == 2).Single(),
                    Name = "adaptive",
                    RoundsPerMinute = 1000,
                    IsBurst = false,
                    WeaponType = context.WeaponTypes.Where(a => a.Name == "trace rifle").Single(),
                    FramesBetweenShots = 2,
                    ShotDamage = shotDamage,
                };
                context.Archetypes.Add(archetype);
                context.ShotsDamage.Add(shotDamage);
                context.SaveChanges();
            }
        }

        static async Task AddPerk(Perk perk)
        {
            using (var _context = new Destiny2DataContext())
            {
                foreach(var archetype in _context.Archetypes.Include(a=>a.WeaponType))
                {
                    if(true)
                        perk.Archetypes.Add(archetype);
                }
                _context.Perks.Add(perk);
                if (perk.ActivationSteps != null)
                {
                    foreach (BuffStack perkStack in perk.ActivationSteps)
                    {
                        _context.BuffStacks.Add(perkStack);
                    }
                }
                await _context.SaveChangesAsync();
            }
        }

        static double CalculateReload(int reloadStat, double a, double b, double c)
        {
            return (a * (reloadStat * reloadStat) + b * reloadStat + c) / 30;
        }

        static double CalculateReloadAmmo(int reloadStat, double timeForAmmo)
        {
            return (reloadStat * timeForAmmo) / 30;
        }

        static void FillReload()
        {
            var path = "D:\\програмрование\\проги\\Destiny2DamageChecker\\DbTest\\tables\\reloadStat.csv";
            var parser = new TextFieldParser(path);
            parser.SetDelimiters(",");
            parser.HasFieldsEnclosedInQuotes = true;
            List<string[]> rows = new List<string[]>();
            parser.ReadFields();
            while (!parser.EndOfData)
            {
                rows.Add(parser.ReadFields());
            }
            using (var context = new Destiny2DataContext())
            {
                List<string> archetypes = new List<string>();
                foreach (var fields in rows)
                {
                    var weaponType = context.WeaponTypes.Where(w => w.Name == fields[0].ToLower()).Single();
                    var reloadStat = new ReloadStat()
                    {
                        a = double.Parse(fields[1]),
                        b = double.Parse(fields[2]),
                        c = double.Parse(fields[3])
                    };
                    weaponType.ReloadStats = reloadStat;
                }
                context.SaveChanges();
            }
        }

        static void ShowPerk(Perk perk)
        {
            Console.WriteLine(perk.Name + " : ");
            foreach (var it in perk.ActivationSteps)
            {
                Console.WriteLine(it.StepNumber + " - " + it.PveDamageBuffPercent);
            }
            Console.WriteLine();
        }

        static async Task ApiTest()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7208/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage responseMessage = await client.GetAsync("api/WeaponTypes");
            var responce = await client.GetAsync($"api/Archetypes/FromWeaponType/1");
            Console.WriteLine(responce.IsSuccessStatusCode);
            if (responce.IsSuccessStatusCode)
            {
                var archetypes = await responce.Content.ReadFromJsonAsync<IEnumerable<Archetype>>();
                foreach (Archetype it in archetypes)
                {
                    Console.WriteLine(it.Name);
                }
            }
            else
            {
                Console.WriteLine("ooops");
            }
        }

        static async Task AddDamageBuff(DamageBuff buff, int buffCategoryId)
        {
            using (var context = new Destiny2DataContext())
            {
                buff.BuffCategory = context.BuffCategories.Find(buffCategoryId);
                context.DamageBuffs.Add(buff);
                if (buff.ActivationSteps != null)
                {
                    foreach (BuffStack perkStack in buff.ActivationSteps)
                    {
                        context.BuffStacks.Add(perkStack);
                    }
                }
                await context.SaveChangesAsync();
            }
        }

        static async Task Main(string[] args)
        {
            var acivationsSpets = new BuffStack[]
            {
                new BuffStack() { StepNumber = 1, PveDamageBuffPercent = 20, PvpDamageBuffPercent = 15 },
                new BuffStack() { StepNumber = 2, PveDamageBuffPercent = 25, PvpDamageBuffPercent = 20 },
                new BuffStack() { StepNumber = 1, PveDamageBuffPercent = 35, PvpDamageBuffPercent = 25 },
                new BuffStack() { StepNumber = 1, PveDamageBuffPercent = 40, PvpDamageBuffPercent = 35 }
            };
            DamageBuff damageBuff = new DamageBuff()
            {
                Name = "the path of burning steps",
                Summary = "Solar Kills have a chance of granting 1 stack of Firewalker. [1 to 3 Kills, average of 2]\r\nBecoming Frozen grants 1 stack of Firewalker.\r\n Max of 4 Stacks.\r\n\r\nFirewalker increases Weapon Damage and lasts 10 seconds.\r\n1x = 20% | 2x = 25% | 3x = 35% | 4x = 40%\r\n1x = 15% | 2x = 25% | 3x = 20% | 4x = 35%",
                ActivationSteps = acivationsSpets,
                ActivationStepsAmount = acivationsSpets.Length,
            };
            await AddDamageBuff(damageBuff, 2);
            //using (var _context = new Destiny2DataContext())
            //{
            //    _context.BuffCategories.Add(new BuffCategory() { Name = "global debuffs" }) ;
            //    _context.BuffCategories.Add(new BuffCategory() { Name = "empowering buffs" });
            //    _context.BuffCategories.Add(new BuffCategory() { Name = "amplification modifiers" });
            //    _context.SaveChanges();
            //}

        }
    }
}