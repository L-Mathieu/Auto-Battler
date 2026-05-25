using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Battler.Core
{
    public abstract class StatusEffect
    {
        public double Duration { get; protected set; }

        public abstract void Update(Character character, double deltaTime);

        public virtual bool IsFinished => Duration <= 0;
    }
}
