using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;

namespace MC_SVWeModAnyShipDotCom
{
    [BepInPlugin(pluginGuid, pluginName, pluginVersion)]
    public class Main : BaseUnityPlugin
    {
        public const string pluginGuid = "mc.starvalor.wemodanyshipdotcom";
        public const string pluginName = "SV We Mod Any Ship.com";
        public const string pluginVersion = "1.1.0";
                
        private const string modFilesDIR = "\\ShipMods\\";

        private static string pluginFolder = "";

        internal static ManualLogSource log = BepInEx.Logging.Logger.CreateLogSource(pluginName);

        public void Awake()
        {
            Harmony.CreateAndPatchAll(typeof(Main));
            pluginFolder = Path.GetDirectoryName(GetType().Assembly.Location);
        }

        private static void LoadModFiles()
        {
            string path = pluginFolder + modFilesDIR;
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            Dictionary<string, int> shipNames = GetShipNames();

            string[] fileList = Directory.GetFiles(path, "*.shipmod");
            if (fileList.Length < shipNames.Count)
                GenerateMissing(shipNames, path);

            fileList = Directory.GetFiles(path, "*.shipmod");
            foreach (string file in fileList)
            {
                string fileName = Path.GetFileName(file);
                if (shipNames.TryGetValue(fileName.Replace(".shipmod", "").ToLower(), out int id))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(SpaceShip));
                    using (XmlReader reader = XmlReader.Create(file))
                    {
                        SpaceShip ss = (SpaceShip)xmlSerializer.Deserialize(reader);                        
                        SpaceShip.Modify(id, ss);
                    }
                }
                else
                {
                    File.Copy(path + fileName, path + "ERR" + fileName, true);
                    File.Delete(path + fileName);
                }
            }
        }

        private static void GenerateMissing(Dictionary<string, int> shipNames, string path)
        {
            foreach (KeyValuePair<string, int> ship in shipNames)
            {
                bool found = false;
                foreach (string file in Directory.GetFiles(path, "*.shipmod"))
                {
                    string fileName = Path.GetFileName(file);
                    if (fileName.Replace(".shipmod", "").ToLower().Equals(ship.Key))
                    {
                        found = true;
                    }
                }

                if (!found)
                    WriteShipData(ship.Value, path + ship.Key + ".shipmod");
            }
        }

        private static void WriteShipData(int id, string file)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(SpaceShip));
            using(TextWriter writer = new StreamWriter(file))
            {
                xmlSerializer.Serialize(writer, SpaceShip.GetShip(id));
            }
        }

        private static Dictionary<string, int> GetShipNames()
        {
            Dictionary<string, int> names = new Dictionary<string, int>();
            
            foreach (ShipModelData smd in AccessTools.StaticFieldRefAccess<List<ShipModelData>>(typeof(ShipDB), "shipModels"))
                names.Add(smd.shipModelName.ToLower(), smd.id);

            return names;
        }

        [HarmonyPatch(typeof(ShipDB), nameof(ShipDB.LoadDatabaseForce))]
        [HarmonyPostfix]
        private static void ShipDBLoad_Post()
        {
            LoadModFiles();            
        }
    }
}
