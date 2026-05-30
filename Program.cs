using Auto_Battler.Combat;
using Auto_Battler.Core;
using Auto_Battler.Core.Hero;
using Auto_Battler.Core.Monster;

/// <summary>
/// Faire log propre voir dernier prompt chatgpt dans Avis sur la classe Character
/// </summary>

Hero hero = new ("Hero", 100, 10, 3, 40);
Monster monster1 = new ("Monstre1", 50, 6, 5, 30);
Monster monster2 = new ("Monstre2", 60, 5, 6, 30);
Team heroes = new("Heroes");
heroes.AddMember(hero);
Team monsters = new("Monster");
monsters.AddMember(monster1);
monsters.AddMember(monster2);

CombatSystem combatSystem = new(heroes, monsters);
CombatLoop combatLoop = new(combatSystem);

