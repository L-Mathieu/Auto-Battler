using Auto_Battler.Application.Interfaces;
using Auto_Battler.Application.Mappers;
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

        private List<HeroSave> _heroList;

        private Team _teamHeroes;

        private readonly IHeroRepository _heroRepository;

        private readonly HeroMapper _heroMapper;

        private int _heroSaveId;

        private Monster _monster1;
        private Monster _monster2;

        private Team _teamMonsters;

        private BasicAttack _basicAttack;
        private PowerStrike _powerStrike;
        private Heal _heal;

        public GameService(IHeroRepository heroRepository)
        {
            _heroRepository = heroRepository;
            _heroMapper = new HeroMapper();
        }

        public void StartNewGame()
        {
            string? heroName = null;

            while (string.IsNullOrWhiteSpace(heroName))
            {
                Console.Write("Nom du héros : ");

                heroName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(heroName))
                {
                    Console.WriteLine("Le nom ne peut pas être vide.");
                    Console.WriteLine();
                }
            }

            _hero = new(heroName, 100, 15, 5, 40);

            SaveHero();

            InitializeHeroTeam();

            InitializeSkills();
            AssignSkills();
        }

        public void LoadGame()
        {
            _heroList = _heroRepository.GetAll();

            if (_heroList.Count == 0)
            {
                Console.WriteLine("Aucune sauvegarde disponible.");
                return;
            } 

            if (_heroList.Count == 1)
            {
                _hero = _heroMapper.ToHero(_heroList[0]);
            }
            else
            {
                bool heroSelected = false;

                string? playerChoice = null;

                int index;

                int number = -1;

                while (!heroSelected)
                {
                    Console.WriteLine("Quel personnage voulez-vous charger ?");
                    Console.WriteLine();

                    int count = 1;

                    foreach (var hero in _heroList)
                    {
                        Console.WriteLine($"Pour choisir ce personnage {hero.Name} Level : {hero.Level} entrer {count}");
                        count++;
                    }

                    playerChoice = Console.ReadLine();

                    if (int.TryParse(playerChoice, out number)
                        && number >= 1
                        && number <= _heroList.Count)
                    {
                        heroSelected = true;
                    }
                    else
                    {
                        Console.WriteLine("Veuillez choisir un personnage existant.");
                    }
                }

                index = number - 1;

                _hero = _heroMapper.ToHero(_heroList[index]);
            }

            InitializeHeroTeam();

            InitializeSkills();
            AssignSkills();
        }

        public void Run()
        {
            InitializeMonsterTeam();

            CombatLoop combatLoop = CreateCombat();

            StartCombat(combatLoop);

            UpdateHero();

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

        private void SaveHero()
        {
            _heroSaveId = _heroRepository.Create(_heroMapper.ToHeroSave(_hero));
        }

        private Hero LoadHero(int id)
        {
            return null;
        }

        private void UpdateHero()
        {
            HeroSave heroSave = _heroMapper.ToHeroSave(_hero);

            heroSave.Id = _heroSaveId;

            _heroRepository.Update(heroSave);
        }
    }
}
