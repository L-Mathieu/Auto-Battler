using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Battler.Stats
{
    public interface IStatModifier
    {
        StatType Stat { get; }
        ModifierType ModifierType { get; }
        double Value { get; }
    }
}
