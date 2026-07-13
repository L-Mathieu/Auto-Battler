using Auto_Battler.Application.Interfaces;
using Auto_Battler.Application.Models;

namespace Auto_Battler.Infrastructure.Persistence
{
    public class SqliteHeroRepository : IHeroRepository
    {
        public void Create(HeroSave hero)
        {
            throw new NotImplementedException();
        }

        public HeroSave? Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(HeroSave hero)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}