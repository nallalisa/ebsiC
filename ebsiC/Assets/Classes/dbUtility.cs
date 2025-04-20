using ebsiC.Assets.MVVM.Model;
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
                string query = @"SELECT COUNT(1) FROM users WHERE username = @username AND passwordHash = @password";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count == 1;
                }
            }
        }
        public static bool AddEmployee(Employee emp)
        {
            using (var conn = GetConnection())
            {
                string query = @"INSERT INTO employees (
                employeeID,
                firstName,
                middleName,
                lastName,
                jobTitleID,
                departmentID,
                dateHired,
                email,
                phoneNumber,
                sssNumber,
                philHealthNumber,
                pagIbigNumber,
                tinNumber,
                status
            ) VALUES (
                @employeeID,
                @firstName,
                @middleName,
                @lastName,
                @jobTitleID,
                @departmentID,
                @dateHired,
                @email,
                @phoneNumber,
                @sssNumber,
                @philHealthNumber,
                @pagIbigNumber,
                @tinNumber,
                @status
            );";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@employeeID", emp.EmployeeID);
                    cmd.Parameters.AddWithValue("@firstName", emp.FirstName);
                    cmd.Parameters.AddWithValue("@middleName", string.IsNullOrEmpty(emp.MiddleName) ? DBNull.Value : emp.MiddleName);
                    cmd.Parameters.AddWithValue("@lastName", emp.LastName);
                    cmd.Parameters.AddWithValue("@jobTitleID", emp.JobTitleID);
                    cmd.Parameters.AddWithValue("@departmentID", emp.DepartmentID);
                    cmd.Parameters.AddWithValue("@dateHired", emp.DateHired);
                    cmd.Parameters.AddWithValue("@email", string.IsNullOrEmpty(emp.Email) ? DBNull.Value : emp.Email);
                    cmd.Parameters.AddWithValue("@phoneNumber", emp.PhoneNumber == 0 ? DBNull.Value : emp.PhoneNumber);
                    cmd.Parameters.AddWithValue("@sssNumber", string.IsNullOrEmpty(emp.SSSNumber) ? DBNull.Value : emp.SSSNumber);
                    cmd.Parameters.AddWithValue("@philHealthNumber", string.IsNullOrEmpty(emp.PhilHealthNumber) ? DBNull.Value : emp.PhilHealthNumber);
                    cmd.Parameters.AddWithValue("@pagIbigNumber", string.IsNullOrEmpty(emp.PagIbigNumber) ? DBNull.Value : emp.PagIbigNumber);
                    cmd.Parameters.AddWithValue("@tinNumber", string.IsNullOrEmpty(emp.TinNumber) ? DBNull.Value : emp.TinNumber);
                    cmd.Parameters.AddWithValue("@status", string.IsNullOrEmpty(emp.Status) ? DBNull.Value : emp.Status);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SQLiteException ex)
                    {
                        Console.WriteLine($"SQLite Error: {ex.Message}");
                        return false;
                    }
                }
            }
        }
    }
}
