using Auto_Battler.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Battler.Skills
{
    public abstract class Skill
    {
        public string Name { get; }
        public string Description { get; }
        public TargetType TargetType { get; }
        public int Cooldown { get; }

        protected Skill(string name, string description, TargetType targetType, int cooldown)
        {
            Name = name;
            Description = description;
            TargetType = targetType;
            Cooldown = cooldown;
        }

        public virtual bool CanExecute(Character caster)
        {
            bool canExecute;
            if (caster.SkillCooldowns[this] == 0)
            {
                canExecute = true;
            }
            else
            {
                canExecute = false;
            }
            return canExecute;
        }

        public abstract double Execute(Character caster, Character target);

        public abstract int GetPriority(Character caster);
    }
}
