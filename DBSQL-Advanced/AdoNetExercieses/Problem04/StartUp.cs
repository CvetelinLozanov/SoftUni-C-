using AdoNetExercises;
using System;
using System.Data.SqlClient;

namespace Problem04
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] minionInput = Console.ReadLine()
                .Split();
            string[] villainInfo = Console.ReadLine()
                .Split();

            string minionName = minionInput[1];
            int age = int.Parse(minionInput[2]);
            string townName  = minionInput[3];

            string villainName = villainInfo[1];

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                SqlTransaction transaction = connection.BeginTransaction();

                int? townId = GetTownByName(townName, connection);

                if (townId == null)
                {
                    AddTown(connection, townName);
                }

                townId = GetTownByName(townName, connection);

                AddMinion(connection, minionName, age, townId);

                int? villainId = GetVillainId(connection, villainName);

                if (villainId == null)
                {
                    AddVillain(connection, villainName);
                }

                villainId = GetVillainId(connection, villainName);
                int minionId = GetMinionIdByName(connection, minionName);
                AddMinionVillain(connection, villainId, minionId, minionName, villainName);
            }
        }

        private static void AddMinionVillain(SqlConnection connection, int? villainId, int minionId, string minionName, string villainName)
        {
            string insertMinionsVillain = "INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@villainId, @minionId)";

            using (SqlCommand command = new SqlCommand(insertMinionsVillain, connection))
            {
                command.Parameters.AddWithValue("@villainId", villainId);
                command.Parameters.AddWithValue("@minionId", minionId);
                command.ExecuteNonQuery();
            }

            Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}");
        }

        private static int GetMinionIdByName(SqlConnection connection, string minionName)
        {
            string getMinionQuerry = "SELECT Id FROM Minions WHERE Name = @Name";

            using (SqlCommand command = new SqlCommand(getMinionQuerry, connection))
            {
                command.Parameters.AddWithValue("@Name", minionName);
                return (int)command.ExecuteScalar();
            }
        }

        private static void AddVillain(SqlConnection connection, string villainName)
        {
            string insertVillainQuerry = "INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)";

            using (SqlCommand command = new SqlCommand(insertVillainQuerry, connection))
            {
                command.Parameters.AddWithValue("@villainName", villainName);
                command.ExecuteNonQuery();
            }

            Console.WriteLine($"Villain {villainName} was added to the database.");
        }

        private static int? GetVillainId(SqlConnection connection, string villainName)
        {
            string villainIdQuerry = "SELECT Id FROM Villains WHERE Name = @Name";
            using (SqlCommand command = new SqlCommand(villainIdQuerry, connection))
            {
                command.Parameters.AddWithValue("@Name", villainName);
                return (int?)command.ExecuteScalar();
            }
        }

        private static void AddMinion(SqlConnection connection, string minionName, int age, int? townId)
        {
            string insertMinionQuerry = "INSERT INTO Minions(Name, Age, TownId) VALUES(@name, @age, @townId)";

            using (SqlCommand command = new SqlCommand(insertMinionQuerry, connection))
            {
                command.Parameters.AddWithValue("@name", minionName);
                command.Parameters.AddWithValue("@age", age);
                command.Parameters.AddWithValue("@TownId", townId);

                command.ExecuteNonQuery();
            }
        }

        private static int? GetTownByName(string townName, SqlConnection connection)
        {
            string townIdQuerry = "SELECT Id FROM Towns WHERE Name = @townName";
            using (SqlCommand command = new SqlCommand(townIdQuerry, connection))
            {
                command.Parameters.AddWithValue("@townName", townName);
                return (int?)command.ExecuteScalar();              
            }
        }

        private static void AddTown(SqlConnection connection, string townName)
        {
            string insertTownQuerry = "INSERT INTO Towns (Name) VALUES (@townName)";

            using (SqlCommand command = new SqlCommand(insertTownQuerry, connection))
            {
                command.Parameters.AddWithValue("@townName", townName);
                command.ExecuteNonQuery();
            }

            Console.WriteLine($"Town {townName} was added to the database.");
        }
    }
}
