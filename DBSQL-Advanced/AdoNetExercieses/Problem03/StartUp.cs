﻿using AdoNetExercises;
using System;
using System.Data.SqlClient;

namespace Problem03
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int id = int.Parse(Console.ReadLine());
            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();
                string villainNameQuerry = "SELECT Name FROM Villains WHERE Id = @Id";
                

                using (SqlCommand command = new SqlCommand(villainNameQuerry, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    string villainName = (string)command.ExecuteScalar();

                    if (villainName == null)
                    {
                        Console.WriteLine($"No villain with ID {id} exists in the database.");
                    }
                    Console.WriteLine($"Villain: {villainName}");
                }

                string minionsQuerry = @"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) as RowNum,
                                         m.Name, 
                                         m.Age
                                    FROM MinionsVillains AS mv
                                    JOIN Minions As m ON mv.MinionId = m.Id
                                   WHERE mv.VillainId = @Id
                                ORDER BY m.Name";
                using (SqlCommand command = new SqlCommand(minionsQuerry, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        
                        while (reader.Read())
                        {
                            long rowNumber = (long)reader[0];
                            string name = (string)reader[1];
                            int age = (int)reader[2];
                            Console.WriteLine($"{rowNumber}. {name} {age}");
                        }
                        if (!reader.HasRows)
                        {
                            Console.WriteLine("No minions");
                        }
                    }
                }
            }
        }
    }
}
