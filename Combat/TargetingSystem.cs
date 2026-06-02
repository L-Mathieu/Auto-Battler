using Auto_Battler.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Battler.Combat
{
    public class TargetingSystem
    {
        private readonly Random _random = new Random();

        public Character GetRandomTarget(Team enemyTeam)
        {
            var enemies = enemyTeam.Members
                .Where(c => c.IsAlive)
                .ToList();

            if (enemies.Count == 0)
                return null;

            return enemies[_random.Next(enemies.Count)];
        }
    }
}
