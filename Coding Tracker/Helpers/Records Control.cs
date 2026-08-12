using Coding_Tracker;
using Dapper;
using Microsoft.Data.Sqlite;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Coding_Tracker.Helpers
{
    internal class Records_Control
    {
        internal string? ConnectionString { get; set; }

        internal Records_Control(string stringConnection)
        {
            this.ConnectionString = stringConnection;
        }


        internal static TimeSpan getHour()
        {
            string? stringHour = Console.ReadLine();
            TimeSpan hour;

            while (string.IsNullOrEmpty(stringHour) || !TimeSpan.TryParse(stringHour, out hour))
            {
                Console.WriteLine("Invalid Format Hour. Try Again! Insert like Ex: 14:30");
                stringHour = Console.ReadLine();
            }

            return hour;
        }


        internal void insertionOfStartTimeEndTime(string stringConnection)
        {
            // getting the start & end hours

            Console.WriteLine("Insert the beginning hour (ex: 13:30) : ");
            TimeSpan startHour;
            startHour = getHour();

            Console.WriteLine("Insert the final hour (ex: 17:00) : ");
            TimeSpan finalHour = getHour();

            // duration holds the time that passed
            TimeSpan duration = finalHour - startHour;

            // open DB

            using (var connection = new SqliteConnection(stringConnection))
            {
                connection.Open();

                string insertQuery = @"
            INSERT INTO coding_tracker (StartTime, EndTime, Duration) 
            VALUES (@Start, @End, @Dur)";

                connection.Execute(insertQuery, new
                {
                    Start = startHour.ToString(),
                    End = finalHour.ToString(),
                    Dur = duration.ToString()
                });
            }

            Console.WriteLine("\nRecord inserted successfully!");
        }

        internal void viewTimeRecords(string connectionString)
        {
            Console.Clear();

            using (var connection = new SqliteConnection(connectionString)) // using 
            {
                connection.Open();

                string query = "SELECT * FROM coding_tracker";

                List<CodingSession> tableData = connection.Query<CodingSession>(query).ToList();

                foreach(var session in tableData)
                {
                    Console.WriteLine($@"{session.Id} - Starting Code Time: {session.StartTime} - End Code Time: {session.EndTime} - Duration Session: {session.Duration}");
                }

            }


        }
    }
}


