using AdoNetExercises;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace Problem08
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int[] minionIds = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                string updateMinions = @" UPDATE Minions
   SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
 WHERE Id = @Id";
                for (int i = 0; i < minionIds.Length; i++)
                {
                    using (SqlCommand command = new SqlCommand(updateMinions, connection))
                    {
                        command.Parameters.AddWithValue("@Id", minionIds[i]);
                        command.ExecuteNonQuery();
                    }
                }

                string sqlQuerry = "SELECT Name, Age FROM Minions";

                using (SqlCommand command = new SqlCommand(sqlQuerry, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = (string)reader[0];
                            int age = (int)reader[1];
                            Console.WriteLine($"{name} {age}");
                        }
                    }
                }
                
            }
        }
    }
}
