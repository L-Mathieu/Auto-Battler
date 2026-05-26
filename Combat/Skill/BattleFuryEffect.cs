using Auto_Battler.Stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Battler.Combat.Skill
{
    public class BattleFuryEffect : StatusEffect
    {
        private readonly List<IStatModifier> _mods;

        public BattleFuryEffect(double duration)
        {
            Duration = duration;

            _mods = new List<IStatModifier>
        {
            new StatModifier(StatType.Attack, ModifierType.Multiplicative, 0.30),
            new StatModifier(StatType.Speed, ModifierType.Multiplicative, 0.15)
        };
        }

        public override List<IStatModifier> GetModifiers() => _mods;
    }
}
