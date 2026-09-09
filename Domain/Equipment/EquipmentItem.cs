using Auto_Battler.Domain.Hero;

namespace Auto_Battler.Domain.Equipment
{
    public class EquipmentItem
    {
        public string Name { get; }
        public int Level { get; }
        public int RequiredLevel { get; }
        public EquipType EquipType { get; }
        public HeroClass RequiredClass { get; }
        public double AttackBonus { get; }
        public double DefenceBonus { get; }
        public double SpeedBonus {  get; }

        public EquipmentItem(
            string name,
            int requiredLevel,
            EquipType equipType,
            HeroClass requiredClass,
            double attackBonus,
            double defenceBonus,
            double speedBonus)
        {
            Name = name;
            Level = 1;
            RequiredLevel = requiredLevel;
            EquipType = equipType;
            RequiredClass = requiredClass;
            AttackBonus = attackBonus;
            DefenceBonus = defenceBonus;
            SpeedBonus = speedBonus;
        }

        public EquipmentItem(
            string name,
            int level,
            int requiredLevel,
            EquipType equipType,
            HeroClass requiredClass,
            double attackBonus,
            double defenceBonus,
            double speedBonus)
        {
            Name = name;
            Level = level;
            RequiredLevel = requiredLevel;
            EquipType = equipType;
            RequiredClass = requiredClass;
            AttackBonus = attackBonus;
            DefenceBonus = defenceBonus;
            SpeedBonus = speedBonus;
        }
    }
}
