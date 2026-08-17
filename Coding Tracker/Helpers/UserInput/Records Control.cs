using Dapper;
using Microsoft.Data.Sqlite;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Globalization;

namespace Coding_Tracker.Helpers.UserInput
{
    internal class Records_Control
    {
        internal string? ConnectionString { get; set; }

        internal Records_Control(string stringConnection)
        {
            this.ConnectionString = stringConnection;
        }


        internal static DateTime getHourDate()
        {
            string? stringInput = Console.ReadLine();
            DateTime validDate;

            while (string.IsNullOrEmpty(stringInput) || !DateTime.TryParseExact(stringInput, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out validDate))
            {
                Console.WriteLine("Invalid Format Hour. Try Again! Insert like Ex: 17/08/2026 11:30");
                stringInput = Console.ReadLine();
            }

            return validDate;
        }


        internal void insertionOfStartTimeEndTime(string stringConnection)
        {
            // getting the start & end hours

            Console.WriteLine("Insert the beginning hour (ex: 17/08/2026 13:30) : ");
            DateTime startHour;
            startHour = getHourDate();

            Console.WriteLine("Insert the final hour (ex: 17/08/2026 17:30) : ");
            DateTime finalHour = getHourDate();

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
                    Start = startHour,
                    End = finalHour,
                    Dur = duration
                });
            }

            Console.WriteLine("\nRecord inserted successfully! Press Enter");
            Console.ReadKey();
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

                Console.WriteLine("\nPress Enter");
                Console.ReadKey();

            }


        }
    }
}


