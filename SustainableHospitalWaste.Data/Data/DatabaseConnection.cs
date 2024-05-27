using System.Data.SQLite;

namespace SustainableHospitalWaste.Data
{
    public static class DatabaseConnection
    {
        private static readonly string connectionString = @"Data Source=..\SustainableHospitalWaste.sqlite;Version=3;";

        public static SQLiteConnection GetConnection()
        {
            var connection = new SQLiteConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}
