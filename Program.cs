using Auto_Battler.Application;
using Auto_Battler.Domain;
using Auto_Battler.Domain.Combat;
using Auto_Battler.Domain.Hero;
using Auto_Battler.Domain.Monster;
using Auto_Battler.Domain.Skills;
using static System.Net.Mime.MediaTypeNames;

/// <summary>
/// continuer de suivre ce plan
//1) Nettoyer les dépendances
//✅ supprimer les using inutiles ;
//enlever les Console.WriteLine du Domain.
//2) Créer une couche Application

//Par exemple :

//Application
//└── GameService.cs

//et déplacer progressivement la logique de création de partie dedans.

//3) Préparer la sauvegarde

//Créer :

//Infrastructure
//└── Persistence

//avec un premier :

//SaveRepository.cs
//4) Ajouter SQLite
//
// ProjetAutobattler et bdd ChatGPT
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
/// 
/// </summary>

//----------------------------------------------------------------------
//Test

GameService game = new();

game.Run();

//----------------------------------------------------------------------
