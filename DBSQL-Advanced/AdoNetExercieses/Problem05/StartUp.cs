using AdoNetExercises;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Problem05
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IList<string> towns = new List<string>();
            string countryName = Console.ReadLine();
            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();
                string updateQuerry = @"UPDATE Towns
   SET Name = UPPER(Name)
 WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";
                using (SqlCommand command = new SqlCommand(updateQuerry, connection))
                {
                    command.Parameters.AddWithValue("@countryName", countryName);
                    int affectedTowns = (int)command.ExecuteNonQuery();
                    Console.WriteLine($"{affectedTowns} town names were affected.");
                }

                string selectTownsQuerry = @" SELECT t.Name 
   FROM Towns as t
   JOIN Countries AS c ON c.Id = t.CountryCode
  WHERE c.Name = @countryName";

                using (SqlCommand command = new SqlCommand(selectTownsQuerry, connection))
                {
                    command.Parameters.AddWithValue(@"countryName", countryName);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            towns.Add((string)reader[0]);
                        }
                    }
                }
            }

            Console.WriteLine("[" + string.Join(", ", towns) + "]");
        }
    }
}
