using Auto_Battler.Application.Models;

namespace Auto_Battler.Application.Interfaces
{
    public interface IHeroRepository
    {
        int Create(HeroSave hero);

        HeroSave? Get(int id);

        void Update(HeroSave hero);

        void Delete(int id);
    }
}
