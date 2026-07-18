using Microsoft.Data.Sqlite;

namespace Auto_Battler.Infrastructure.Persistence
{
    public class DatabaseInitializer
    {
        private const string ConnectionString =
            "Data Source=../../../Data/autobattler.db";

        public void Initialize()
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
    }
}