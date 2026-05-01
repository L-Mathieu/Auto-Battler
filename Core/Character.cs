using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Battler.Core
{
    public class Character
    {
        public double HP { get; private set; }
        public double BaseAttack  { get; private set; }
        public double BonusAttack { get; private set; }
        public double Attack => BaseAttack * (1 + BonusAttack);
        public double BaseSpeed { get; private set; }
        public double BonusSpeed { get; private set; }
        public double Speed => BaseSpeed * (1 + BonusSpeed);
        public bool IsAlive => HP > 0;
        public double ActionProgress { get; private set; }

        public Character(double hp, double baseAttack, double bonusAttack, double baseSpeed, double bonusSpeed)
        {
            HP = Math.Max(0, hp);
            BaseAttack = Math.Max(0, baseAttack);
            BonusAttack = bonusAttack;
            BaseSpeed = Math.Max(0, baseSpeed);
            BonusSpeed = bonusSpeed;
            ActionProgress = 0;
        }

        public double DealDamage()
        {
            return Attack;
        }

        public void TakeDamage(double damage)
        {
            HP = Math.Max(0, HP - damage);
        }
    }
}
