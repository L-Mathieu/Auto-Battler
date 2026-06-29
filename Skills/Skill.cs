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

        protected Skill(string name, string description, TargetType targetType)
        {
            Name = name;
            Description = description;
            TargetType = targetType;
        }

        public abstract double Execute(Character caster, Character target);
    }
}
