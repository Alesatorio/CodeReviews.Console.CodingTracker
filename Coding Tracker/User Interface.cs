using Coding_Tracker.Helpers.UserInput;

namespace Coding_Tracker
{
    internal class User_Interface
    {
        internal void menuOptions(string connectionString)
        {
            var timeRecords = new Records_Control(connectionString);

            bool closeApp = false;

            Console.Clear();
            Console.WriteLine("--- Coding Tracker App ---");

            do
            {
                Console.Clear();

                Console.WriteLine(@"
                    Menu:

                1 - Insert Start Time & End Time
                2 - Delete Record
                3 - Update Record
                4 - View All Coding Sessions Duration
                0 - Exit");

                Console.WriteLine("\nMenu Selection: ");
                string? selection = Console.ReadLine();

                switch (selection)
                {
                    case "1":
                        timeRecords.insertionOfStartTimeEndTime(connectionString);
                        break;

                    case "2":
                        timeRecords.deleteSession(connectionString);
                        break;

                    case "3":

                        break;

                    case "4":
                        timeRecords.viewTimeRecords(connectionString);
                        break;

                    case "0":
                        Console.WriteLine("Exiting...");
                        closeApp = true;
                        break;

                    default:
                        Console.WriteLine("Invalid Option. Select Again.");
                        break;
                }

            } while (!closeApp);


        }
    }
}
