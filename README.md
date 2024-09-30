# MC_SVWeModAnyShipDotCom
  
Uninstall any mods and attempt to repeat any issues you suspect may exist with the vanilla game before reporting on the forums or discord.  
  
Backup your saves.  
  
This mod will increase the game load time, especially on the first run.  

WARNING: When this mod first runs, it generals .shipmod xml files for all ships in the game.  It then loads those and overrides in-game settings.  This means if an official update changes an existing ship, this mod will override those.  To resolve this, delete the .xml file for the updated ship.
  
## Installation

1. Install BepInEx - https://docs.bepinex.dev/articles/user_guide/installation/index.html Stable version 5.4.21 x86.  
2. Run the game at least once to initialise BepInEx and quit.  
3. Download latest mod release.  
4. Place MC_SVWeModAnyShipDotCom.dll in .\SteamLibrary\steamapps\common\Star Valor\BepInEx\plugins\  

## Use
  
Modify ship stats, weapon turret properties, crew positions, bonuses etc.  The mod doesn't let you change everything.  You cannot add new turrets or modify models or textures.  
  
1. Run the game once.  A new folder will be created in .\Star Valor\BepInEx\plugins\ with shipmod files for all ships in the game.  
2. Close the game, open the .shipmod file in a text editor, modify any stat(s) and restart.  
  
Note that new ships will automatically have a .shipmod file generated, but any changes to existing ships by official patches will not be included unless the existing .shipmod file is deleted, allowing the mod to generate a new one with new base stats for the ship.  
  
Deleting the .shipmod file will revert the ship to its vanilla stats, but unknown what will happen if you have extra crew or weapons equipped when you do this.  
  
Be careful.  If it's a whole number, replace with another whole number.  If you want to add seats, best to copy from another ship which already has them to get the correct structure. 

## Some info on ship stats
  
Some of the less obvious stuff:  
factions = factions who use the ship  
level = minimum AI level who will use the ship  
  
Possible values (there are more, but to avoid possible spoilers / crashes...):  
  
ShipClassLevel  
Shuttle, Yacht,	Corvette,	Frigate, Cruiser,	Dreadnought  
  
ShipRole  
None, Interceptor, Fighter,	Gunship, Destroyer,	Battleship,	Carrier, Corsair,	Mining,	Freighter, Ranger  
  
Factions  
Any, Independent, Miners, Traders, Pirates, Venghi,	Rebels,	Tecnomancers  
  
Crew Positions   
Engineer, Pilot, Navigator, Supervisor, Gunner, Co_Pilot, FirstOfficer, Staff  
  
Weapon Turret Type  
Rotating, limitedArch  

Temp Damage Bonuses (weapon slot damage bonus)  
All, Energy, Cannon, Vulcan, Missile, MiningLaser, DONOTUSE, Plasma, Mine, Torpedo, Pulse, Railgun, Repair, Remove  
  
Note: "Remove" exists as a means to remove an damage bonus while maintaining backwards compatability with shipmod files generated with previous versions of the mod i.e. the mod wont remove bonuses where none are defined in the .shipmod XML.  
  
## Ship Bonuses
  
### Types and changing values

The list shows the xml format you need.  Just copy-paste into the relevant ShipBonus list and modify the value.  For example, in the line:
```
<value xsi:type="xsd:float">0.0</value>
```

I would modify the 0.0 to whatever I wanted.  Nothing else should be changed.

If a ship does not have any existing bonuses i.e. has an entry like
```
<bonuses />
```
  
Replace that line with the following two lines
```
<bonuses>
</bonuses>
```
then add SSBonus entries between those lines as normal
  
Refer to the list below for possible values for types:

xsd:float  
A decimal number
  
xsd:int  
A whole number
  
xsd:boolean  
true, false

CrewPosition  
Engineer, Pilot, Navigator, Supervisor, Gunner, Instructor, Tactician, Co_Pilot, FirstOfficer, Staff, Captain
  
WeaponType  
None, Energy, Cannon, Vulcan, Missile, MiningLaser, Booster, Plasma, Mine, Torpedo, Pulse, Railgun, Repair
  
TFaction  
Any, Independent, Miners, Traders, Pirates, Venghi, Rebels, Tecnomancers

