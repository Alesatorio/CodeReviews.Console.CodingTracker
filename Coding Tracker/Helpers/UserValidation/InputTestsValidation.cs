

namespace Coding_Tracker.Helpers.UserValidation
{
    internal class InputTestsValidation
    {
        internal int getNum()
        {
            int validNum;
            string? userNum = Console.ReadLine();

            while (string.IsNullOrEmpty(userNum) || !int.TryParse(userNum, out validNum))
            {
                Console.WriteLine("Type a valid number (ex: 12): ");
                userNum = Console.ReadLine();
            }
            
            Console.Clear();
            return validNum;
        }

    }
}
