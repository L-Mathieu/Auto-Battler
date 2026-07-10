namespace Auto_Battler.Domain.Combat
{
    public interface ITargetingSystem
    {
        Character GetTarget(Team team);
    }
}
