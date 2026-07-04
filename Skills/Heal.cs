using Auto_Battler.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Battler.Skills
{
    public class Heal : Skill
    {
        public int HealAmount { get; }
        public Heal() : base("Heal", "Un soin basique", TargetType.Ally, 5)
        {
            HealAmount = 10;
        }

        public override double Execute(Character caster, Character target)
        {
            return target.Heal(this.HealAmount);
        }

        public override int GetPriority(Character caster)
        {
            var priority = 0;
            var usableSkills = caster.Team.Members
                .Where(s => s.HP < s.MaxHP/2)
                .ToList();
            priority = usableSkills.Count > 0 ? 30 : -1;
            return priority;
        }
    }
}
