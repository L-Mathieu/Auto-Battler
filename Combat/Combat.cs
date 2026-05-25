using Auto_Battler.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Battler.Combat
{
    public class Combat
    {
        private List<Character> TeamA;
        private List<Character> TeamB;
        public bool IsCombatActive = false;

        public Combat(List<Character> teamA, List<Character> teamB)
        {
            TeamA = teamA;
            TeamB = teamB;
            IsCombatActive = true;


        }
    }
}
