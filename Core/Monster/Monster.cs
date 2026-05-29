using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Battler.Core.Monster
{
    public class Monster : Character
    {
        public string Name { get; }

        public Monster(
            string name,
            double hp,
            double baseAttack,
            double baseDefence,
            double baseSpeed)
            : base(hp, baseAttack, baseDefence, baseSpeed)
        {
            Name = name;
        }
    }
}
