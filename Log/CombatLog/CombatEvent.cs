using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Battler.Log.CombatLog
{
    public class CombatEvent
    {
        public string AttackerName { get; set; }
        public string DefenderName { get; set; }
        public double Damage { get; set; }
        public double DefenderHpAfterAttack { get; set; }
        public bool DefenderIsAlive { get; set; }
    }
}
