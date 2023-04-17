using DamageChecker.Services;
using Destiny2DataLibrary.Models;
using Microsoft.AspNetCore.Components;

namespace DamageChecker.Components
{
	partial class DamageMenu
	{
		[Inject]
		public DamageService DamageService { get; set; }

		//if its true show Pvp stats, else Pve stats
		[Parameter]
		public bool IsPvp { get; set; } = false;

		[Parameter]
		public Archetype? CurrentArchetype { get; set; } = null;

		[CascadingParameter]
		public CombinedBuff CurrentCombinedBuff { get; set; } = new CombinedBuff();

		//display damage component
		DisplayDamage? displayDamage;

		private int _reloadValue = 100;

		public int ReloadValue
		{
			get
			{
				return _reloadValue;
			}
			set
			{
				if (value >= 0 && value <= 100)
				{
					_reloadValue = value;
				}
			}
		}
		private double _takingDamageTime = 60;

		public double TakingDamageTime
		{
			get
			{
				return _takingDamageTime;
			}
			set
			{
				if (value > 0)
					_takingDamageTime = value;
			}
		}

		private int _magSize = 10;

		private int _resiliance = 0;
		public int Resiliance
		{
			get
			{
				return _resiliance;
			}
			set
			{
				if (value >= 0 && value <= 10)
				{
					_resiliance = value;
				}
			}
		}

		public int MagSize
		{
			get
			{
				return _magSize;
			}
			set
			{
				if (value >= 1)
				{
					_magSize = value;
				}
			}
		}

		private double GetReloadTime()
		{
			double reloadTime = -1;
			if (CurrentArchetype != null && CurrentArchetype.WeaponType != null)
			{
				reloadTime = DamageService.GetReloadTime(CurrentArchetype.WeaponType.ReloadStats, ReloadValue);
			}
			return reloadTime;
		}

		private double GetReloadDps()
		{
			if (CurrentArchetype != null && CurrentArchetype.WeaponType != null)
			{
				return Math.Round(DamageService.GetReloadPveDps(CurrentArchetype, CurrentCombinedBuff,
					GetReloadTime(), TakingDamageTime, MagSize), 2);
			}
			return -1;

		}

		private int GetBulletToShoot()
		{
			return DamageService.GetBulletToHitAmount(CurrentArchetype, CurrentCombinedBuff, Resiliance);
		}

		private double GetTTK()
		{
			return Math.Round(DamageService.GetTTK(CurrentArchetype, CurrentCombinedBuff, Resiliance), 2);
		}

		private void SwitchMode()
		{
			IsPvp = !IsPvp;
		}

		private void OpenPvp()
		{
			IsPvp = true;
		}

		private void OpenPve()
		{
			IsPvp = false;
		}

	}
}
