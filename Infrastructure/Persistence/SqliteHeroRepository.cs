using Auto_Battler.Application.Interfaces;
using Auto_Battler.Application.Models;
using Auto_Battler.Domain.Hero;
using Microsoft.Data.Sqlite;

namespace Auto_Battler.Infrastructure.Persistence
{
    public class SqliteHeroRepository : IHeroRepository
    {
        private const string ConnectionString =
            "Data Source=../../../Data/autobattler.db";

        public void Create(HeroSave hero)
        {
            using var connection =
                new SqliteConnection(ConnectionString);

            connection.Open();

            var command = connection.CreateCommand();

            command.CommandText =
            """
            INSERT INTO Heroes
            (
                Name,
                MaxHP,
                HP,
                BaseAttack,
                BaseDefence,
                BaseSpeed
            )
            VALUES
            (
                $name,
                $maxHp,
                $hp,
                $attack,
                $defence,
                $speed
            );
            """;

            command.Parameters.AddWithValue("$name", hero.Name);
            command.Parameters.AddWithValue("$maxHp", hero.MaxHP);
            command.Parameters.AddWithValue("$hp", hero.HP);
            command.Parameters.AddWithValue("$attack", hero.BaseAttack);
            command.Parameters.AddWithValue("$defence", hero.BaseDefence);
            command.Parameters.AddWithValue("$speed", hero.BaseSpeed);

            command.ExecuteNonQuery();
        }

        public HeroSave? Get(int id)
        {
            using var connection =
                new SqliteConnection(ConnectionString);

            connection.Open();

            var command = connection.CreateCommand();

            command.CommandText =
            """
            SELECT * FROM Heroes WHERE Id = $id
            """;

            command.Parameters.AddWithValue("$id", id);

            using var reader = command.ExecuteReader();

            if (!reader.Read())
            {
                return null;
            }

            HeroSave hero = new HeroSave
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                Name = reader.GetString(reader.GetOrdinal("Name")),
                MaxHP = reader.GetDouble(reader.GetOrdinal("MaxHP")),
                HP = reader.GetDouble(reader.GetOrdinal("HP")),
                BaseAttack = reader.GetDouble(reader.GetOrdinal("BaseAttack")),
                BaseDefence = reader.GetDouble(reader.GetOrdinal("BaseDefence")),
                BaseSpeed = reader.GetDouble(reader.GetOrdinal("BaseSpeed"))
            };

            return hero;
        }

        public void Update(HeroSave hero)
        {
            using var connection =
                new SqliteConnection(ConnectionString);

            connection.Open();

            var command = connection.CreateCommand();

            command.CommandText =
            """
            UPDATE Heroes
            SET
                Name = $name,
                MaxHP = $maxHP,
                HP = $hp,
                BaseAttack = $attack,
                BaseDefence = $defence,
                BaseSpeed = $speed
            WHERE
                Id = $id
            """;

            command.Parameters.AddWithValue("$id", hero.Id);
            command.Parameters.AddWithValue("$name", hero.Name);
            command.Parameters.AddWithValue("$maxHP", hero.MaxHP);
            command.Parameters.AddWithValue("$hp", hero.HP);
            command.Parameters.AddWithValue("$attack", hero.BaseAttack);
            command.Parameters.AddWithValue("$defence", hero.BaseDefence);
            command.Parameters.AddWithValue("$speed", hero.BaseSpeed);

            command.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var connection =
                new SqliteConnection(ConnectionString);

            connection.Open();

            var command = connection.CreateCommand();

            command.CommandText =
            """
            DELETE FROM Heroes WHERE Id = $id
            """;

            command.Parameters.AddWithValue("$id", id);

            command.ExecuteNonQuery();

            //using var reader = command.ExecuteReader();

            //if (!reader.Read())
            //{
            //    throw new InvalidOperationException("Ce personnage ne se trouve pas dans la DB.");
            //}

            //throw new NotImplementedException();
        }
    }
}