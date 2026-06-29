using Auto_Battler.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Battler.Skills
{
    public class BasicAttack : Skill
    {
        public BasicAttack() : base("Basic Attack", "Une simple attaque", TargetType.Enemy)
        {
        }

        public override double Execute(Character caster, Character target)
        {
            return target.TakeDamage(caster.Attack);
        }
    }
}
