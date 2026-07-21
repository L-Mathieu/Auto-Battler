using Auto_Battler.Application.Models;
using Auto_Battler.Domain.Hero;

namespace Auto_Battler.Application.Mappers
{
    public class HeroMapper
    {
        public Hero ToHero(HeroSave heroSave)
        {
            return new Hero
            (
                heroSave.Name,
                heroSave.Level,
                heroSave.MaxHP,
                heroSave.HP,
                heroSave.BaseAttack,
                heroSave.BaseDefence,
                heroSave.BaseSpeed
            );
        }

        public HeroSave ToHeroSave(Hero hero)
        {
            return new HeroSave
            {
                Name = hero.Name,
                Level = hero.Level,
                MaxHP = hero.MaxHP,
                HP = hero.HP,
                BaseAttack = hero.BaseAttack,
                BaseDefence = hero.BaseDefence,
                BaseSpeed = hero.BaseSpeed
            };
        }
    }
}
