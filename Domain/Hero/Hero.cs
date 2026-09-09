using Auto_Battler.Domain.Equipment;
using System.Security.Claims;

namespace Auto_Battler.Domain.Hero
{
    public class Hero : Character
    {
        public int Level { get; private set; }
        public  HeroClass Class { get; private set; }
        public EquipmentItem? Equipment { get; private set; }

        public Hero(
            string name,
            HeroClass job,
            double maxHp,
            double baseAttack,
            double baseDefence,
            double baseSpeed)
            : base(name, maxHp, baseAttack, baseDefence, baseSpeed)
        {
            Level = 1;
            Class = job;
            Equipment = null;
        }

        public Hero(
            string name,
            int level,
            double maxHp,
            double hp,
            double baseAttack,
            double baseDefence,
            double baseSpeed)
            : base(name, maxHp, hp, baseAttack, baseDefence, baseSpeed)
        {
            Level = level;
        }

        public EquipResult Equip(EquipmentItem equipment)
        {
            if (Level < equipment.RequiredLevel)
            {
                return EquipResult.InsufficientLevel;
            }

            if (Class != equipment.RequiredClass)
            {
                return EquipResult.WrongClass;
            }

            Equipment = equipment;

            return EquipResult.Success;
        }

        public void LevelUp()
        {
            Level += 1;
        }
    }
}
