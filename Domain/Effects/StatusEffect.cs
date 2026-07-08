using Auto_Battler.Domain.Stats;

namespace Auto_Battler.Domain.Effects
{
    public abstract class StatusEffect
    {
        public double Duration { get; protected set; }

        public abstract List<IStatModifier> GetModifiers();

        public virtual void Tick(double deltaTime)
        {
            Duration -= deltaTime;
        }

        public bool IsExpired => Duration <= 0;
    }
}
