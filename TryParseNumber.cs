using System;

namespace CSLight
{
    public class TryParseNumber
    {
        static void Main(string[] args)
        {
            int number = TryGetNumber();
            Console.WriteLine(number);
        }

        static int TryGetNumber()
        {
            bool isRunning = true;
            
            while (isRunning)
            {
                Console.Write("Введите число: ");
                string userInput = Console.ReadLine();
                bool gotNumber = int.TryParse(userInput, out int result);

                if (gotNumber == false)
                {
                    Console.WriteLine("Пожалуйста, введите число.");
                }
                else
                {
                    return result;
                }
            }

            return 0;
        }
    }
}
