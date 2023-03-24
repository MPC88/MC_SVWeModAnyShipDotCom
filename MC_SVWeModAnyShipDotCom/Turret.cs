namespace MC_SVWeModAnyShipDotCom
{
    public enum UndefBool { Unknown, False, True }
    public class Turret
    {
        public WeaponTurretType type;
        public bool spinalMount;
        public float degreesLimit = 10f;
        public float turnSpeed = 20f;
        public float totalSpace;
        public int maxInstalledWeapons;
        public TurretMods mods;
        public UndefBool hasSpecialStats = UndefBool.Unknown;
    }
}
