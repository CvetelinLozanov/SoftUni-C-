using AdoNetExercises;
using System;
using System.Data.SqlClient;

namespace Problem06
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int id = int.Parse(Console.ReadLine());
            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();
                string villainQuerry = "SELECT Name FROM Villains WHERE Id = @villainId";

                string villainName;

                using (SqlCommand command = new SqlCommand(villainQuerry, connection))
                {
                    command.Parameters.AddWithValue("@villainId", id);

                    villainName = (string)command.ExecuteScalar();

                    if (villainName == null)
                    {
                        Console.WriteLine("No such villain was found.");
                        return;
                    }
                }

                int affectedRows = DeleteMinionViilainById(connection, id);
                DeleteVillainById(connection, id);

                Console.WriteLine($"{villainName} was deleted.");
                Console.WriteLine($"{affectedRows} minions were released.");
            }
        }

        private static void DeleteVillainById(SqlConnection connection, int id)
        {
            string deleteVillainQuerry = @"DELETE FROM Villains
      WHERE Id = @villainId";

            using (SqlCommand command = new SqlCommand(deleteVillainQuerry, connection))
            {
                command.Parameters.AddWithValue("@villainId", id);

                command.ExecuteNonQuery();
            }            
        }

        private static int DeleteMinionViilainById(SqlConnection connection, int id)
        {
            string deleteVillainQuerry = @"DELETE FROM MinionsVillains 
      WHERE VillainId = @villainId";

            using (SqlCommand command = new SqlCommand(deleteVillainQuerry, connection))
            {
                command.Parameters.AddWithValue("@villainId", id);

                return (int)command.ExecuteNonQuery();

            }
        }
    }
}
