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
        private readonly List<Character> _allCharacters;
        public Team? WinningTeam { get; private set; }

        public CombatSystem(Team teamA, Team teamB)
        {
            _teamA = teamA;
            _teamB = teamB;

            _allCharacters = _teamA.Members
                .Concat(_teamB.Members)
                .ToList();
            //Attention si je modifie _teamA ou _teamB je ne modifie PAS _allCharacters
        }

        public void Update(double deltaTime)
        {
            foreach (var character in _allCharacters)
            {
                if (!character.IsAlive)
                    continue;

                character.UpdateActionProgress(deltaTime);
            }
        }

        public Character GetReadyCharacter()
        {
            return _allCharacters
                .Where(c => c.IsAlive && c.IsReady)
                .OrderByDescending(c => c.ActionProgress) // optionnel
                .FirstOrDefault();
        }

        public Character GetTarget(Character attacker)
        {
            if (attacker.Team == null)
                return null;

            Team enemyTeam = GetEnemyTeam(attacker.Team);

            return enemyTeam.Members
                .Where(c => c.IsAlive)
                .OrderBy(_ => Guid.NewGuid())
                .FirstOrDefault();
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

            bool teamAAlive = _teamA.Members.Any(c => c.IsAlive);

            return teamAAlive ? _teamA : _teamB;
        }

        public void ConsumeTurn(Character character)
        {
            character.ResetActionProgress();
        }

        public bool IsCombatFinished()
        {
            bool teamAAlive = _teamA.Members.Any(c => c.IsAlive);
            bool teamBAlive = _teamB.Members.Any(c => c.IsAlive);

            return !teamAAlive || !teamBAlive;
        }
    }
}
