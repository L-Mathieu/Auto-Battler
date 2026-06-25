using Auto_Battler.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Battler.Combat
{
    public class CombatSystem
    {
        private readonly Team _teamA;
        private readonly Team _teamB;

        private readonly TargetingSystem _targetingSystem;

        public Team? WinningTeam { get; private set; }

        public CombatSystem(Team teamA, Team teamB)
        {
            _teamA = teamA;
            _teamB = teamB;
            _targetingSystem = new TargetingSystem();
        }

        public Character GetTarget(Character attacker)
        {
            if (attacker.Team == null)
                return null;

            Team enemyTeam = GetEnemyTeam(attacker.Team);

            return _targetingSystem.GetRandomTarget(enemyTeam);
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
