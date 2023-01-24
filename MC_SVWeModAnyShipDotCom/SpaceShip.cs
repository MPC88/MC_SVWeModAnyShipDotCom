using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace MC_SVWeModAnyShipDotCom
{
    [Serializable]
    public class SpaceShip
    {
		// Name		
		public string shipModelName;

		// Manufacturer
		public TFaction manufacturer;

		// Class
		public ShipClassLevel shipClass = ShipClassLevel.Yacht;

		// Role
		public ShipRole shipRole;

		// Sell chance
		public int sellChance = 100;

		// Ideal AI level (To have full HP on this ship)
		public int level = 5;

		// Hull points
		public int hullPoints = 100;

		// Weapon space
		public int weaponSpace = 3;

		// Equipment space
		public int equipSpace = 15;

		// Cargo space
		public int cargoSpace = 25;

		// Drone hangar space
		public int hangarDroneSpace;

		// Ship hangar space
		public int hangarShipSpace;

		// Passenger space
		public int passengers;

		// Speed
		public int speed = 10;

		// Agility
		public int agility = 10;

		// Mass
		public int mass = 70;

		// Rarity
		public int rarity = 1;

		// Crew
		public CrewSeat[] crewSpace;

		// Reputation requirement
		public ReputationRequisite repReq;

		// Factions who use this ship
		public TFaction[] factions;

		// Weapon slots
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
							maxInstalledWeapons = turret.maxInstalledWeapons						
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
				if (i < smd.weaponSlotsGO.childCount)
                {
					WeaponTurret turret = smd.weaponSlotsGO.GetChild(i).GetComponent<WeaponTurret>();
					turret.type = moddedShipData.weapons[i].type;
					turret.spinalMount = moddedShipData.weapons[i].spinalMount;
					turret.degreesLimit = moddedShipData.weapons[i].degreesLimit;
					turret.turnSpeed = moddedShipData.weapons[i].turnSpeed;
					turret.totalSpace = moddedShipData.weapons[i].totalSpace;
					turret.maxInstalledWeapons = moddedShipData.weapons[i].maxInstalledWeapons;
				}
            }

			return true;
		}
	}
}
