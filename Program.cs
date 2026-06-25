using Auto_Battler.Combat;
using Auto_Battler.Core;
using Auto_Battler.Core.Hero;
using Auto_Battler.Core.Monster;
using Auto_Battler.Log.CombatLog;

/// <summary>
/// Continuer le log voir dernier message chatgpt sujet Test Auto Battler
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
//Test 1

//Hero hero = new ("Hero", 100, 10, 3, 40);
//Monster monster1 = new ("Monstre1", 50, 6, 5, 30);
//Monster monster2 = new ("Monstre2", 5, 5, 5, 30);
//Monster monster3 = new ("Monstre3", 5, 5, 5, 30);
//Team teamHeroes = new("Heroes");
//teamHeroes.AddMember(hero);
//Team teamMonsters = new("Monster");
//teamMonsters.AddMember(monster1);
//teamMonsters.AddMember(monster2);
//Team teamMonsters2 = new("Monster2");
//teamMonsters2.AddMember(monster3);

//CombatLoop combatLoop = new(teamHeroes, teamMonsters);


//Console.WriteLine("Hero Stat");
//Console.WriteLine(hero.Name);
//Console.WriteLine(hero.HP);
//Console.WriteLine(hero.Attack);
//Console.WriteLine(hero.Defence);
//Console.WriteLine(hero.Speed);
//Console.WriteLine("-----------");

//Console.WriteLine("Monster1 Stat");
//Console.WriteLine(monster1.Name);
//Console.WriteLine(monster1.HP);
//Console.WriteLine(monster1.Attack);
//Console.WriteLine(monster1.Defence);
//Console.WriteLine(monster1.Speed);
//Console.WriteLine("-----------");

//Console.WriteLine("Monster2 Stat");
//Console.WriteLine(monster2.Name);
//Console.WriteLine(monster2.HP);
//Console.WriteLine(monster2.Attack);
//Console.WriteLine(monster2.Defence);
//Console.WriteLine(monster2.Speed);
//Console.WriteLine("-----------");

//Console.WriteLine("Test d'une equipe");
//Console.WriteLine(teamHeroes.Members.Count);
//Console.WriteLine($"Encore des membre vivant ? {teamHeroes.IsDefeated()}");
//Console.WriteLine("-----------");

//hero.ExecuteAttack(monster1);

//Console.WriteLine($"{monster1.HP}/{monster1.MaxHP} HP");

//hero.ExecuteAttack(monster3);

//Console.WriteLine($"{monster3.HP}/{monster3.MaxHP} HP");
//Console.WriteLine($"Monstre vivant ? {monster3.IsAlive}");
//Console.WriteLine($"Encore des membre vivant ? {teamMonsters2.IsDefeated()}");

//----------------------------------------------------------------------

//----------------------------------------------------------------------
//Test 2

Hero hero = new("Hero", 100, 10, 3, 40);

Monster monster1 = new("Monstre1", 50, 6, 5, 30);
Monster monster2 = new("Monstre2", 50, 6, 5, 30);

Team teamHeroes = new("Heroes");
teamHeroes.AddMember(hero);

Team teamMonsters = new("Monsters");
teamMonsters.AddMember(monster1);
teamMonsters.AddMember(monster2);

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
