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
            var injuredCharacter = caster.Team.Members
                .MinBy(s => s.HP/s.MaxHP);
            switch ((injuredCharacter.HP / injuredCharacter.MaxHP) * 100)
            {
                case >= 100:
                    priority = -1;
                    break;
                case > 75:
                    priority = 1;
                    break;
                case > 50:
                    priority = 15;
                    break;
                case > 25:
                    priority = 50;
                    break;
                case > 10:
                    priority = 100;
                    break;
                case > 1:
                    priority = 1000;
                    break;
            }
            return priority;
        }
    }
}
