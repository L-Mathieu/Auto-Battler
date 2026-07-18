namespace Auto_Battler.Domain.Hero
{
    public class Hero : Character
    {
        public int Level { get; private set; }

        public Hero(
            string name,
            double maxHp,
            double baseAttack,
            double baseDefence,
            double baseSpeed)
            : base(name, maxHp, baseAttack, baseDefence, baseSpeed)
        {
            Level = 1;
        }

        public Hero(
            string name,
            int level,
            double maxHp,
            double hp,
            double baseAttack,
            double baseDefence,
            double baseSpeed)
            : base(name, maxHp, hp, baseAttack, baseDefence, baseSpeed)
        {
            Level = level;
        }
    }
}
