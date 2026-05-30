using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Battler.Core.Hero
{
    public class Hero : Character
    {
        public int Level { get; private set; }

        public Hero(
            string name,
            double hp,
            double baseAttack,
            double baseDefence,
            double baseSpeed)
            : base(name, hp, baseAttack, baseDefence, baseSpeed)
        {
            Level = 1;
        }
    }
}
