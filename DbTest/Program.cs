using Destiny2DataLibrary.DataAccess;
using Destiny2DataLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.FileIO;

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
                    Console.WriteLine(it.Id+": "+it.WeaponType.Name + " " + it.Name + " " + it.RoundsPerMinute + " " + it.ShotDamage.PvpPrecisionBulletDamage);
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

        static void addPerk()
        {
            using (var context = new Destiny2DataContext())
            {
                int[] idAll = { 12 };
                int[] archetypes = { 777, 778 };
                foreach (int id in idAll)
                {
                    var perk = context.Perks.Include(p => p.Archetypes).Where(perk => perk.Id == id).Single();
                    foreach (int archetype in archetypes)
                    {
                        var buffer = context.Archetypes.Where(a => a.Id == archetype).Single();
                        perk.Archetypes.Add(buffer);
                    }
                }
                context.SaveChanges();
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("so");
        }
    }
}