using Auto_Battler.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Auto_Battler.Combat;

namespace Auto_Battler.Combat
{
    public class CombatLoop
    {
        private CombatSystem _combatSystem;

        public void Update(double deltaTime)
        {
            _combatSystem.Update(deltaTime);

            var actor = _combatSystem.GetReadyCharacter();

            if (actor == null)
                return;

            var target = _combatSystem.GetTarget(actor);
            actor.ExecuteAttack(target);

            _combatSystem.ConsumeTurn(actor);
        }
    }
}
