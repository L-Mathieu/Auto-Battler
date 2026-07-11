namespace Auto_Battler.Domain.Combat.Targeting
{
    public class LowestHpTargetingSystem : ITargetingSystem
    {
        public Character? GetTarget(Team team)
        {
            return team.Members
                .Where(c => c.IsAlive)
                .MinBy(c => c.HP);
        }
    }
}
