using Auto_Battler.Effects;
using Auto_Battler.Stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Battler.Core
{
    public abstract class Character
    {
        public double MaxHP { get; private set; }
        public double HP { get; private set; }

        public double BaseAttack  { get; private set; }

        public double Attack =>
            ApplyModifiers(BaseAttack, StatType.Attack);

        public double BaseDefence { get; private set; }
        public double Defence =>
            ApplyModifiers(BaseDefence, StatType.Defence);

        public double BaseSpeed { get; private set; }
        public double Speed =>
            ApplyModifiers(BaseSpeed, StatType.Speed);

        public List<StatusEffect> StatusEffects { get; }

        /// <summary>
        /// 
        /// </summary>

        public bool IsAlive => HP > 0;

        public double ActionProgress { get; private set; }


        public Character(
            double maxHp, 
            double baseAttack, 
            double baseDefence,
            double baseSpeed)
        {
            MaxHP = Math.Max(0, maxHp);
            HP = MaxHP;

            BaseAttack = Math.Max(0, baseAttack);

            BaseDefence = Math.Max(0, baseDefence);

            BaseSpeed = Math.Max(0, baseSpeed);

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

        private IEnumerable<IStatModifier> GetAllModifiers()
        {
            foreach (var effect in StatusEffects)
            {
                foreach (var mod in effect.GetModifiers())
                {
                    yield return mod;
                }
            }
        }

        private double ApplyModifiers(double baseValue, StatType stat)
        {
            double flat = 0;
            double multiplier = 1;

            foreach (var mod in GetAllModifiers())
            {
                if (mod.Stat != stat)
                    continue;

                if (mod.ModifierType == ModifierType.Additive)
                    flat += mod.Value;
                else
                    multiplier *= (1 + mod.Value);
            }

            return (baseValue + flat) * multiplier;
        }
    }
}
