using Auto_Battler.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Battler.Combat
{
    public class TurnSystem
    {
        private readonly Team _teamA;
        private readonly Team _teamB;
        private readonly IEnumerable<Character> _characters;
        private IEnumerable<Character> AllCharacters =>
_teamA.Members.Concat(_teamB.Members);

        public TurnSystem(IEnumerable<Character> characters)
        {
            _characters = characters;
        }

        public void Update(double deltaTime)
        {
            foreach (var character in _characters)
            {
                if (!character.IsAlive)
                    continue;

                character.UpdateActionProgress(deltaTime);
            }
        }

        public Character GetReadyCharacter()
        {
            return _characters
                .Where(c => c.IsAlive && c.IsReady)
                .OrderByDescending(c => c.ActionProgress) // optionnel
                .FirstOrDefault();
        }
        public void ConsumeTurn(Character character)
        {
            character.ResetActionProgress();
        }

    }
}
