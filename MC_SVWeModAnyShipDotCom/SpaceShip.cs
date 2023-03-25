﻿using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml.Serialization;
using UnityEngine;

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
		public float sizeScale = -1f;
		public CrewSeat[] crewSpace;
		public ReputationRequisite repReq;
		public TFaction[] factions;
		public Turret[] weapons;
		public SSBonus[] bonuses;

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
				crewSpace = smd.crewSpace,
				sizeScale = smd.sizeScale,
				weapons = GetWeapons(smd),
				bonuses = GetBonuses(smd.modelBonus)
			};

			return ss;
        }

		private static SSBonus[] GetBonuses(ShipBonus[] bonusList)
        {
			SSBonus[] bonuses = new SSBonus[bonusList.Length];
			
			for(int i = 0; i < bonusList.Length; i++)
            {
				Type bonusType = bonusList[i].GetType();

				FieldInfo[] bonusFields = bonusList[i].GetType().GetFields();

                List<SSBonus.BonusProperty> properties = new List<SSBonus.BonusProperty>();
				foreach(FieldInfo field in bonusFields)
                {
					if(!SSBonus.excludeList.Contains(field.Name))
                    {
						if (field.FieldType == typeof(ShipBonus[]))
						{
							properties.Add(new SSBonus.BonusProperty()
							{
								name = field.Name,
								value = GetBonuses((ShipBonus[]) field.GetValue(bonusList[i]))
							});
						}
						else
						{
							object val = null;

							// CrewBonus "bonus" field is a single element float array :(
							if (field.Name.Equals("bonus") &&
								field.FieldType == typeof(Single[]) &&
								bonusType.IsSubclassOf(typeof(CrewBonus)))
								val = ((Single[]) field.GetValue(bonusList[i]))[0];
							else
								val = field.GetValue(bonusList[i]);

							properties.Add(new SSBonus.BonusProperty()
							{
								name = field.Name,
								value = val
							});
						}
					}
                }

				SSBonus bonus = new SSBonus()
				{
					type = bonusType.Name,
					properties = properties.ToArray()
				};

				bonuses[i] = bonus;
            }
			
			return bonuses;
        }

		private static Turret[] GetWeapons(ShipModelData smd)
        {
			Turret[] weapons = new Turret[smd.weaponSlotsGO.childCount];

			if (smd.weaponSlotsGO != null && smd.weaponSlotsGO.childCount > 0)
			{
				for (int i = 0; i < smd.weaponSlotsGO.childCount; i++)
				{
					WeaponTurret turret = smd.weaponSlotsGO.GetChild(i).GetComponent<WeaponTurret>();
					if (turret != null)
					{
						weapons[i] = new Turret()
						{
							type = turret.type,
							spinalMount = turret.spinalMount,
							degreesLimit = turret.degreesLimit,
							turnSpeed = turret.turnSpeed,
							totalSpace = turret.totalSpace,
							maxInstalledWeapons = turret.maxInstalledWeapons,
							hasSpecialStats = turret.hasSpecialStats ? UndefBool.True : UndefBool.False,
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

			return weapons;
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
			if(moddedShipData.sizeScale > 0)
				smd.sizeScale = moddedShipData.sizeScale;
			smd.weaponSlotsGO = ModifyWeaponSlots(moddedShipData.weapons, smd.weaponSlotsGO);
			if(moddedShipData.bonuses != null && moddedShipData.bonuses.Length > 0)
				smd.modelBonus = ModifyBonuses(moddedShipData.bonuses, smd.modelBonus);

			return true;
		}

		private static Transform ModifyWeaponSlots(Turret[] moddedWeapons, Transform originalWeapons)
        {
			for (int i = 0; i < moddedWeapons.Length; i++)
			{
				if (i < originalWeapons.childCount && moddedWeapons[i] != null)
				{
					WeaponTurret turret = originalWeapons.GetChild(i).GetComponent<WeaponTurret>();

					if (turret == null)
						turret = originalWeapons.GetChild(i).gameObject.AddComponent<WeaponTurret>();

					if (turret.baseWeaponMods == null)
						turret.baseWeaponMods = new WeaponStatsModifier();

					turret.type = moddedWeapons[i].type;
					turret.spinalMount = moddedWeapons[i].spinalMount;
					turret.degreesLimit = moddedWeapons[i].degreesLimit;
					turret.turnSpeed = moddedWeapons[i].turnSpeed;
					turret.totalSpace = moddedWeapons[i].totalSpace;
					turret.maxInstalledWeapons = moddedWeapons[i].maxInstalledWeapons;
					if (moddedWeapons[i].hasSpecialStats == UndefBool.False)
						turret.hasSpecialStats = false;
					else if (moddedWeapons[i].hasSpecialStats == UndefBool.True)
						turret.hasSpecialStats = true;
					turret.baseWeaponMods.dmgBonus = moddedWeapons[i].mods.dmgBonus;
					turret.baseWeaponMods.criticalChanceBonus = moddedWeapons[i].mods.criticalChanceBonus;
					turret.baseWeaponMods.criticalDamageBonus = moddedWeapons[i].mods.criticalDamageBonus;
					turret.baseWeaponMods.armorPenBonus = moddedWeapons[i].mods.armorPenBonus;
					turret.baseWeaponMods.massKiller = moddedWeapons[i].mods.massKiller;
					turret.baseWeaponMods.rangeBonus = moddedWeapons[i].mods.rangeBonus;
					turret.baseWeaponMods.rangeBonusPerc = moddedWeapons[i].mods.rangeBonusPerc;
					turret.baseWeaponMods.projectileSpeedBonus = moddedWeapons[i].mods.projectileSpeedBonus;
					turret.baseWeaponMods.projectileSpeedPerc = moddedWeapons[i].mods.projectileSpeedPerc;
					turret.baseWeaponMods.heatCapBonus = moddedWeapons[i].mods.heatCapBonus;
					turret.baseWeaponMods.heatCapMod = moddedWeapons[i].mods.heatCapMod;
					turret.baseWeaponMods.weaponHeatMod = moddedWeapons[i].mods.weaponHeatMod;
					turret.baseWeaponMods.chargeTime = moddedWeapons[i].mods.chargeTime;
					turret.baseWeaponMods.chargedFireTime = moddedWeapons[i].mods.chargedFireTime;
					turret.baseWeaponMods.chargedFireCooldown = moddedWeapons[i].mods.chargedFireCooldown;
					turret.baseWeaponMods.fluxDamageMod = moddedWeapons[i].mods.fluxDamageMod;
					turret.baseWeaponMods.explodeBoostChance = moddedWeapons[i].mods.explodeBoostChance;
					turret.baseWeaponMods.explodeBoost = moddedWeapons[i].mods.explodeBoost;
					turret.baseWeaponMods.sizeMod = moddedWeapons[i].mods.sizeMod;
					turret.baseWeaponMods.weaponChargedBaseDamageBoost = moddedWeapons[i].mods.weaponChargedBaseDamageBoost;
				}
			}

			return originalWeapons;
		}

		private static ShipBonus[] ModifyBonuses(SSBonus[] moddedBonuses, ShipBonus[] originalBonusList)
        {
            List<ShipBonus> newBonusList = new List<ShipBonus>();

			// Read bonuses list from game
			Dictionary<string, Type> bonusList = GetBonusList();

			// Logs bonuses "used" so if a ship has multiple instances of the same
			// bonus they are not overridden.
			Dictionary<Type, int> usedInstances = new Dictionary<Type, int>();

			// Logs bonus indexes where no existing ship bonus is found
			List<int> newBonuses = new List<int>();

			// Update existing bonuses
			for (int i = 0; i < moddedBonuses.Length; i++)
            {
				// Get actual type from stored string
				Type bonusType;

				if (bonusList.TryGetValue(moddedBonuses[i].type, out bonusType))
				{
					bool updateDone = false;
					int used = usedInstances.ContainsKey(bonusType) ? usedInstances[bonusType] : 0;
					if (used == 0)
						usedInstances.Add(bonusType, 0);

					int instance = 0;
					for (int j = 0; j < originalBonusList.Length; j++)
                    {
                        if (originalBonusList[j].GetType() == bonusType && instance++ == used)
                        {
							ShipBonus newBonus = (ShipBonus)ScriptableObject.CreateInstance(bonusType);
							foreach (FieldInfo field in bonusType.GetFields())
                            {
								field.SetValue(newBonus, field.GetValue(originalBonusList[j]));
                            }

							foreach (SSBonus.BonusProperty property in moddedBonuses[i].properties)
							{
								FieldInfo field = bonusType.GetField(property.name);
								object val = property.value;

								if (field.Name.Equals("bonus") &&
									field.FieldType == typeof(Single[]) &&
									bonusType.IsSubclassOf(typeof(CrewBonus)))
									val = new float[1] { (float)val };
                                else if (field.Name.Equals("shipBonuses") &&
                                    field.FieldType == typeof(ShipBonus[]) &&
                                    bonusType == typeof(SB_FleetShipBonuses))
                                    val = ModifyBonuses((SSBonus[])val, (ShipBonus[])field.GetValue(originalBonusList[j]));
                                
								field.SetValue(newBonus, val);								
							}
							newBonusList.Add(newBonus);

							usedInstances[bonusType]++;
							updateDone = true;
                        }
                    }

					if (!updateDone)
						newBonuses.Add(i);
				}
            }

			// Add new bonuses, if any
			if (newBonuses.Count > 0)
            {
				//TODO: Adding new bonuses
            }

			return newBonusList.ToArray();
        }

		private static Dictionary<string, Type> GetBonusList()
		{
			AccessTools.Method(typeof(ShipBonusDB), "LoadShipBonuses").Invoke(null, null);

			Dictionary<string, Type> bonuses = new Dictionary<string, Type>();

			foreach (ShipBonus bonus in AccessTools.StaticFieldRefAccess<List<ShipBonus>>(typeof(ShipBonusDB), "list"))
			{
				Type bonusType = bonus.GetType();
				if (!bonuses.ContainsKey(bonusType.Name))
					bonuses.Add(bonusType.Name, bonusType);
			}

			//SB_Flux and SB_FluxPassiveBonus aren't in ShipBonusDB because reasons
			bonuses.Add("SB_Flux", typeof(SB_Flux));
			bonuses.Add("SB_FluxPassiveBonus", typeof(SB_FluxPassiveBonus));

			return bonuses;
		}
	}
}
