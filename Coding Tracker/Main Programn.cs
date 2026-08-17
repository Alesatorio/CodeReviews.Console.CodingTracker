using Coding_Tracker;
using Coding_Tracker.Helpers;
using Data_Coding_Tracker;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using System.Collections.Specialized;
using Coding_Tracker.Helpers.TypeHandler;
using Dapper;

SqlMapper.AddTypeHandler(new TypeHandler());

var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory()) // get the current file where is being compiled
        .AddJsonFile("appsettings.json"); // add this specific file and interpret it as json file

var config = builder.Build(); // stores the configs set

string? connectionString = config["connectionString"];

var initializeDataBase = new DataBase();
initializeDataBase.configuringDataBase(connectionString);



var initializeMenu = new User_Interface();
initializeMenu.menuOptions(connectionString);