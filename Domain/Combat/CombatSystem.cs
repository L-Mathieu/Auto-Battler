using Auto_Battler.Domain.Skills;

namespace Auto_Battler.Domain.Combat
{
    public class CombatSystem
    {
        private readonly Team _teamA;
        private readonly Team _teamB;

        private readonly ITargetingSystem _targetingSystem;

        public Team? WinningTeam { get; private set; }

        public CombatSystem(Team teamA, Team teamB, ITargetingSystem targetingSystem)
        {
            _teamA = teamA;
            _teamB = teamB;

            _targetingSystem = targetingSystem;
        }

        public Character GetTarget(Character actor, TargetType targetType)
        {
            if (actor.Team == null)
                return null;

            Team team = actor.Team;

            switch (targetType)
            {
                case TargetType.Enemy:
                    team = GetEnemyTeam(actor.Team);
                    break;
                case TargetType.Ally:
                    team = actor.Team;
                    break;
                case TargetType.Self:
                    return actor;
            }

            var target = _targetingSystem.GetTarget(team);

            if (target == null)
            {
                throw new InvalidOperationException(
                    $"No valid target found in team {team.Name}");
            }

            return target;
        }

        private Team GetEnemyTeam(Team team)
        {
            if (team == _teamA)
                return _teamB;

            if (team == _teamB)
                return _teamA;

            throw new InvalidOperationException("Unknown team.");
        }

        public Team GetWinningTeam()
        {
            if (!IsCombatFinished())
                throw new InvalidOperationException("Combat is not finished yet.");

            return _teamA.IsDefeated()
                ? _teamB
                : _teamA;
        }

        public bool IsCombatFinished()
        {
            bool teamAAlive = _teamA.Members.Any(c => c.IsAlive);
            bool teamBAlive = _teamB.Members.Any(c => c.IsAlive);

            return !teamAAlive || !teamBAlive;
        }
    }
}
