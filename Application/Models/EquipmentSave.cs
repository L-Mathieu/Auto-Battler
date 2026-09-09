using Auto_Battler.Domain.Equipment;
using Auto_Battler.Domain.Hero;

namespace Auto_Battler.Application.Models
{
    public class EquipmentSave
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int Level { get; set; }

        public int RequiredLevel { get; set; }

        public EquipType EquipType { get; set; }

        public HeroClass RequiredClass { get; set; }

        public double AttackBonus { get; set; }

        public double DefenceBonus { get; set; }

        public double SpeedBonus { get; set; }

    }
}
