using Auto_Battler.Domain.Stats;

namespace Auto_Battler.Domain.Effects
{
    public class BattleFuryEffect : StatusEffect
    {
        private readonly List<IStatModifier> _mods;

        public BattleFuryEffect(double duration)
        {
            Duration = duration;

            _mods = new List<IStatModifier>
        {
            new StatModifier(StatType.Attack, ModifierType.Multiplicative, 0.30),
            new StatModifier(StatType.Speed, ModifierType.Multiplicative, 0.15)
        };
        }

        public override List<IStatModifier> GetModifiers() => _mods;
    }
}
