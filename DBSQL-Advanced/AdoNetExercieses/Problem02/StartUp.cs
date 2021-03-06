﻿using AdoNetExercises;
using System;
using System.Data.SqlClient;

namespace Problem02
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();
                string sqlQuerry = @"SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  
                                       FROM Villains AS v 
                                       JOIN MinionsVillains AS mv ON v.Id = mv.VillainId 
                                        GROUP BY v.Id, v.Name 
                                        HAVING COUNT(mv.VillainId) > 3 
                                       ORDER BY COUNT(mv.VillainId)";
                using (SqlCommand command = new SqlCommand(sqlQuerry, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = (string)reader[0];
                            int age = (int)reader[1];

                            Console.WriteLine($"{name} - {age}");
                        }
                    }
                }     
            }
        }
    }
}
