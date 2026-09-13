using Microsoft.Data.Sqlite;

namespace Auto_Battler.Infrastructure.Persistence
{
    public class DatabaseInitializer
    {
        private const string ConnectionString =
            "Data Source=../../../Data/autobattler.db";

        public void Initialize()
        {
            CreateHeroesTable();
            CreateEquipmentItemTable();
        }

        public void CreateHeroesTable()
        {
            using var connection =
                new SqliteConnection(ConnectionString);

            connection.Open();

            var command = connection.CreateCommand();

            command.CommandText =
            """
            CREATE TABLE IF NOT EXISTS Heroes
            (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Name TEXT NOT NULL,
                Level INTEGER NOT NULL,
                MaxHP REAL NOT NULL,
                HP REAL NOT NULL,
                BaseAttack REAL NOT NULL,
                BaseDefence REAL NOT NULL,
                BaseSpeed REAL NOT NULL
            );
            """;

            command.ExecuteNonQuery();


            Console.WriteLine("Table Heroes créée ou déjà existante.");
        }

        public void CreateEquipmentItemTable()
        {
            using var connection =
                new SqliteConnection(ConnectionString);

            connection.Open();

            var command = connection.CreateCommand();

            command.CommandText =
            """
            CREATE TABLE IF NOT EXISTS EquipmentItem
            (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Name TEXT NOT NULL,
                Level INTEGER NOT NULL,
                RequiredLevel INTEGER NOT NULL,
                EquipType INTEGER NOT NULL,
                AttackBonus REAL NOT NULL,
                DefenceBonus REAL NOT NULL,
                SpeedBonus REAL NOT NULL
            );
            """;

            command.ExecuteNonQuery();


            Console.WriteLine("Table EquipmentItem créée ou déjà existante.");
        }
    }
}