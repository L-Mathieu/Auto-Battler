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

        public double DefenderHpBeforeAttack { get; set; }
        public double DefenderHpAfterAttack { get; set; }

        public bool DefenderIsAlive { get; set; }

        public override string ToString()
        {
            string status = DefenderIsAlive ? "vivant" : "mort";

            return $"{AttackerName} attaque {DefenderName} et inflige {Damage} dégâts. " +
                   $"PV : {DefenderHpBeforeAttack} -> {DefenderHpAfterAttack}. " +
                   $"Statut : {status}";
        }
    }
}
