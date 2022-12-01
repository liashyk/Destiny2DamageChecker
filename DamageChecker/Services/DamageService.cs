using Destiny2DataLibrary.Models;
using System.Security.AccessControl;

namespace DamageChecker.Services
{
	public class DamageService
	{
		public double GetSimplePveDps(Archetype archetype,CombinedBuff buff)
		{
            int shotDamage = GetBuffedDamage(archetype.ShotDamage,buff);
			return shotDamage*archetype.RoundsPerMinute/60;
		}

        public double GetReloadPveDps(Archetype archetype, CombinedBuff buff,double reloadTime, double damageTime,int magSize)
        {
            double timespended = 0;
            double timeBetweenShot = archetype.FramesBetweenShots / 30;
            double shotDuration = 0;
            int shotDamage = GetBuffedDamage(archetype.ShotDamage, buff);
            int shotCount = 1;
            while (timespended <= damageTime)
            {
                for(int i = 0; i < magSize-1 && timespended <= damageTime; i++)
                {
                    timespended = timespended + shotDuration + timeBetweenShot;
                    shotCount++;
                }
                timespended += reloadTime;
            }
            return shotDamage * shotCount / damageTime;
        }

        public double GetReloadTime(ReloadStat? reloadStat,int reloadValue)
        {
            if (reloadStat == null)
                return 0;
            double reloadTime = (reloadStat.a * (reloadValue * reloadValue) + reloadStat.b * reloadValue + reloadStat.c)/30;
            return Math.Round(reloadTime, 2);
        }

        public int GetBuffedDamage(ShotDamage damage, CombinedBuff combinedBuff, bool isPrecision = true, bool IsPve = true)
        {
            if (damage == null)
                return 0;
            int damageResult;
            if (IsPve)
            {
                if (isPrecision)
                {
                    damageResult = damage.PvePrecisionBulletDamage;
                }
                else
                {
                    damageResult = damage.PveBulletDamage;
                }
                if (combinedBuff != null)
                    damageResult = Convert.ToInt32(Math.Floor(damageResult * (1 + combinedBuff.PveDamageBuffPercent / 100)));
            }
            else
            {
                if (isPrecision)
                {
                    damageResult = damage.PvpPrecisionBulletDamage;
                }
                else
                {
                    damageResult = damage.PvpBulletDamage;
                }
                if (combinedBuff != null)
                    damageResult = Convert.ToInt32(Math.Floor(damageResult * (1 + combinedBuff.PvpDamageBuffPercent / 100)));
            }
            return damageResult;
        }

        public int GetBulletToHitAmount(Archetype archetype, CombinedBuff buff,int resilience)
        {
            int shotDamage = GetBuffedDamage(archetype.ShotDamage, buff,true,false);
            int guardianHp = 200;
            return (int)Math.Ceiling((double)(guardianHp)/shotDamage);
        }

        public double GetTTK(Archetype archetype, CombinedBuff buff, int resilience)
        {
            double timeBetweenShot = archetype.FramesBetweenShots / 30;
            double shotDuration = 0;
            int shotDamage = GetBuffedDamage(archetype.ShotDamage, buff);
            int shotAmount=GetBulletToHitAmount(archetype, buff,resilience);
            return (shotAmount - 1) * timeBetweenShot;
        }
    }
}
