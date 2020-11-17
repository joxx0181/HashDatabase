using System.Data.SqlClient;

namespace HashDatabase
{
    // This class represents Datainsert and implements interface!
    class DataInsert : IData
    {
        // Create connection string!
        private static string connString = "server = ZBC-S-JOXX0181\\SQLEXPRESS; database=HashDB; integrated Security=true;";

        // The body of interface method is provided here!
        public string GetSQLquery(string sqlQuery)
        {
            // Asign connection!
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string sqlQ = sqlQuery;
                SqlCommand cmd = new SqlCommand(sqlQ, conn);

                // Open connection!
                conn.Open();

                // Executing sql statements!
                cmd.ExecuteNonQuery();

                // Close connection!
                conn.Close();
            }
            return sqlQuery;
        }
    }
}
