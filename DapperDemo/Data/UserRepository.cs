using Dapper;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;
using System.Linq;

namespace DapperDemo.Data
{
    public class UserRepository
    {
        public void AddUser(User user)
        {
            using (var connection = new SqliteConnection(Database.ConnectionString))
            {
                connection.Open();
                string query = "INSERT INTO Users (Name, Age) VALUES (@Name, @Age)";
                connection.Execute(query, user);
            }
        }

        public List<User> GetAllUsers()
        {
            using (var connection = new SqliteConnection(Database.ConnectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Users";
                return connection.Query<User>(query).ToList();
            }
        }

        public User GetUserById(int id)
        {
            using (var connection = new SqliteConnection(Database.ConnectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Users WHERE Id = @Id";
                return connection.QuerySingleOrDefault<User>(query, new { Id = id });
            }
        }

        public void UpdateUser(User user)
        {
            using (var connection = new SqliteConnection(Database.ConnectionString))
            {
                connection.Open();
                string query = "UPDATE Users SET Name = @Name, Age = @Age WHERE Id = @Id";
                connection.Execute(query, user);
            }
        }

        public void DeleteUser(int id)
        {
            using (var connection = new SqliteConnection(Database.ConnectionString))
            {
                connection.Open();
                string query = "DELETE FROM Users WHERE Id = @Id";
                connection.Execute(query, new { Id = id });
            }
        }
    }
}
