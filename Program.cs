using Auto_Battler.Application;
using Auto_Battler.Application.Interfaces;
using Auto_Battler.Application.Models;
using Auto_Battler.Domain.Hero;
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

