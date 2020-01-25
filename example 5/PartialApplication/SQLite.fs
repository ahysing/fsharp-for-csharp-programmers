module SQLite

open System
open Microsoft.Data.Sqlite

let setup (fileName:string) =
    let builder = SqliteConnectionStringBuilder()
    builder.Mode <- SqliteOpenMode.ReadWriteCreate
    builder.DataSource <- fileName
    let connectionString = builder.ToString()
    use connection = new SqliteConnection(connectionString)
    connection.Open()
    let sql = "CREATE TABLE IF NOT EXISTS DOCUMENT ( ID INTEGER, NAME VARCHAR(1), PRIMARY KEY(ID) )"
    let command = new SqliteCommand(sql, connection)
    command.ExecuteNonQuery() |> ignore
    (connectionString)

let NextDocumentId (connectionString) =
    use connection = new SqliteConnection(connectionString)
    connection.Open()
    let sql = "INSERT INTO DOCUMENT (NAME) VALUES ('N')"
    let command = new SqliteCommand(sql, connection)
    command.ExecuteNonQuery() |> ignore
    connection.Close()

    use readConnection = new SqliteConnection(connectionString)
    readConnection.Open()
    let get = new SqliteCommand("SELECT ID FROM DOCUMENT ORDER BY ID DESC LIMIT 1", readConnection)
    let reader = (downcast get.ExecuteScalar() : Nullable<int64>)
    if reader.HasValue then
        int32(reader.Value)
    else
        -1
    