# MC_SVWeModAnyShipDotCom
  
Requires BepInEx.  
  
Backup your saves.  
  
It doesn't let you change everything.  You cannot add new turrets, modify models or textures, ship and turret bonuses changes also not implemented (beyond roles).  
  
1. Run the game once.  A new folder will be created in .\Star Valor\BepInEx\plugins\.  
2. Create a new file <ship name>.shipmod in this folder.  For example, if I wanted to mod a driller I would create "driller.shipmod".  
3. Run the game again (main menu is fine), the file will be populated with the base ship stats.  
4. Close the game, open the .shipmod file in a text editor, modify any stat(s) and restart.  
  
Deleting the .shipmod file will revert the ship to its vanilla stats, but unknown what will happen if you have extra crew or weapons equipped when you do this.  
  
Be careful.  If it's a whole number, replace with another whole number.  If you want to add seats, best to copy from another ship which already has them to get the correct structure. 
  
Some of the less obvious stuff:  
factions = factions who use the ship  
level = minimum AI level who will use the ship  
  
Possible values (there are more, but to avoid possible spoilers / crashes...):  
  
ShipClassLevel:  
Shuttle, Yacht,	Corvette,	Frigate, Cruiser,	Dreadnought  
  
ShipRole:  
None, Interceptor, Fighter,	Gunship, Destroyer,	Battleship,	Carrier, Corsair,	Mining,	Freighter, Ranger  
  
Factions:  
Any, Independent, Miners, Traders, Pirates, Venghi,	Rebels,	Tecnomancers  
  
Crew Positions:  
Engineer, Pilot, Navigator, Supervisor, Gunner, Co_Pilot, FirstOfficer, Staff  
  
Weapon Turret Type:  
Rotating, limitedArch  
