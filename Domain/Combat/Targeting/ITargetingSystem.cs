namespace Auto_Battler.Domain.Combat.Targeting
{
    public interface ITargetingSystem
    {
        Character? GetTarget(Team team);
    }
}
