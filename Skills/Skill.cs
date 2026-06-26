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

        protected Skill(string name)
        {
            Name = name;
        }

        public abstract double Execute(Character caster, Character target);
    }
}
