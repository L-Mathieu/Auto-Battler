using Auto_Battler.Effects;
using Auto_Battler.Log.CombatLog;
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
        public string Name { get; private set; }
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

        public List<StatusEffect> StatusEffects { get; } = new();

        public bool IsAlive => HP > 0;

        public Team? Team { get; private set; }

        public double ActionProgress { get; private set; }
        public bool IsReady => ActionProgress >= 100;


        public Character(
            string name,
            double maxHp, 
            double baseAttack, 
            double baseDefence,
            double baseSpeed)
        {
            Name = name;

            MaxHP = Math.Max(0, maxHp);
            HP = MaxHP;

            BaseAttack = Math.Max(0, baseAttack);

            BaseDefence = Math.Max(0, baseDefence);

            BaseSpeed = Math.Max(0, baseSpeed);

            ActionProgress = 0;
        }

        internal void SetTeam(Team? team)
        {
            Team = team;
        }

        public double ExecuteAttack(Character target)
        {
            double damage = Attack;
            return target.TakeDamage(damage);
        }

        public double TakeDamage(double damage)
        {
            double finalDamage = Math.Max(1, damage - Defence);

            HP = Math.Max(0, HP - finalDamage);

            Console.WriteLine($"{Name} subit {finalDamage} dégâts");
            Console.WriteLine($"{Name} HP : {HP} / {MaxHP}");
            if (IsAlive)
            {
                Console.WriteLine($"{Name} vivant ? : {IsAlive}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{Name} vivant ? : {IsAlive}");
                Console.ResetColor();
            }

            return finalDamage;
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
