namespace Auto_Battler.Infrastructure.Log.CombatLog
{
    public class CombatLog
    {
        private readonly List<CombatEvent> _entries;
        public IReadOnlyList<CombatEvent> Entries => _entries;

        public CombatLog()
        {
            _entries = new List<CombatEvent>();
        }

        public void Add(CombatEvent entry)
        {
            _entries.Add(entry);
        }
    }
}
