using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using Dapper;

namespace Data_Coding_Tracker;

internal class DataBase
{
    
    internal void configuringDataBase(string? connectionString)
    {

        using (var connection = new SqliteConnection((connectionString)))
        {
            connection.Open();

            connection.Execute(@"CREATE TABLE IF NOT EXISTS coding_tracker (
            Id Integer PRIMARY KEY AUTOINCREMENT, 
            StartTime Text, 
            EndTime Text,
            Duration Text)");

            connection.Close();

        }
    }
}



