using System;
using Microsoft.Data.SQLite;
namespace DependencyInjection.CSharp
{
    public class SQLite : IDatabase
    {
        private readonly string _connectionString;
        private bool IsSetup { get; set; }        
        public SQLite(string connectionString)
        {
            _connectionString = connectionString;
        }
        
        private void Setup()
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string sql = "CREATE TABLE DOCUMENT (ID INTEGER AUTOINCREMENT)";
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.ExecuteNonQuery();
                IsSetup = true;
            }
        }

        public int NextDocumentId()
        {
            if (IsSetup == false)
            {
                Setup();
            }

            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string sql = "INSERT INTO DOCUMENT (); SELECT ID FROM DOCUMENT";
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                var reader = command.ExecuteReader();
                return reader.GetInt32(0);
            }
        }
    }
}