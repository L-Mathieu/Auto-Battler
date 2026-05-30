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
        public bool IsFinished { get; private set; }

        private CombatSystem _combatSystem;

        public CombatLoop(CombatSystem combatSystem)
        {
            _combatSystem = combatSystem;
        }

        public void Update(double deltaTime)
        {
            if (IsFinished)
                Console.WriteLine("combat fini");
                return;

            _combatSystem.Update(deltaTime);

            var actor = _combatSystem.GetReadyCharacter();

            if (actor == null)
                return;

            var target = _combatSystem.GetTarget(actor);

            if (target == null)
            {
                throw new InvalidOperationException(
                    $"No valid target found for {actor.Name}");
            }

            actor.ExecuteAttack(target);

            _combatSystem.ConsumeTurn(actor);

            IsFinished = _combatSystem.IsCombatFinished();
        }
    }
}
