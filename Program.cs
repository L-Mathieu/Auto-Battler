using Auto_Battler.Application;
using Auto_Battler.Application.Models;
using Auto_Battler.Infrastructure.Persistence;

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

//GameService game = new();

//game.Run();

//----------------------------------------------------------------------

//----------------------------------------------------------------------
//Test CRUD

// CREATE

//HeroSave hero = new()
//{
//    Name = "Arthur",
//    MaxHP = 100,
//    HP = 100,
//    BaseAttack = 15,
//    BaseDefence = 5,
//    BaseSpeed = 40
//};

//SqliteHeroRepository repository = new();

//repository.Create(hero);

// READ

SqliteHeroRepository repository = new();

HeroSave? hero = repository.Get(1);

if (hero != null)
{
    Console.WriteLine(hero.Name);
    Console.WriteLine(hero.HP);
}
else
{
    Console.WriteLine("Héros introuvable");
}

//----------------------------------------------------------------------
