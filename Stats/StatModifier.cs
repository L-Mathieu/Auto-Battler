using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Battler.Stats
{
    public class StatModifier : IStatModifier
    {
        public StatType Stat { get; }
        public ModifierType ModifierType { get; }
        public double Value { get; }

        public StatModifier(StatType stat, ModifierType type, double value)
        {
            Stat = stat;
            ModifierType = type;
            Value = value;
        }
    }
}
