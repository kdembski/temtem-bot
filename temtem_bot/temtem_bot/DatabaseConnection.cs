using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace temtem_bot
{
    class DatabaseConnection
    {
        //connection string
        readonly static string connectionString = @"Data Source=DESKTOP-5TAUCHM\SQLEXPRESS; database=Temtem; Trusted_Connection=yes;";

        /// <summary>
        /// get training values from database
        /// </summary>
        /// <param name="temName">temtem name which TVs we want</param>
        /// <returns>table of training values</returns>
        public static int[] GetTrainingValues(string temName)
        {
            //array to store training values
            int[] trainingValues = new int[7];

            //cut last two characters from string
            if (temName.Length > 2)
            {
                temName = temName.Substring(0, temName.Length - 2);
            }
            //string contains query to send
            string query = @"SELECT * FROM TrainingValuesView WHERE Name=@temName";
            //connect to database
            using (SqlConnection connection = new SqlConnection(connectionString))
            //send query
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                //add functions parameter to query
                command.Parameters.Add("@temName", SqlDbType.VarChar).Value = temName;
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    //while there is still something to read
                    while (reader.Read())
                    {
                        for (int i = 0; i < 7; i++)
                        {
                            //assign values from database to array
                            trainingValues[i] = Int32.Parse(reader[i + 1].ToString());
                        }
                    }
                    reader.Close();
                }
                connection.Close();
            }

            return trainingValues;
        }
    }
}
