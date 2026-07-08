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

Hero hero = new("Hero", 100, 10, 3, 40);

Monster monster1 = new("Monstre1", 50, 6, 5, 30);
Monster monster2 = new("Monstre2", 50, 6, 5, 30);

Team teamHeroes = new("Heroes");
teamHeroes.AddMember(hero);

Team teamMonsters = new("Monsters");
teamMonsters.AddMember(monster1);
teamMonsters.AddMember(monster2);

BasicAttack basicAttack = new();
PowerStrike powerStrike = new();
Heal heal = new();
hero.AddSkill(basicAttack);
hero.AddSkill(powerStrike);
hero.AddSkill(heal);
monster1.AddSkill(basicAttack);
monster1.AddSkill(powerStrike);
monster2.AddSkill(basicAttack);
monster2.AddSkill(powerStrike);

foreach (var item in hero.Skills)
{
    Console.WriteLine(item.Name);
}

CombatLoop combatLoop = new(teamHeroes, teamMonsters);

while (!combatLoop.IsFinished)
{
    combatLoop.Update(0.1);
}

foreach (var entry in combatLoop.FightLog.Entries)
{
    Console.WriteLine(entry);
}

Console.WriteLine("Combat terminé");

var winner = combatLoop.GetWinningTeam();
Console.WriteLine($"Vainqueur : {winner.Name}");

//----------------------------------------------------------------------
