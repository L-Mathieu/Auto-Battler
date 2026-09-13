using Auto_Battler.Application.Models;

namespace Auto_Battler.Application.Interfaces
{
    public interface IEquipmentRepository
    {
        int Create(EquipmentSave equipment);

        EquipmentSave? Get(int id);

        List<EquipmentSave> GetAll();

        void Update(EquipmentSave equipment);

        void Delete(int id);
    }
}
