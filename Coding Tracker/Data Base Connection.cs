using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using Dapper;

namespace Data_Coding_Tracker;

internal class DataBase
{
    
    internal void configuringDataBase()
    {
        var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory()) // get the current file where is being compiled
        .AddJsonFile("appsettings.json"); // add this specific file and interpret it as json file

        var config = builder.Build(); // stores the configs set

        string? connectionString = config["connectionString"];

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



