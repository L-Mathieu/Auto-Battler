using Auto_Battler.Domain.Combat.Targeting;
using Auto_Battler.Domain.Skills;
using Auto_Battler.Infrastructure.Log.CombatLog;

namespace Auto_Battler.Domain.Combat
{
    public class CombatLoop
    {
        public bool IsFinished { get; private set; }

        private readonly CombatSystem _combatSystem;
        private readonly TurnSystem _turnSystem;
        public CombatLog FightLog { get; }

        public CombatLoop(Team teamA, Team teamB, ITargetingSystem targetingSystem)
        {
            _combatSystem = new CombatSystem(teamA, teamB, targetingSystem);

            var allCharacters = teamA.Members.Concat(teamB.Members);
            _turnSystem = new TurnSystem(allCharacters);

            FightLog = new CombatLog();
        }

        public void Update(double deltaTime)
        {
            if (IsFinished)
            {
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
