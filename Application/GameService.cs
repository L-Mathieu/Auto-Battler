using Auto_Battler.Application.Interfaces;
using Auto_Battler.Application.Mappers;
using Auto_Battler.Application.Models;
using Auto_Battler.Domain;
using Auto_Battler.Domain.Combat;
using Auto_Battler.Domain.Combat.Targeting;
using Auto_Battler.Domain.Hero;
using Auto_Battler.Domain.Monster;
using Auto_Battler.Domain.Skills;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public void MainMenu()
        {
            _heroList = _heroRepository.GetAll();

            int choice = 0;

            while (choice == 0)
            {
                ShowMainMenu();

                Console.Write("Que voulez vous faire ? : ");

                var playerChoice = Console.ReadLine();

                if (int.TryParse(playerChoice, out int number)
                    && number >= 1
                    && number <= 3)
                {
                    if (_heroList.Count == 0 && number == 2)
                    {
                        Console.WriteLine("Veuillez choisir une des deux options existantes.");
                    }
                    else
                    {
                        choice = number;
                    }
                }
                else
                {
                    Console.WriteLine("Veuillez choisir une des trois options existantes.");
                }
            }

            switch (choice)
            {
                case 1:
                    StartNewGame();
                    break;
                case 2:
                    LoadGame();
                    break;
                case 3:
                    return;
            }
            Run();
        }

        private void ShowMainMenu()
        {
            Console.Clear();

            Console.WriteLine("========================");
            Console.WriteLine("      AUTO BATTLER      ");
            Console.WriteLine("========================");
            Console.WriteLine();
            Console.WriteLine("1. Nouvelle partie");

            if (_heroList.Count >= 1)
            {
                Console.WriteLine("2. Charger une partie");
            }
            else
            {
                Console.WriteLine("2. Charger une partie (aucune sauvegarde)");
            }
            Console.WriteLine("3. Quitter");
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

            PrepareHero();
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
                _heroSaveId = _heroList[index].Id;
            }

            PrepareHero();
        }

        public void Run()
        {
            InitializeMonsterTeam();
            AssignMonsterSkills();

            CombatLoop combatLoop = CreateCombat();

            StartCombat(combatLoop);

            UpdateHero();

            DisplayResults(combatLoop);
        }

        private void PrepareHero()
        {
            InitializeHeroTeam();
            InitializeSkills();
            AssignHeroSkills();
        }

        private void InitializeHeroTeam()
        {
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

        private void AssignHeroSkills()
        {
            _hero.AddSkill(_basicAttack);
            _hero.AddSkill(_powerStrike);
            _hero.AddSkill(_heal);
        }

        private void AssignMonsterSkills()
        {
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
            Console.WriteLine($"hero : {_hero.Name}");
            HeroSave heroSave = _heroMapper.ToHeroSave(_hero);

            heroSave.Id = _heroSaveId;
            Console.WriteLine($"hero id : {_heroSaveId}");

            _heroRepository.Update(heroSave);
        }
    }
}
