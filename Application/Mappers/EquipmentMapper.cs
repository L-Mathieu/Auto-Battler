using Auto_Battler.Application.Models;
using Auto_Battler.Domain.Equipment;

namespace Auto_Battler.Application.Mappers
{
    public class EquipmentMapper
    {
        public EquipmentItem ToEquipmentItem(EquipmentSave equipmentSave)
        {
            return new EquipmentItem
            (
                equipmentSave.Name,
                equipmentSave.Level,
                equipmentSave.RequiredLevel,
                equipmentSave.EquipType,
                equipmentSave.RequiredClass,
                equipmentSave.AttackBonus,
                equipmentSave.DefenceBonus,
                equipmentSave.SpeedBonus
            );
        }

        public EquipmentSave ToEquipmentSave(EquipmentItem equipmentItem)
        {
            return new EquipmentSave
            {
                Name = equipmentItem.Name,
                Level = equipmentItem.Level,
                RequiredLevel = equipmentItem.RequiredLevel,
                EquipType = equipmentItem.EquipType,
                RequiredClass = equipmentItem.RequiredClass,
                AttackBonus = equipmentItem.AttackBonus,
                DefenceBonus = equipmentItem.DefenceBonus,
                SpeedBonus = equipmentItem.SpeedBonus
            };
        }
    }
}
