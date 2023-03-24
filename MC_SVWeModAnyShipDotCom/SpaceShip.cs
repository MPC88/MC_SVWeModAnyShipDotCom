using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace MC_SVWeModAnyShipDotCom
{
    [Serializable]
    public class SpaceShip
    {
		public string shipModelName;
		public TFaction manufacturer;
		public ShipClassLevel shipClass = ShipClassLevel.Yacht;
		public ShipRole shipRole;
		public int sellChance = 100;
		public int level = 5;
		public int hullPoints = 100;
		public int weaponSpace = 3;
		public int equipSpace = 15;
		public int cargoSpace = 25;
		public int hangarDroneSpace;
		public int hangarShipSpace;
		public int passengers;
		public int speed = 10;
		public int agility = 10;
		public int mass = 70;
		public int rarity = 1;
		public CrewSeat[] crewSpace;
		public ReputationRequisite repReq;
		public TFaction[] factions;
		public Turret[] weapons;

		internal static SpaceShip GetShip(int id)
        {
			ShipModelData smd = ShipDB.GetModel(id);

			if (smd == null)
				return null;

			SpaceShip ss = new SpaceShip()
			{
				shipModelName = smd.shipModelName,
				manufacturer = smd.manufacturer,
				shipClass = smd.shipClass,
				shipRole = smd.shipRole,
				sellChance = smd.sellChance,
				level = smd.level,
				hullPoints = smd.hullPoints,
				weaponSpace = smd.weaponSpace,
				equipSpace = smd.equipSpace,
				cargoSpace = smd.cargoSpace,
				hangarDroneSpace = smd.hangarDroneSpace,
				hangarShipSpace = smd.hangarShipSpace,
				passengers = smd.passengers,
				speed = smd.speed,
				agility = smd.agility,
				mass = smd.mass,
				rarity = smd.rarity,
				factions = smd.factions,
				repReq = smd.repReq,
				crewSpace = smd.crewSpace
			};

			ss.weapons = new Turret[smd.weaponSlotsGO.childCount];

			if (smd.weaponSlotsGO != null && smd.weaponSlotsGO.childCount > 0)
            {
				for (int i = 0; i < smd.weaponSlotsGO.childCount; i++)
                {
					WeaponTurret turret = smd.weaponSlotsGO.GetChild(i).GetComponent<WeaponTurret>();
					if(turret != null)
                    {
						ss.weapons[i] = new Turret()
						{
							type = turret.type,
							spinalMount = turret.spinalMount,
							degreesLimit = turret.degreesLimit,
							turnSpeed = turret.turnSpeed,
							totalSpace = turret.totalSpace,
							maxInstalledWeapons = turret.maxInstalledWeapons,
							hasSpecialStats = turret.hasSpecialStats ? UndefBool.True:UndefBool.False,
							mods = new TurretMods()
                            {
								dmgBonus = turret.baseWeaponMods.dmgBonus,
								criticalChanceBonus = turret.baseWeaponMods.criticalChanceBonus,
								criticalDamageBonus = turret.baseWeaponMods.criticalDamageBonus,
								armorPenBonus = turret.baseWeaponMods.armorPenBonus,
								massKiller = turret.baseWeaponMods.massKiller,
								rangeBonus = turret.baseWeaponMods.rangeBonus,
								rangeBonusPerc = turret.baseWeaponMods.rangeBonusPerc,
								projectileSpeedBonus = turret.baseWeaponMods.projectileSpeedBonus,
								projectileSpeedPerc = turret.baseWeaponMods.projectileSpeedPerc,
								heatCapBonus = turret.baseWeaponMods.heatCapBonus,
								heatCapMod = turret.baseWeaponMods.heatCapMod,
								weaponHeatMod = turret.baseWeaponMods.weaponHeatMod,
								chargeTime = turret.baseWeaponMods.chargeTime,
								chargedFireTime = turret.baseWeaponMods.chargedFireTime,
								chargedFireCooldown = turret.baseWeaponMods.chargedFireCooldown,
								fluxDamageMod = turret.baseWeaponMods.fluxDamageMod,
								explodeBoostChance = turret.baseWeaponMods.explodeBoostChance,
								explodeBoost = turret.baseWeaponMods.explodeBoost,
								sizeMod = turret.baseWeaponMods.sizeMod,
								weaponChargedBaseDamageBoost = turret.baseWeaponMods.weaponChargedBaseDamageBoost
							}
						};
                    }
                }
            }

			return ss;
        }

		internal static bool Modify(int id, SpaceShip moddedShipData)
        {
			ShipModelData smd = ShipDB.GetModel(id);
			if (smd == null)
				return false;

			smd.shipModelName = moddedShipData.shipModelName;
			smd.manufacturer = moddedShipData.manufacturer;
			smd.shipClass = moddedShipData.shipClass;
			smd.shipRole = moddedShipData.shipRole;
			smd.sellChance = moddedShipData.sellChance;
			smd.level = moddedShipData.level;
			smd.hullPoints = moddedShipData.hullPoints;
			smd.weaponSpace = moddedShipData.weaponSpace;
			smd.equipSpace = moddedShipData.equipSpace;
			smd.cargoSpace = moddedShipData.cargoSpace;
			smd.hangarDroneSpace = moddedShipData.hangarDroneSpace;
			smd.hangarShipSpace = moddedShipData.hangarShipSpace;
			smd.passengers = moddedShipData.passengers;
			smd.speed = moddedShipData.speed;
			smd.agility = moddedShipData.agility;
			smd.mass = moddedShipData.mass;
			smd.rarity = moddedShipData.rarity;
			smd.factions = moddedShipData.factions;
			smd.repReq = moddedShipData.repReq;
			smd.crewSpace = moddedShipData.crewSpace;

			for (int i = 0; i < moddedShipData.weapons.Length; i++)
            {
				if (i < smd.weaponSlotsGO.childCount && moddedShipData.weapons[i] != null)
                {
					WeaponTurret turret = smd.weaponSlotsGO.GetChild(i).GetComponent<WeaponTurret>();

					if (turret == null)
						turret = smd.weaponSlotsGO.GetChild(i).gameObject.AddComponent<WeaponTurret>();

					if (turret.baseWeaponMods == null)
						turret.baseWeaponMods = new WeaponStatsModifier();

					turret.type = moddedShipData.weapons[i].type;
					turret.spinalMount = moddedShipData.weapons[i].spinalMount;
					turret.degreesLimit = moddedShipData.weapons[i].degreesLimit;
					turret.turnSpeed = moddedShipData.weapons[i].turnSpeed;
					turret.totalSpace = moddedShipData.weapons[i].totalSpace;
					turret.maxInstalledWeapons = moddedShipData.weapons[i].maxInstalledWeapons;
					if (moddedShipData.weapons[i].hasSpecialStats == UndefBool.False)
						turret.hasSpecialStats = false;
					else if (moddedShipData.weapons[i].hasSpecialStats == UndefBool.True)
						turret.hasSpecialStats = true;
					turret.baseWeaponMods.dmgBonus = moddedShipData.weapons[i].mods.dmgBonus;
					turret.baseWeaponMods.criticalChanceBonus = moddedShipData.weapons[i].mods.criticalChanceBonus;
					turret.baseWeaponMods.criticalDamageBonus = moddedShipData.weapons[i].mods.criticalDamageBonus;
					turret.baseWeaponMods.armorPenBonus = moddedShipData.weapons[i].mods.armorPenBonus;
					turret.baseWeaponMods.massKiller = moddedShipData.weapons[i].mods.massKiller;
					turret.baseWeaponMods.rangeBonus = moddedShipData.weapons[i].mods.rangeBonus;
					turret.baseWeaponMods.rangeBonusPerc = moddedShipData.weapons[i].mods.rangeBonusPerc;
					turret.baseWeaponMods.projectileSpeedBonus = moddedShipData.weapons[i].mods.projectileSpeedBonus;
					turret.baseWeaponMods.projectileSpeedPerc = moddedShipData.weapons[i].mods.projectileSpeedPerc;
					turret.baseWeaponMods.heatCapBonus = moddedShipData.weapons[i].mods.heatCapBonus;
					turret.baseWeaponMods.heatCapMod = moddedShipData.weapons[i].mods.heatCapMod;
					turret.baseWeaponMods.weaponHeatMod = moddedShipData.weapons[i].mods.weaponHeatMod;
					turret.baseWeaponMods.chargeTime = moddedShipData.weapons[i].mods.chargeTime;
					turret.baseWeaponMods.chargedFireTime = moddedShipData.weapons[i].mods.chargedFireTime;
					turret.baseWeaponMods.chargedFireCooldown = moddedShipData.weapons[i].mods.chargedFireCooldown;
					turret.baseWeaponMods.fluxDamageMod = moddedShipData.weapons[i].mods.fluxDamageMod;
					turret.baseWeaponMods.explodeBoostChance = moddedShipData.weapons[i].mods.explodeBoostChance;
					turret.baseWeaponMods.explodeBoost = moddedShipData.weapons[i].mods.explodeBoost;
					turret.baseWeaponMods.sizeMod = moddedShipData.weapons[i].mods.sizeMod;
					turret.baseWeaponMods.weaponChargedBaseDamageBoost = moddedShipData.weapons[i].mods.weaponChargedBaseDamageBoost;
				}
            }

			return true;
		}
	}
}
