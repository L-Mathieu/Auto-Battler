namespace Auto_Battler.Domain
{
    public class Team
    {
        public string Name { get; }

        private readonly List<Character> _members = new();

        public IReadOnlyList<Character> Members => _members;

        public Team(string name)
        {
            Name = name;
        }

        public void AddMember(Character member)
        {
            if (member.Team == this)
                return;

            member.Team?.RemoveMember(member);

            _members.Add(member);
            member.SetTeam(this);
        }

        public void RemoveMember(Character member)
        {
            if (!_members.Remove(member))
                return;

            member.SetTeam(null);
        }

        public bool IsDefeated()
        {
            return Members.All(c => !c.IsAlive);
        }
    }
}
