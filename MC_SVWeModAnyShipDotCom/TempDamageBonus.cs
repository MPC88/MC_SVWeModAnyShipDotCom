using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MC_SVWeModAnyShipDotCom
{
    public class TempDamageBonus
    {
        public enum BonusType { All, Energy, Cannon, Vulcan, Missile, MiningLaser, DONOTUSE, Plasma, Mine, Torpedo, Pulse, Railgun, Repair, Remove};
        public BonusType type;
        public float bonus;
    }
}
