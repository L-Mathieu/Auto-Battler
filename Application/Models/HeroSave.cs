namespace Auto_Battler.Application.Models
{
    public class HeroSave
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public double MaxHP { get; set; }

        public double HP { get; set; }

        public double BaseAttack { get; set; }

        public double BaseDefence { get; set; }

        public double BaseSpeed { get; set; }
    }
}
