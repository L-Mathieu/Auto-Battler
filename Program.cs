using Auto_Battler.Application;
using Auto_Battler.Application.Interfaces;
using Auto_Battler.Application.Models;
using Auto_Battler.Domain.Hero;
using Auto_Battler.Domain.Equipment;
using Auto_Battler.Infrastructure.Persistence;
using Microsoft.Data.Sqlite;

/// <summary>
/// continuer de suivre ce plan
//1) Nettoyer les dépendances
//✅ supprimer les using inutiles ;
//✅ enlever les Console.WriteLine du Domain.
//2) Créer une couche Application

//Par exemple :

//Application
//└── ✅ GameService.cs

//✅ et déplacer progressivement la logique de création de partie dedans.

//3) Préparer la sauvegarde

//Créer :

//Infrastructure
//└── Persistence

//avec un premier :

//SaveRepository.cs
//4) Ajouter SQLite
//
// ProjetAutobattler et bdd ChatGPT

// TODO: Faire évoluer le ciblage pour permettre une stratégie
// adaptée au personnage, à la compétence et à l'état du combat.

/// </summary>
/// 
/// <summary>
/// 
/// Character gère les personnages ;
/// TurnSystem gère les tours ;
/// CombatSystem gère les règles du combat ;
/// CombatLoop orchestre;
/// CombatLog conserve l'historique.
/// 
/// Domain
///     ↓
/// Règles métier du jeu
/// 
/// Application
///     ↓
/// Orchestration / cas d'utilisation
/// 
/// Infrastructure
///     ↓
/// Accès aux données / technologie
/// 
/// Presentation
///     ↓
/// Interaction avec le joueur
/// 
/// Application
///
///HeroSave
///       ↓
///    "quelles données ?"
///
///
///    IHeroRepository
///       ↓
///    "quelles opérations sont nécessaires ?"
///
///
///Infrastructure
///
///    SqliteHeroRepository
///       ↓
///    "comment je fais techniquement ?"
/// 
/// 
/// </summary>

//----------------------------------------------------------------------
//Test
//SQLitePCL.Batteries.Init();

//DatabaseInitializer databaseInitializer = new();
//databaseInitializer.Initialize();

//IHeroRepository repository =
//    new SqliteHeroRepository();

//GameService game =
//    new GameService(repository);

//game.Run();

//----------------------------------------------------------------------

//----------------------------------------------------------------------
//Test CRUD

// CREATE

//HeroSave hero = new()
//{
//    Name = "arthur",
//    Level = 1,
//    MaxHP = 100,
//    HP = 100,
//    BaseAttack = 15,
//    BaseDefence = 5,
//    BaseSpeed = 40
//};

//HeroSave hero = new()
//{
//    Name = "bob",
//    Level = 1,
//    MaxHP = 80,
//    HP = 80,
//    BaseAttack = 20,
//    BaseDefence = 6,
//    BaseSpeed = 41
//};

//SqliteHeroRepository repository = new();

//int id = repository.Create(hero);

//Console.WriteLine($"id créé : {id}");

//HeroSave? loadedhero = repository.Get(id);

//if (loadedhero != null)
//{
//    Console.WriteLine($"nom : {loadedhero.Name}");
//    Console.WriteLine($"niveau : {loadedhero.Level}");
//    Console.WriteLine($"hp : {loadedhero.HP}");
//}

// READ

//SqliteHeroRepository repository = new();

////repository.Delete(1);

//HeroSave? hero = repository.Get(1);

//if (hero != null)
//{
//    Console.WriteLine(hero.Name);
//    Console.WriteLine(hero.HP);
//}
//else
//{
//    Console.WriteLine("Héros introuvable");
//}

// UPDATE

//SqliteHeroRepository repository = new();

//HeroSave? heroToUpdate = repository.Get(1);

//if (heroToUpdate != null)
//{
//    heroToUpdate.HP = 50;
//    heroToUpdate.Level = 2;

//    repository.Update(heroToUpdate);
//}

//HeroSave? updatedHero = repository.Get(1);

//Console.WriteLine(updatedHero.HP);
//Console.WriteLine(updatedHero.Level);

// DELETE

//SqliteHeroRepository repository = new();

//repository.Delete(1);

//HeroSave? deletedHero = repository.Get(1);

//Console.WriteLine(deletedHero == null);

//SqliteHeroRepository repository = new();
//repository.ResetTable();

//GETALL

//SqliteHeroRepository repository = new();

//List<HeroSave>list = new List<HeroSave>();

//list = repository.GetAll();

//foreach (var item in list)
//{
//    Console.WriteLine($"nom : {item.Name}");
//    Console.WriteLine($"niveau : {item.Level}");
//    Console.WriteLine($"hp : {item.HP}");
//}

//----------------------------------------------------------------------
//IHeroRepository repository =
//    new SqliteHeroRepository();

//GameService game =
//    new GameService(repository);
//game.MainMenu();

