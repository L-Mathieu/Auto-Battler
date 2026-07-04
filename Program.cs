using Auto_Battler.Combat;
using Auto_Battler.Core;
using Auto_Battler.Core.Hero;
using Auto_Battler.Core.Monster;
using Auto_Battler.Log.CombatLog;
using Auto_Battler.Skills;

/// <summary>
/// continuer de suivre ce plan
//✅ BasicAttack
//✅ PowerStrike
//✅ Heal (même très simple)
//✅ Modifier le ciblage pour permettre TargetType.Ally
//✅ Constater que Heal est utilisé n'importe quand
//Remplacer Priority par GetPriority()
//Ajouter une vraie logique d'IA
/// Modifier le ciblage pour permettre TargetType.Ally voir dernier message de chatgpt dans sujet Systeme de compétence auto battler
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
