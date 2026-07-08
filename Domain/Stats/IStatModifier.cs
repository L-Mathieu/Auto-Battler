namespace Auto_Battler.Domain.Stats
{
    public interface IStatModifier
    {
        StatType Stat { get; }
        ModifierType ModifierType { get; }
        double Value { get; }
    }
}
