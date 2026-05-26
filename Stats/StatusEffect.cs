using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Battler.Stats
{
    public abstract class StatusEffect
    {
        public double Duration { get; protected set; }

        public abstract List<IStatModifier> GetModifiers();

        public virtual void Tick(double deltaTime)
        {
            Duration -= deltaTime;
        }

        public bool IsExpired => Duration <= 0;
    }
}
