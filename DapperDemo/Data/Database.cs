using Microsoft.Data.Sqlite;
using System.IO;

namespace DapperDemo.Data
{
    public static class Database
    {
        public static string ConnectionString => "Data Source=./Data/dapperdemo.db";

        public static void Initialize()
        {
            if (!File.Exists("./Data/dapperdemo.db"))
            {
                using (var connection = new SqliteConnection(ConnectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = @"
                        CREATE TABLE Users (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Name TEXT NOT NULL,
                            Age INTEGER NOT NULL
                        )";
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
