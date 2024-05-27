using SustainableHospitalWaste.Data.Interfaces;
using SustainableHospitalWaste.Entities;
using System;
using System.Collections.Generic;
using System.Data.SQLite;


namespace SustainableHospitalWaste.Data
{
    internal class WasteGroupData : IWasteGroupData
    {
        public void Create(WasteGroup wasteGroup)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                string sql = "INSERT INTO WasteGroups (Name, Description) VALUES (@Name, @Description)";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Name", wasteGroup.Name);
                    command.Parameters.AddWithValue("@Description", wasteGroup.Description);
                    command.ExecuteNonQuery();
                }
            }
        }

        public WasteGroup Read(int id)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                string sql = "SELECT * FROM WasteGroups WHERE ID = @ID";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new WasteGroup
                            {
                                Id = Convert.ToInt32(reader["ID"]),
                                Name = reader["Name"].ToString(),
                                Description = reader["Description"].ToString()
                            };
                        }
                    }
                }
            }
            return null;
        }

        public List<WasteGroup> ReadAll()
        {
            var wasteGroups = new List<WasteGroup>();
            using (var connection = DatabaseConnection.GetConnection())
            {
                string sql = "SELECT * FROM WasteGroups";
                using (var command = new SQLiteCommand(sql, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        wasteGroups.Add(new WasteGroup
                        {
                            Id = Convert.ToInt32(reader["ID"]),
                            Name = reader["Name"].ToString(),
                            Description = reader["Description"].ToString()
                        });
                    }
                }
            }
            return wasteGroups;
        }

        public void Update(WasteGroup wasteGroup)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                string sql = "UPDATE WasteGroups SET Name = @Name, Description = @Description WHERE ID = @ID";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@ID", wasteGroup.Id);
                    command.Parameters.AddWithValue("@Name", wasteGroup.Name);
                    command.Parameters.AddWithValue("@Description", wasteGroup.Description);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                string sql = "DELETE FROM WasteGroups WHERE ID = @ID";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
