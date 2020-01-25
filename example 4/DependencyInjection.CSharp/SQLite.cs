using Microsoft.Data.Sqlite;

namespace DependencyInjection.CSharp
{
    public class SQLite : IDatabase
    {
        private readonly string _fileName;
        private string _connectionString;

        private bool IsSetup { get; set; }
        public SQLite(string fileName)
        {
            _fileName = fileName;
        }

        private void Setup()
        {
            SqliteConnectionStringBuilder builder = new SqliteConnectionStringBuilder();
            builder.Mode = SqliteOpenMode.ReadWriteCreate;
            builder.DataSource = _fileName;
            _connectionString = builder.ToString();
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();
            string sql = "CREATE TABLE IF NOT EXISTS DOCUMENT ( ID INTEGER, NAME VARCHAR(1), PRIMARY KEY(ID) )";
            SqliteCommand command = new SqliteCommand(sql, connection);
            command.ExecuteNonQuery();
            IsSetup = true;
        }

        public int NextDocumentId()
        {
            if (IsSetup == false)
            {
                Setup();
            }

            using var connection = new SqliteConnection(_connectionString);
            connection.Open();
            string sql = "INSERT INTO DOCUMENT (NAME) VALUES ('N')";
            SqliteCommand command = new SqliteCommand(sql, connection);
            command.ExecuteNonQuery();
            connection.Close();

            using var readConnection = new SqliteConnection(_connectionString);
            readConnection.Open();
            SqliteCommand get = new SqliteCommand("SELECT ID FROM DOCUMENT ORDER BY ID DESC LIMIT 1", readConnection);
            var reader = get.ExecuteScalar() as long?;
            if (reader.HasValue)
            {
                return (int)reader.Value;
            }
            return -1;
        }
    }
}