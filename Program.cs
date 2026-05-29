using Auto_Battler.Combat;
using Auto_Battler.Core;
using Auto_Battler.Core.Hero;
using Auto_Battler.Core.Monster;

/// <summary>
/// 
/// </summary>

Hero hero = new (100, 10, 3, 40);
Monster monster = new ("Monstre1", 50, 6, 5, 30);
Team teamA = new("TeamA");
teamA.AddMember(hero);
Team teamB = new("TeamB");
teamB.AddMember(monster);

