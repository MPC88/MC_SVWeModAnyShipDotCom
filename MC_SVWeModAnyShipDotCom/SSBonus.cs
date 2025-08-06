using System.Collections.Generic;

namespace MC_SVWeModAnyShipDotCom
{
    public class SSBonus
    {
        internal static List<string> excludeList = new List<string>()
        {
            "field",
            "minSkillRank",
            "shipEnhancementRank",
            "hideFleetShipGainText"
        };

        public string type;
        public BonusProperty[] properties;

        public class BonusProperty
        {
            public string name;
            public object value;
        }
    }
}
