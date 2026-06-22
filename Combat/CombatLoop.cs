using Auto_Battler.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Battler.Combat
{
    public class CombatLoop
    {
        public bool IsFinished { get; private set; }

        private CombatSystem _combatSystem;
        private TurnSystem _turnSystem;

        public CombatLoop(Team teamA, Team teamB)
        {
            _combatSystem = new CombatSystem(teamA, teamB);

            var allCharacters = teamA.Members.Concat(teamB.Members);
            _turnSystem = new TurnSystem(allCharacters);
        }

        public void Update(double deltaTime)
        {
            if (IsFinished)
            {
                Console.WriteLine("combat fini");
                return;
            }


            _turnSystem.Update(deltaTime);

            var actor = _turnSystem.GetReadyCharacter();

            if (actor == null)
                return;

            var target = _combatSystem.GetTarget(actor);

            if (target == null)
            {
                throw new InvalidOperationException(
                    $"No valid target found for {actor.Name}");
            }

            actor.ExecuteAttack(target);

            _turnSystem.ConsumeTurn(actor);

            IsFinished = _combatSystem.IsCombatFinished();
        }
    }
}
