using Auto_Battler.Core;
using Auto_Battler.Log.CombatLog;
using Auto_Battler.Skills;
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
        public CombatLog FightLog { get; }

        public CombatLoop(Team teamA, Team teamB)
        {
            _combatSystem = new CombatSystem(teamA, teamB);

            var allCharacters = teamA.Members.Concat(teamB.Members);
            _turnSystem = new TurnSystem(allCharacters);

            FightLog = new CombatLog();
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

            var skill = actor.SelectSkill();

            var target = _combatSystem.GetTarget(actor, skill.TargetType);

            double targetHpBeforeAttack = target.HP;

            double amount = skill.Execute(actor, target);

            actor.StartCooldown(skill);

            var combatEvent = new CombatEvent
            {
                AttackerName = actor.Name,
                DefenderName = target.Name,
                SkillName = skill.Name,
                Amount = amount,
                EventType = skill is Heal ? CombatEventType.Heal : CombatEventType.Damage,
                DefenderHpBeforeAttack = targetHpBeforeAttack,
                DefenderHpAfterAttack = target.HP,
                DefenderIsAlive = target.IsAlive
            };

            FightLog.Add(combatEvent);

            _turnSystem.ConsumeTurn(actor);

            IsFinished = _combatSystem.IsCombatFinished();
        }

        public Team GetWinningTeam()
        {
            return _combatSystem.GetWinningTeam();
        }
    }
}
