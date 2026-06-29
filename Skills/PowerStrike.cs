using Auto_Battler.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Battler.Skills
{
    public class PowerStrike : Skill
    {
        public PowerStrike() : base("Power Strike", "Une attaque puissante", TargetType.Enemy)
        {
        }

        public override double Execute(Character caster, Character target)
        {
            return target.TakeDamage(caster.Attack * 1.5);
        }
    }
}
