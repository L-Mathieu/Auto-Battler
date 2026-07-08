namespace Auto_Battler.Domain.Hero
{
    public class Hero : Character
    {
        public int Level { get; private set; }

        public Hero(
            string name,
            double hp,
            double baseAttack,
            double baseDefence,
            double baseSpeed)
            : base(name, hp, baseAttack, baseDefence, baseSpeed)
        {
            Level = 1;
        }
    }
}
