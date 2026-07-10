namespace Auto_Battler.Domain.Combat
{
    public class TargetingSystem : ITargetingSystem
    {
        public Character GetTarget(Team team)
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
