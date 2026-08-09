using Coding_Tracker.Helpers;
using Data_Coding_Tracker;
using Microsoft.Data.Sqlite;
using System.Collections.Specialized;
using Coding_Tracker;

var initializeDataBase = new DataBase();
initializeDataBase.configuringDataBase();

var initializeMenu = new User_Interface();
initializeMenu.menuOptions(string connectionString);