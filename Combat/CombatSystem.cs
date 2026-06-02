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
    //    private IEnumerable<Character> AllCharacters =>
    //_teamA.Members.Concat(_teamB.Members);

        private readonly TargetingSystem _targetingSystem;
        //private readonly Random _random = new Random();

        public Team? WinningTeam { get; private set; }

        public CombatSystem(Team teamA, Team teamB)
        {
            _teamA = teamA;
            _teamB = teamB;
            _targetingSystem = new TargetingSystem();
        }

        //public void Update(double deltaTime)
        //{
        //    foreach (var character in AllCharacters)
        //    {
        //        if (!character.IsAlive)
        //            continue;

        //        character.UpdateActionProgress(deltaTime);
        //    }
        //}

        //public Character GetReadyCharacter()
        //{
        //    return AllCharacters
        //        .Where(c => c.IsAlive && c.IsReady)
        //        .OrderByDescending(c => c.ActionProgress) // optionnel
        //        .FirstOrDefault();
        //}

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
