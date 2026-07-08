namespace Auto_Battler.Domain.Stats
{
    public class StatModifier : IStatModifier
    {
        public StatType Stat { get; }
        public ModifierType ModifierType { get; }
        public double Value { get; }

        public StatModifier(StatType stat, ModifierType type, double value)
        {
            Stat = stat;
            ModifierType = type;
            Value = value;
        }
    }
}