ArrayOfSSBonus  
One or more <SSBonus> sub-entries (from the list below) should be added.  Different example values are shown for SB_FleetShipBonuses bonus and SB_ShipManufacturerBonus.  Iziko.shipmod has further examples.
  
VariableStatType  
CollectorRange, CollectorSpeed, BlueprintChance, LootSoundWarning, LootDetectStrong, CantBuyEquipmentOrShip, BasicBlueprints, RepairOnScavenge
  
### Bonuses

  
```
<SSBonus>
	<type>CB_Acceleration</type>
	<properties>
		<BonusProperty>
			<name>bonus</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_Armor</type>
	<properties>
		<BonusProperty>
			<name>ArmorBonus</name>
			<value xsi:type="xsd:int">0</value>
		</BonusProperty>
		<BonusProperty>
			<name>ArmorMod</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>CB_PowerOptimization</type>
	<properties>
		<BonusProperty>
			<name>bonus</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>CB_PowerManagement</type>
	<properties>
		<BonusProperty>
			<name>bonus</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>CB_Navigation</type>
	<properties>
		<BonusProperty>
			<name>bonus</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>CB_Prospect</type>
	<properties>
		<BonusProperty>
			<name>bonus</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>CB_Scanning</type>
	<properties>
		<BonusProperty>
			<name>bonus</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>CB_Sensors</type>
	<properties>
		<BonusProperty>
			<name>bonus</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>CB_StrafeSpeed</type>
	<properties>
		<BonusProperty>
			<name>bonus</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>CB_Tecnology</type>
	<properties>
		<BonusProperty>
			<name>bonus</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>CB_Trading</type>
	<properties>
		<BonusProperty>
			<name>bonus</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_TurnSpeed</type>
	<properties>
		<BonusProperty>
			<name>turnSpeedMod</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>CB_Velocity</type>
	<properties>
		<BonusProperty>
			<name>bonus</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_ShieldAbsorb</type>
	<properties>
		<BonusProperty>
			<name>shieldAbsorb</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_WarpDistance</type>
	<properties>
		<BonusProperty>
			<name>warpDistanceBonus</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_MiningSpeed</type>
	<properties>
		<BonusProperty>
			<name>miningBonus</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_Hull</type>
	<properties>
		<BonusProperty>
			<name>hullBonus</name>
			<value xsi:type="xsd:int">0</value>
		</BonusProperty>
		<BonusProperty>
			<name>hullMod</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_Shield</type>
	<properties>
		<BonusProperty>
			<name>shieldBonus</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_WeaponCrit</type>
	<properties>
		<BonusProperty>
			<name>critialChanceBonus</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_WeaponRange</type>
	<properties>
		<BonusProperty>
			<name>rangeBonus</name>
			<value xsi:type="xsd:int">0</value>
		</BonusProperty>
		<BonusProperty>
			<name>rangeBonusPerc</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_MarketInsight</type>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_WeaponDmg</type>
	<properties>
		<BonusProperty>
			<name>weaponType</name>
			<value xsi:type="WeaponType">Energy</value>
		</BonusProperty>
		<BonusProperty>
			<name>damageBonus</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_Xp</type>
	<properties>
		<BonusProperty>
			<name>xpModifier</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_CrewXp</type>
	<properties>
		<BonusProperty>
			<name>xpModifier</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_HPRegen</type>
	<properties>
		<BonusProperty>
			<name>hpRegen</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_HeatCap</type>
	<properties>
		<BonusProperty>
			<name>heatCapBonus</name>
			<value xsi:type="xsd:int">0</value>
		</BonusProperty>
		<BonusProperty>
			<name>heatCapMod</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_WeaponCritDmgBonus</type>
	<properties>
		<BonusProperty>
			<name>criticalDamageBonus</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_WeaponHeatGenerated</type>
	<properties>
		<BonusProperty>
			<name>weaponHeatMod</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_ExplosiveChance</type>
	<properties>
		<BonusProperty>
			<name>explodeBoostChance</name>
			<value xsi:type="xsd:int">0</value>
		</BonusProperty>
		<BonusProperty>
			<name>explodeBoost</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_SpeedBoost</type>
	<properties>
		<BonusProperty>
			<name>speedBoost</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
		<BonusProperty>
			<name>energyCost</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_TechLevelXp</type>
	<properties>
		<BonusProperty>
			<name>techLevelXpMod</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_SpacePilotXp</type>
	<properties>
		<BonusProperty>
			<name>spacePilotXpMod</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_FleetCommanderXp</type>
	<properties>
		<BonusProperty>
			<name>fleetCommanderXpMod</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_GeologyXp</type>
	<properties>
		<BonusProperty>
			<name>geologyXpMod</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_Bounty</type>
	<properties>
		<BonusProperty>
			<name>extraBounty</name>
			<value xsi:type="xsd:int">0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_FleetCommander</type>
	<properties>
		<BonusProperty>
			<name>fleetCommanderBonus</name>
			<value xsi:type="xsd:int">0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_HeavyWeaponDmg</type>
	<properties>
		<BonusProperty>
			<name>heavyWeaponBonus</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_LightWeaponDmg</type>
	<properties>
		<BonusProperty>
			<name>lightWeaponBonus</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_eWarp</type>
	<properties>
		<BonusProperty>
			<name>eWarpRepair</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
		<BonusProperty>
			<name>ignoreEWarpSickness</name>
			<value xsi:type="xsd:boolean">true</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_FleetShipBonuses</type>
	<properties>
		<BonusProperty>
			<name>manufacturer</name>
			<value xsi:type="TFaction"></value>
		</BonusProperty>
		<BonusProperty>
			<name>shipBonuses</name>
			<value xsi:type="ArrayOfSSBonus">
				<SSBonus>
					<type>SB_MassSupremacy</type>
				</SSBonus>
			</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_HangarRepair</type>
	<properties>
		<BonusProperty>
			<name>hangarRepairBonus</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_Geology</type>
	<properties>
		<BonusProperty>
			<name>geologyBonus</name>
			<value xsi:type="xsd:int">0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_CrewEfficiency</type>
	<properties>
		<BonusProperty>
			<name>position</name>
			<value xsi:type="xsd:CrewPosition">Engineer</value>
		</BonusProperty>
		<BonusProperty>
			<name>efficiencyBonus</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_Tutor</type>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_CrewEfficiencySolo</type>
	<properties>
		<BonusProperty>
			<name>efficiencyBonus</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_Reputation</type>
	<properties>
		<BonusProperty>
			<name>repModifier</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_SpacePilot</type>
	<properties>
		<BonusProperty>
			<name>spacePilotBonus</name>
			<value xsi:type="xsd:int">0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_HPRegenCurrent</type>
	<properties>
		<BonusProperty>
			<name>hpRegenCurrent</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_CurrHPShieldRegen</type>
	<properties>
		<BonusProperty>
			<name>shieldRegenHPBased</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_EnhancementSlot</type>
	<properties>
		<BonusProperty>
			<name>extraSlots</name>
			<value xsi:type="xsd:int">0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_ShieldFlat</type>
	<properties>
		<BonusProperty>
			<name>flatShieldBonus</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_CargoSpace</type>
	<properties>
		<BonusProperty>
			<name>flatCargoSpace</name>
			<value xsi:type="xsd:int">0</value>
		</BonusProperty>
		<BonusProperty>
			<name>cargoSpaceMod</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_Energy</type>
	<properties>
		<BonusProperty>
			<name>energyBonus</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_RepairCost</type>
	<properties>
		<BonusProperty>
			<name>repairCost</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_ScannerPower</type>
	<properties>
		<BonusProperty>
			<name>scannerBonus</name>
			<value xsi:type="xsd:int">0</value>
		</BonusProperty>
		<BonusProperty>
			<name>scannerMod</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
   </properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_WeaponCooling</type>
	<properties>
		<BonusProperty>
			<name>flatCooling</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_BuiltInEquipment</type>
	<properties>
		<BonusProperty>
			<name>equipmentID</name>
			<value xsi:type="xsd:int">0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_WarpCost</type>
	<properties>
		<BonusProperty>
			<name>warpCostMod</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_ExplorerXp</type>
	<properties>
		<BonusProperty>
			<name>explorerXpMod</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_ShipManufacturerBonus</type>
	<properties>
		<BonusProperty>
			<name>manufacturer</name>
			<value xsi:type="TFaction"></value>
		</BonusProperty>
		<BonusProperty>
			<name>shipBonuses</name>
			<value xsi:type="ArrayOfSSBonus">
				<SSBonus>
					<type>SB_WeaponHeatGenerated</type>
					<properties>
						<BonusProperty>
							<name>weaponHeatMod</name>
							<value xsi:type="xsd:float">0.0</value>
						</BonusProperty>
					</properties>
				</SSBonus>
			</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_Prodigy3rdSeat</type>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_ImpactDamage</type>
	<properties>
		<BonusProperty>
			<name>impactBonus</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_ProximityDmgMod</type>
	<properties>
		<BonusProperty>
			<name>proxDmgMod</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_WeaponAutoTargeting</type>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_DroneModifiers</type>
	<properties>
		<BonusProperty>
			<name>dmgMod</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
		<BonusProperty>
			<name>speedBonus</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
		<BonusProperty>
			<name>HPBonus</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
		<BonusProperty>
			<name>partsRecovery</name>
			<value xsi:type="xsd:boolean">true</value>
		</BonusProperty>
		<BonusProperty>
			<name>autoTargeting</name>
			<value xsi:type="xsd:boolean">true</value>
		</BonusProperty>
		<BonusProperty>
			<name>explodeOnDestroyMod</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_ExplosionRadius</type>
	<properties>
		<BonusProperty>
			<name>aoeBonus</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>CB_TurnSpeed</type>
	<properties>
		<BonusProperty>
			<name>bonus</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_Agility</type>
	<properties>
		<BonusProperty>
			<name>agilityBonus</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_AmmoReplicator</type>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_ArmorPiercing</type>
	<properties>
		<BonusProperty>
			<name>armorPen</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_CloakCost</type>
	<properties>
		<BonusProperty>
			<name>cloakEnergyCostMod</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_CloakCoT</type>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_CreditLoot</type>
	<properties>
		<BonusProperty>
			<name>creditLootMod</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_DmgTolerance</type>
	<properties>
		<BonusProperty>
			<name>shipDmgTolerance</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
		<BonusProperty>
			<name>stationDmgTolerance</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_Explorer</type>
	<properties>
		<BonusProperty>
			<name>explorerBonus</name>
			<value xsi:type="xsd:int">0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_JunkTreasure</type>
	<properties>
		<BonusProperty>
			<name>junkTreasureMod</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_MassSupremacy</type>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_ProjectileSpeed</type>
	<properties>
		<BonusProperty>
			<name>projSpeedBonus</name>
			<value xsi:type="xsd:int">0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_Prospect</type>
	<properties>
		<BonusProperty>
			<name>prospectBonus</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_Sensor</type>
	<properties>
		<BonusProperty>
			<name>sensorPowerBonus</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_Speed</type>
	<properties>
		<BonusProperty>
			<name>speedBonus</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_Strafe</type>
	<properties>
		<BonusProperty>
			<name>strafeBonus</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_TradeMod</type>
	<properties>
		<BonusProperty>
			<name>tradeMod</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_Velocity</type>
	<properties>
		<BonusProperty>
			<name>speedBonus</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_WarpTowage</type>
	<properties>
		<BonusProperty>
			<name>warpTowagePower</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_WeaponSpace</type>
	<properties>
		<BonusProperty>
			<name>extraWeaponSlot</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_Flux</type>
	<properties>
		<BonusProperty>
			<name>bonusFluxCharges</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_FluxPassiveBonus</type>
	<properties>
		<BonusProperty>
			<name>maxSpeedBonus</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
		<BonusProperty>
			<name>speedBoostBonus</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
		<BonusProperty>
			<name>critChanceBonus</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
		<BonusProperty>
			<name>critDamageBonus</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_PassiveBuff</type>
	<properties>
		<BonusProperty>
			<name>passiveBuffID</name>
			<value xsi:type="xsd:int">0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```
  
```
<SSBonus>
	<type>SB_VariableStat</type>
	<properties>
		<BonusProperty>
			<name>varStatType</name>
			<value xsi:type="VariableStatType">CollectorRange</value>
		</BonusProperty>
		<BonusProperty>
			<name>value</name>
			<value xsi:type="xsd:float">0.0</value>
		</BonusProperty>
	</properties>
</SSBonus>
```  
