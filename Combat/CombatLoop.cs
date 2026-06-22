using Auto_Battler.Core;
using Auto_Battler.Log.CombatLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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

            double damage = actor.ExecuteAttack(target);

            var combatEvent = new CombatEvent
            {
                AttackerName = actor.Name,
                DefenderName = target.Name,
                Damage = damage,
                DefenderHpAfterAttack = target.HP,
                DefenderIsAlive = target.IsAlive
            };
            Affiche(combatEvent);

            _turnSystem.ConsumeTurn(actor);

            IsFinished = _combatSystem.IsCombatFinished();
        }

        public Team GetWinningTeam()
        {
            return _combatSystem.GetWinningTeam();
        }

        public void Affiche(CombatEvent combatEventLog)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Attaquant : {combatEventLog.AttackerName}");
            Console.WriteLine($"Defenseur : {combatEventLog.DefenderName}");
            Console.WriteLine($"Damage : {combatEventLog.Damage}");
            Console.WriteLine($"DefenseurHp : {combatEventLog.DefenderHpAfterAttack}");
            Console.WriteLine($"Defenseur vivant ? : {combatEventLog.DefenderIsAlive}");
            Console.ResetColor();
        }
    }
}
