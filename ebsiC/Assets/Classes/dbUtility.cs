using NPOI.SS.Formula.Functions;
using System.Data.SQLite;

namespace ebsiC.Assets.Classes
{
    public static class dbUtility
    {
        private static readonly string connectionString = @"Data Source=ebsiDB.db;Version=3;";

        public static SQLiteConnection GetConnection()
        {
            var connection = new SQLiteConnection(connectionString);
            connection.Open();

            using (var command = new SQLiteCommand("PRAGMA foreign_keys = ON;", connection))
            {
                command.ExecuteNonQuery();
            }

            return connection;
        }
        public static bool ValidateUser(string username, string password)
        {
            using (var conn = GetConnection())
            {
                string query = "SELECT COUNT(1) FROM users WHERE username = @username AND password = @password";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count == 1;
                }
            }
        }

    }
}
