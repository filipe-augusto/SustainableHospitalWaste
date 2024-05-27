using System;
using System.Data.SQLite;
using System.IO;

namespace SustainableHospitalWaste.CreateBD
{
    internal class Program
    {
        static void Main(string[] args)
        {
        string databasePath = @"SustainableHospitalWaste.sqlite";
            if (File.Exists(databasePath))
            {
            // File.Delete(databasePath);
            }
            CreateSQLiteDatabase();

        }

        public static void CreateSQLiteDatabase()
        {
            try
            {
                // Cria o arquivo do banco de dados SQLite
                SQLiteConnection.CreateFile(@"..\SustainableHospitalWaste.sqlite");

                using (var connection = new SQLiteConnection("Data Source=SustainableHospitalWaste.sqlite;Version=3;"))
                {
                    connection.Open();

                    // Cria as tabelas
                    string createUsersTable = @"
                        CREATE TABLE IF NOT EXISTS Users (
                            ID INTEGER PRIMARY KEY AUTOINCREMENT,
                            Name TEXT NOT NULL,
                            Email TEXT NOT NULL,
                            Password TEXT NOT NULL
                        );";

                    string createWasteGroupsTable = @"
                        CREATE TABLE IF NOT EXISTS WasteGroups (
                            ID INTEGER PRIMARY KEY AUTOINCREMENT,
                            Name TEXT NOT NULL,
                            Description TEXT
                        );";

                    string createWasteItemsTable = @"
                        CREATE TABLE IF NOT EXISTS WasteItems (
                            ID INTEGER PRIMARY KEY AUTOINCREMENT,
                            Name TEXT NOT NULL,
                            GroupID INTEGER NOT NULL,
                            Description TEXT,
                            FOREIGN KEY (GroupID) REFERENCES WasteGroups(ID)
                        );";

                    string createDisposalReportsTable = @"
                        CREATE TABLE IF NOT EXISTS DisposalReports (
                            ID INTEGER PRIMARY KEY AUTOINCREMENT,
                            UserID INTEGER NOT NULL,
                            ItemID INTEGER NOT NULL,
                            DateTime TEXT NOT NULL,
                            Quantity INTEGER NOT NULL,
                            Remarks TEXT,
                            FOREIGN KEY (UserID) REFERENCES Users(ID),
                            FOREIGN KEY (ItemID) REFERENCES WasteItems(ID)
                        );";

                    // Executa os comandos SQL para criar as tabelas
                    ExecuteNonQuery(connection, createUsersTable);
                    ExecuteNonQuery(connection, createWasteGroupsTable);
                    ExecuteNonQuery(connection, createWasteItemsTable);
                    ExecuteNonQuery(connection, createDisposalReportsTable);

                    Console.WriteLine("Banco de dados e tabelas criados com sucesso.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }

        private static void ExecuteNonQuery(SQLiteConnection connection, string sql)
        {
            using (var command = new SQLiteCommand(sql, connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }
}
