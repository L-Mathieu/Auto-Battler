namespace Auto_Battler.Domain.Combat.Targeting
{
    public class RandomTargetingSystem : ITargetingSystem
    {
        public Character? GetTarget(Team team)
        {
            var aliveMembers = team.Members
                .Where(c => c.IsAlive)
                .ToList();

            if (aliveMembers.Count == 0)
                return null;

            return aliveMembers[
                Random.Shared.Next(aliveMembers.Count)
            ];
        }
    }
}