Hero warriorLvl3 = new("Warrior", HeroClass.Warrior, 100, 15, 5, 40);
warriorLvl3.LevelUp();
warriorLvl3.LevelUp();
Hero warriorLvl10 = new("Warrior", HeroClass.Warrior, 100, 15, 5, 40);
warriorLvl10.LevelUp();
warriorLvl10.LevelUp();
warriorLvl10.LevelUp();
warriorLvl10.LevelUp();
warriorLvl10.LevelUp();
warriorLvl10.LevelUp();
warriorLvl10.LevelUp();
warriorLvl10.LevelUp();
warriorLvl10.LevelUp();
Hero mageLvl10 = new("Mage", HeroClass.Mage, 100, 15, 5, 40);
mageLvl10.LevelUp();
mageLvl10.LevelUp();
mageLvl10.LevelUp();
mageLvl10.LevelUp();
mageLvl10.LevelUp();
mageLvl10.LevelUp();
mageLvl10.LevelUp();
mageLvl10.LevelUp();
mageLvl10.LevelUp();
Console.WriteLine($"Name : {warriorLvl3.Name}");
Console.WriteLine($"Lvl : {warriorLvl3.Level}");
string equipementwarriorLvl3;
if(warriorLvl3.Equipment != null)
{
    equipementwarriorLvl3 = warriorLvl3.Equipment.Name;
}
else
{
    equipementwarriorLvl3 = "Pas d'equipement";
}
Console.WriteLine($"Equipement : {equipementwarriorLvl3}");

Console.WriteLine($"Name : {warriorLvl10.Name}");
Console.WriteLine($"Lvl : {warriorLvl10.Level}");
string equipementwarriorLvl10;
if (warriorLvl10.Equipment != null)
{
    equipementwarriorLvl10 = warriorLvl10.Equipment.Name;
}
else
{
    equipementwarriorLvl10 = "Pas d'equipement";
}
Console.WriteLine($"Equipement : {equipementwarriorLvl10}");

Console.WriteLine($"Name : {mageLvl10.Name}");
Console.WriteLine($"Lvl : {mageLvl10.Level}");
string equipementmageLvl10;
if (mageLvl10.Equipment != null)
{
    equipementmageLvl10 = mageLvl10.Equipment.Name;
}
else
{
    equipementmageLvl10 = "Pas d'equipement";
}
Console.WriteLine($"Equipement : {equipementmageLvl10}");

EquipmentItem swordLvl5 = new("Sword", 5, HeroClass.Warrior, 10);

EquipResult equipResultSwordWariorLvl3 = warriorLvl3.Equip(swordLvl5);
EquipResult equipResultSwordWariorLvl10 = warriorLvl10.Equip(swordLvl5);
EquipResult equipResultSwordmageLvl10 = mageLvl10.Equip(swordLvl5);

Console.WriteLine($"Name : {warriorLvl3.Name}");
Console.WriteLine($"Lvl : {warriorLvl3.Level}");
Console.WriteLine($"EquipResult : {equipResultSwordWariorLvl3}");

if (warriorLvl3.Equipment != null)
{
    equipementwarriorLvl3 = warriorLvl3.Equipment.Name;
}
else
{
    equipementwarriorLvl3 = "Pas d'equipement";
}
Console.WriteLine($"Equipement : {equipementwarriorLvl3}");

Console.WriteLine($"Name : {warriorLvl10.Name}");
Console.WriteLine($"Lvl : {warriorLvl10.Level}");
Console.WriteLine($"EquipResult : {equipResultSwordWariorLvl10}");

if (warriorLvl10.Equipment != null)
{
    equipementwarriorLvl10 = warriorLvl10.Equipment.Name;
}
else
{
    equipementwarriorLvl10 = "Pas d'equipement";
}
Console.WriteLine($"Equipement : {equipementwarriorLvl10}");

Console.WriteLine($"Name : {mageLvl10.Name}");
Console.WriteLine($"Lvl : {mageLvl10.Level}");
Console.WriteLine($"EquipResult : {equipResultSwordmageLvl10}");

if (mageLvl10.Equipment != null)
{
    equipementmageLvl10 = mageLvl10.Equipment.Name;
}
else
{
    equipementmageLvl10 = "Pas d'equipement";
}
Console.WriteLine($"Equipement : {equipementmageLvl10}");

EquipmentItem staffLvl5 = new("Staff", 5, HeroClass.Mage, 10);
EquipResult equipResultStaffWariorLvl10 = warriorLvl10.Equip(staffLvl5);

Console.WriteLine($"Name : {warriorLvl10.Name}");
Console.WriteLine($"Lvl : {warriorLvl10.Level}");
Console.WriteLine($"EquipResult : {equipResultStaffWariorLvl10}");

if (warriorLvl10.Equipment != null)
{
    equipementwarriorLvl10 = warriorLvl10.Equipment.Name;
}
else
{
    equipementwarriorLvl10 = "Pas d'equipement";
}
Console.WriteLine($"Equipement : {equipementwarriorLvl10}");