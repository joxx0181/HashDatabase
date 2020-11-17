using System.Data.SqlClient;

namespace HashDatabase
{
    // This class represents Dataverify and implements interface!
    class DataVerify : IData
    {
        // Create connection string!
        private static string connStringV = "server = ZBC-S-JOXX0181\\SQLEXPRESS; database=HashDB; integrated Security=true;";

        // The body of interface method is provided here!
        public string GetSQLquery(string sqlQuery)
        {
            // Asign connection!
            using (SqlConnection conn = new SqlConnection(connStringV))
            {
                string verifySalt = sqlQuery;
                SqlCommand cmd = new SqlCommand(verifySalt, conn);

                // Open connection!
                conn.Open();

                // Executing to get sql record from database!
                SqlDataReader reader = cmd.ExecuteReader();

                // Read sql row!
                while (reader.Read())
                {
                    // Convert sql data to string!
                    sqlQuery = (string)reader["SALT"];
                }
                // Close connection!
                conn.Close();
            }
            // Return a string!
            return sqlQuery;
        }
    }
}
