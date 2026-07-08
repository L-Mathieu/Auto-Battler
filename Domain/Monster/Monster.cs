namespace Auto_Battler.Domain.Monster
{
    public class Monster : Character
    {
        public Monster(
            string name,
            double hp,
            double baseAttack,
            double baseDefence,
            double baseSpeed)
            : base(name, hp, baseAttack, baseDefence, baseSpeed)
        {

        }
    }
}
