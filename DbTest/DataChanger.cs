using Destiny2DataLibrary.DataAccess;
using Destiny2DataLibrary.Models;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbTest
{
    internal class DataChanger
    {
        public void FillWeaponTypes()
        {
            using (var context = new Destiny2DataContext())
            {
                var types = new WeaponType[17];
                types[0] = new WeaponType()
                {
                    Name = "pulse rifle"
                };
                types[1] = new WeaponType()
                {
                    Name = "auto rifle"
                };
                types[2] = new WeaponType()
                {
                    Name = "sniper rifle"
                };
                types[3] = new WeaponType()
                {
                    Name = "scout rifle"
                };
                types[4] = new WeaponType()
                {
                    Name = "fusion rifle"
                };
                types[5] = new WeaponType()
                {
                    Name = "hand cannon"
                };
                types[6] = new WeaponType()
                {
                    Name = "submachine gun"
                };
                types[7] = new WeaponType()
                {
                    Name = "sidearm"
                };
                types[8] = new WeaponType()
                {
                    Name = "bow"
                };
                types[9] = new WeaponType()
                {
                    Name = "shotgun"
                };
                types[10] = new WeaponType()
                {
                    Name = "grenade launcher"
                };
                types[11] = new WeaponType()
                {
                    Name = "trace rifle"
                };
                types[12] = new WeaponType()
                {
                    Name = "glaive"
                };
                types[13] = new WeaponType()
                {
                    Name = "sword"
                };
                types[14] = new WeaponType()
                {
                    Name = "rocket launcher"
                };
                types[15] = new WeaponType()
                {
                    Name = "linear fusion rifle"
                };
                types[16] = new WeaponType()
                {
                    Name = "machine gun"
                };
                foreach (var it in types)
                {
                    context.WeaponTypes.Add(it);
                    //Console.WriteLine(it.Name);
                }
                context.SaveChanges();
            }
        }

        public void FillArchetype()
        {
            var path = "D:\\програмрование\\проги\\Destiny2DataLibrary\\DbTest\\tables\\primary.csv";
            var parser = new TextFieldParser(path);
            parser.SetDelimiters(",");
            parser.HasFieldsEnclosedInQuotes = true;
            List<string[]> rows=new List<string[]>();
            while (!parser.EndOfData)
            {
                rows.Add(parser.ReadFields());
            }
            using (var context = new Destiny2DataContext())
            {
                foreach(var fields in rows)
                {
                    var shotDamage = new ShotDamage()
                    {
                        PveBulletDamage = int.Parse(fields[2]),
                        PvePrecisionBulletDamage = int.Parse(fields[3]),
                        PvpBulletDamage = -1,
                        PvpPrecisionBulletDamage = -1,
                    };
                    var archetype = new Archetype()
                    {
                        Name = fields[1].ToLower(),
                        RoundsPerMinute = int.Parse(fields[4]),
                        WeaponType = context.WeaponTypes.Where(a => a.Name == fields[0].ToLower()).Single(),
                        ShotDamage = shotDamage
                    };
                    context.ShotsDamage.Add(shotDamage);
                    context.Archetypes.Add(archetype);
                }
                context.SaveChanges();
            }
        }
    }
}
