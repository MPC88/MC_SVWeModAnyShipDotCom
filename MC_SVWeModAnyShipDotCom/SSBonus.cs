using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
