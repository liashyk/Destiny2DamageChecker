using Destiny2DataLibrary.Models;
using System.Security.AccessControl;

namespace DamageChecker.Services
{
	public class DamageService
	{
        private readonly int[] _resiliance = { 185, 186, 187, 188, 189, 190, 192, 194, 196, 198, 200 };

        private readonly int _fps = 30;

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="damage"></param>
        /// <param name="combinedBuff"></param>
        /// <param name="isPrecision"></param>
        /// <param name="IsPve"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Return minimal amount bullets to kill enemy
        /// </summary>
        /// <param name="archetype"> Current archetype of weapon</param>
        /// <param name="buff"> current total buff</param>
        /// <param name="resilience"> resilinace stat of enemy</param>
        /// <returns>Return minimal amount bullets to kill enemy</returns>
        public int GetBulletToHitAmount(Archetype archetype, CombinedBuff buff,int resilience)
        {
            int shotDamage = GetBuffedDamage(archetype.ShotDamage, buff,true,false);
            int guardianHp = _resiliance[resilience];
            return (int)Math.Ceiling((double)(guardianHp)/shotDamage);
        }


        private double GetTimeBetweenShots(Archetype archetype, CombinedBuff buff, bool isPvp=true)
        {
            if (buff == null)
            {
                buff = new CombinedBuff();
            }
            double roundsPerSecond;
            if (isPvp)
            {
                roundsPerSecond = archetype.RoundsPerMinute * (buff.PvpRapidFireBuffPercent + 1) / 60;
            }
            else
            {
                roundsPerSecond = archetype.RoundsPerMinute * (buff.PveRapidFireBuffPercent + 1) / 60;
            }
            double framePerBullet = _fps / roundsPerSecond;
            return framePerBullet / _fps; 
        }

        /// <summary>
        /// Return time to kill. If archetype is not shooting bursts
        /// calculate ttk by this formula : (ShotsAmount-1)*secondsBetweenShots
        /// if it is burst - (((burst amount*FramesPerBurstt)-1)+((RoundedBursts-1)*framesBetweenShots))/30
        /// </summary>
        /// <param name="archetype"> Current archetype of weapon</param>
        /// <param name="buff"> current total buff</param>
        /// <param name="resilience"> resilinace stat of enemy</param>
        /// <returns>Return minimal time to kill </returns>
        public double GetTTK(Archetype archetype, CombinedBuff buff, int resilience)
        {
            double timeBetweenShot = GetTimeBetweenShots(archetype,buff);
            int shotAmount=GetBulletToHitAmount(archetype, buff,resilience);
            double timeToKill;
            if (archetype.IsBurst && archetype.BurstStats!=null)
            {
                double burstsAmount = (double)shotAmount / archetype.BurstStats.BulletsInBurst;
                int roundedBurstsAmount = (int)Math.Ceiling(burstsAmount);
                timeToKill = (((burstsAmount*archetype.BurstStats.FramesPerBurst)-1)+((roundedBurstsAmount-1)*archetype.FramesBetweenShots))/30;
            }
            else
            {
                timeToKill = (shotAmount - 1) * timeBetweenShot;
            }
            return timeToKill;
        }
    }
}
