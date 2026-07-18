using Auto_Battler.Application.Interfaces;
using Auto_Battler.Application.Models;
using Auto_Battler.Domain;
using Auto_Battler.Domain.Combat;
using Auto_Battler.Domain.Combat.Targeting;
using Auto_Battler.Domain.Hero;
using Auto_Battler.Domain.Monster;
using Auto_Battler.Domain.Skills;

namespace Auto_Battler.Application
{
    public class GameService
    {
        private Hero _hero;

        private Team _teamHeroes;

        private readonly IHeroRepository _heroRepository;

        private Monster _monster1;
        private Monster _monster2;

        private Team _teamMonsters;

        private BasicAttack _basicAttack;
        private PowerStrike _powerStrike;
        private Heal _heal;

        public GameService(IHeroRepository heroRepository)
        {
            _heroRepository = heroRepository;
        }

        public void Run()
        {
            InitializeTeam();
            InitializeSkills();
            AssignSkills();

            CombatLoop combatLoop = CreateCombat();

            StartCombat(combatLoop);

            DisplayResults(combatLoop);
        }

        private void InitializeTeam()
        {
            InitializeHeroTeam();
            InitializeMonsterTeam();
        }

        private void InitializeHeroTeam()
        {
            _hero = new("Hero", 100, 10, 3, 40);

            _teamHeroes = new("Heroes");

            _teamHeroes.AddMember(_hero);
        }

        private void InitializeMonsterTeam()
        {
            _monster1 = new("Monstre1", 50, 6, 5, 30);
            _monster2 = new("Monstre2", 50, 6, 5, 30);

            _teamMonsters = new("Monsters");

            _teamMonsters.AddMember(_monster1);
            _teamMonsters.AddMember(_monster2);
        }

        public void InitializeSkills()
        {
            _basicAttack = new BasicAttack();
            _powerStrike = new PowerStrike();
            _heal = new Heal();
        }

        private void AssignSkills()
        {
            _hero.AddSkill(_basicAttack);
            _hero.AddSkill(_powerStrike);
            _hero.AddSkill(_heal);
            _monster1.AddSkill(_basicAttack);
            _monster1.AddSkill(_powerStrike);
            _monster2.AddSkill(_basicAttack);
            _monster2.AddSkill(_powerStrike);
        }

        private CombatLoop CreateCombat()
        {
            return new CombatLoop(_teamHeroes, _teamMonsters, new RandomTargetingSystem());
        }

        private void StartCombat(CombatLoop combatLoop)
        {
            while (!combatLoop.IsFinished)
            {
                combatLoop.Update(0.1);
            }
        }

        private void DisplayResults(CombatLoop combatLoop)
        {
            Console.WriteLine("Le combat commence");

            foreach (var entry in combatLoop.FightLog.Entries)
            {
                Console.WriteLine(entry);
            }

            Console.WriteLine("Combat terminé");

            var winner = combatLoop.GetWinningTeam();
            Console.WriteLine($"Vainqueur : {winner.Name}");
        }

        private HeroSave CreateHeroSave()
        {
            return new HeroSave
            {
                Name = _hero.Name,
                Level = _hero.Level,
                MaxHP = _hero.MaxHP,
                HP = _hero.HP,
                BaseAttack = _hero.BaseAttack,
                BaseDefence = _hero.BaseDefence,
                BaseSpeed = _hero.BaseSpeed
            };
        }
    }
}
