using Coding_Tracker.Helpers;

namespace Coding_Tracker
{
    internal class User_Interface
    {
        internal void menuOptions(string connectionString)
        {
            var timeRecords = new Records_Control();

            bool closeApp = false;

            Console.Clear();
            Console.WriteLine("--- Coding Tracker App ---");

            do
            {
                Console.WriteLine(@"
                    Menu:

                1 - Insert Start Time
                2 - Insert End Time
                3 - Delete Record
                4 - Update Record
                5 - View All Coding Sessions Duration
                0 - Exit");

                Console.WriteLine("\nMenu Selection: ");
                string? selection = Console.ReadLine();

                switch (selection)
                {
                    case "1":

                        break;
                    case "2":

                        break;
                    case "3":

                        break;
                    case "4":

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
