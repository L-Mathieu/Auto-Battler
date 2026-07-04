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
        public string SkillName { get; set; }
        public CombatEventType EventType { get; set; }
        public double Amount { get; set; }

        public double DefenderHpBeforeAttack { get; set; }
        public double DefenderHpAfterAttack { get; set; }

        public bool DefenderIsAlive { get; set; }

        public override string ToString()
        {
            string actionText = EventType switch
            {
                CombatEventType.Damage => "inflige",
                CombatEventType.Heal => "soigne",
                _ => "fait une action sur"
            };

            string amountText = EventType switch
            {
                CombatEventType.Damage => $"{Amount} dégâts",
                CombatEventType.Heal => $"{Amount} PV",
                _ => $"{Amount}"
            };

            string status = DefenderIsAlive ? "vivant" : "mort";

            return $"{AttackerName} utilise {SkillName} sur {DefenderName} et {actionText} {amountText}. " +
                   $"PV : {DefenderHpBeforeAttack} -> {DefenderHpAfterAttack}. " +
                   $"Statut : {status}";
        }
    }
}
