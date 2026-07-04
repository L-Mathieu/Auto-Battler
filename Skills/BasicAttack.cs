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
        public BasicAttack() : base("Basic Attack", "Une simple attaque", TargetType.Enemy, 0)
        {
        }

        public override bool CanExecute(Character caster)
        {
            return true;
        }

        public override double Execute(Character caster, Character target)
        {
            return target.TakeDamage(caster.Attack);
        }

        public override int GetPriority(Character caster)
        {
            return 0;
        }
    }
}
