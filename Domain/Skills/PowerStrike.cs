namespace Auto_Battler.Domain.Skills
{
    public class PowerStrike : Skill
    {
        public PowerStrike() : base("Power Strike", "Une attaque puissante", TargetType.Enemy, 2)
        {
        }

        public override double Execute(Character caster, Character target)
        {
            return target.TakeDamage(caster.Attack * 1.5);
        }

        public override int GetPriority(Character caster)
        {
            return 20;
        }
    }
}
