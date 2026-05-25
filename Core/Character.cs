using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Battler.Core
{
    public class Character
    {
        public double MaxHP { get; private set; }
        public double HP { get; private set; }

        public double BaseAttack  { get; private set; }
        public double TemporaryAttackBonus { get; private set; }
        public double AttackMultiplierBonus { get; private set; }
        public double Attack
        {
            get
            {
                double totalBonus = AttackMultiplierBonus;

                foreach (var effect in StatusEffects)
                {
                    if (effect is AttackBuffEffect attackBuff)
                    {
                        totalBonus += attackBuff.BonusPercent;
                    }
                }

                return BaseAttack * (1 + totalBonus);
            }
        }

        public double BaseDefence { get; private set; }
        public double TemporaryDefenceBonus { get; private set; }
        public double DefenceMultiplierBonus { get; private set; }
        public double Defence =>
            Math.Max(0, BaseDefence * (1 + DefenceMultiplierBonus));

        public double BaseSpeed { get; private set; }
        public double TemporarySpeedBonus { get; private set; }
        public double SpeedMultiplierBonus { get; private set; }
        public double Speed => 
            Math.Max(0, BaseSpeed * (1 + SpeedMultiplierBonus));

        public List<StatusEffect> StatusEffects { get; }

        /// <summary>
        /// Voir chatgpt ce qu'il conseil pour status effects (chat Avis sur la classe Character) et adapter ca pour speed et def
        /// </summary>

        public bool IsAlive => HP > 0;

        public double ActionProgress { get; private set; }


        public Character(
            double maxHp, 
            double baseAttack, 
            double attackMultiplierBonus, 
            double baseDefence,
            double defenceMultiplierBonus,
            double baseSpeed, 
            double speedMultiplierBonus)
        {
            MaxHP = Math.Max(0, maxHp);
            HP = MaxHP;

            BaseAttack = Math.Max(0, baseAttack);
            AttackMultiplierBonus = attackMultiplierBonus;

            BaseDefence = Math.Max(0, baseDefence);
            DefenceMultiplierBonus = defenceMultiplierBonus;

            BaseSpeed = Math.Max(0, baseSpeed);
            SpeedMultiplierBonus = speedMultiplierBonus;

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

        public void Heal(double amount)
        {
            HP = Math.Min(MaxHP, HP + amount);
        }

        public void UpdateActionProgress(double deltaTime)
        {
            ActionProgress += Speed * deltaTime;
        }

        public void ResetActionProgress()
        {
            ActionProgress = 0;
        }
    }
}
