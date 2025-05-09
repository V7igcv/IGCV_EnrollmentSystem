using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDP_WinProject102
{
    internal class DBManager
    {
        private readonly string connectionString = "server=localhost; database=enrollment; uid=root; pwd=villamecantos974;";

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        // Check credentials during login
        public bool AuthenticateUser(string email, string password)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM users WHERE email = @Email AND password = @Password AND deleted_at IS NULL";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password); // Hashing is recommended in production!
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count == 1;
                }
            }
        }

        // Register a new user
        public void RegisterUser(string firstName, string lastName, string email, string password, DateTime recoveryBirthdate)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string query = @"
                    INSERT INTO users (first_name, last_name, email, password, recovery_birthdate, created_at)
                    VALUES (@FirstName, @LastName, @Email, @Password, @RecoveryBirthdate, NOW())";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@LastName", lastName);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password); // Consider hashing!
                    cmd.Parameters.AddWithValue("@RecoveryBirthdate", recoveryBirthdate);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Check if email already exists
        public bool EmailExists(string email)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM users WHERE email = @Email AND deleted_at IS NULL";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        public string GetFirstName(string email)
        {
            string firstName = "";

            using (var conn = GetConnection())
            {
                conn.Open();
                string query = "SELECT first_name FROM users WHERE email = @Email";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        firstName = result.ToString();
                    }
                }
            }

            return firstName;
        }

        public bool VerifyRecoveryInfo(string email, DateTime birthdate)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM users WHERE email = @Email AND recovery_birthdate = @Birthdate AND deleted_at IS NULL";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Birthdate", birthdate);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count == 1;
                }
            }
        }

        public void UpdatePassword(string email, string newPassword)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE users SET password = @Password WHERE email = @Email";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Password", newPassword); // Use hash in production!
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
