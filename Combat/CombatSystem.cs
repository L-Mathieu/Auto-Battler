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
        private readonly List<Character> _readyCharacters = new();

        public CombatSystem(List<Character> teamA, List<Character> teamB)
        {
            _allCharacters = teamA.Concat(teamB).ToList();
        }

        public void Update(double deltaTime)
        {
            foreach (var character in _allCharacters)
            {
                if (!character.IsAlive)
                    continue;

                character.UpdateActionProgress(deltaTime);

                if (character.IsReady && !_readyCharacters.Contains(character))
                {
                    _readyCharacters.Add(character);
                }
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
            Team enemyTeam = GetEnemyTeam(attacker.Team);

            return enemyTeam.Members
                .Where(c => c.IsAlive)
                .OrderBy(_ => Guid.NewGuid())
                .FirstOrDefault();
        }

        private Team GetEnemyTeam(Team team)
        {
            return team == _teamA ? _teamB : _teamA;
        }

        public void ConsumeTurn(Character character)
        {
            character.ResetActionProgress();
        }
    }
}
